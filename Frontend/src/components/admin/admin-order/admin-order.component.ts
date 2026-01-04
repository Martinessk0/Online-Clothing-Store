import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AdminOrderListItemDto } from '../../../models/order/admin-order-list-item';
import { AdminOrderService } from '../../../services/admin-order-service';
import { RouterLink } from '@angular/router';
import { AdminOrderDetailsDto } from '../../../models/order/admin-order-details';

@Component({
  selector: 'app-admin-order',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './admin-order.component.html',
  styleUrl: './admin-order.component.scss'
})
export class AdminOrderComponent implements OnInit {
  private readonly adminOrderService = inject(AdminOrderService);

  orders: AdminOrderListItemDto[] = [];
  statuses: string[] = [];

  loading = false;
  error: string | null = null;
  savingId: number | null = null;

  // Drawer state
  detailsOpen = false;
  detailsLoading = false;
  detailsError: string | null = null;

  selectedOrderId: number | null = null;
  orderDetails: AdminOrderDetailsDto | null = null;

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    this.loading = true;
    this.error = null;

    this.adminOrderService.getStatuses().subscribe({
      next: (statuses) => {
        this.statuses = statuses;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при зареждане на статусите.';
      }
    });

    this.adminOrderService.getOrders().subscribe({
      next: (orders) => {
        this.orders = orders;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Възникна грешка при зареждане на поръчките.';
        this.loading = false;
      }
    });
  }

  onStatusChange(order: AdminOrderListItemDto, newStatus: string): void {
    if (!newStatus || newStatus === order.status) {
      return;
    }

    this.savingId = order.id;

    this.adminOrderService.updateStatus(order.id, newStatus).subscribe({
      next: () => {
        order.status = newStatus;

        // ако drawer-а е отворен за същата поръчка — обнови статуса и там
        if (this.orderDetails && this.orderDetails.id === order.id) {
          this.orderDetails.status = newStatus;
        }

        this.savingId = null;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Неуспешна промяна на статуса.';
        this.savingId = null;
      }
    });
  }

  openDetails(orderId: number): void {
    this.detailsOpen = true;
    this.selectedOrderId = orderId;
    this.fetchDetails(orderId);
  }

  closeDetails(): void {
    this.detailsOpen = false;
    this.detailsLoading = false;
    this.detailsError = null;
    this.selectedOrderId = null;
    this.orderDetails = null;
  }

  private fetchDetails(orderId: number): void {
    this.detailsLoading = true;
    this.detailsError = null;
    this.orderDetails = null;

    this.adminOrderService.getOrderDetails(orderId).subscribe({
      next: (dto: AdminOrderDetailsDto) => {
        this.orderDetails = dto;
        this.detailsLoading = false;
      },
      error: (err: any) => {
        console.error(err);
        this.detailsError = 'Грешка при зареждане на детайлите.';
        this.detailsLoading = false;
      }
    });
  }

  // Ще се промени като добавим двата езика с translateService-а
  getStatusLabel(status: string): string {
    switch (status) {
      case 'Pending':
        return 'Чакаща';
      case 'Processing':
        return 'В обработка';
      case 'Shipped':
        return 'Изпратена';
      case 'Completed':
        return 'Завършена';
      case 'Cancelled':
        return 'Отказана';
      default:
        return status;
    }
  }
}
