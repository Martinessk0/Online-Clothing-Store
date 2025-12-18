import { Component, inject, OnInit } from '@angular/core';
import { AdminOrderListItemDto } from '../../../models/order/admin-order-list-item';
import { AdminOrderService } from '../../../services/admin-order-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-order',
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-order.component.html',
  styleUrl: './admin-order.component.scss'
})
export class AdminOrderComponent  implements OnInit {
  private readonly adminOrderService = inject(AdminOrderService);

  orders: AdminOrderListItemDto[] = [];
  statuses: string[] = [];

  loading = false;
  error: string | null = null;
  savingId: number | null = null;

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
        this.savingId = null;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Неуспешна промяна на статуса.';
        this.savingId = null;
      }
    });
  }

  //Ще се промени като добавим двата езика с translateService-а
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