import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { AdminOrderService } from '../../../services/admin-order-service';
import { AdminOrderDetailsDto } from '../../../models/order/admin-order-details';


@Component({
  selector: 'app-admin-order-details',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './admin-order-details.component.html',
  styleUrl: './admin-order-details.component.scss'
})
export class AdminOrderDetailsComponent  implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly adminOrderService = inject(AdminOrderService);

  orderId!: number;
  order: AdminOrderDetailsDto | null = null;

  statuses: string[] = [];

  loading = true;
  error: string | null = null;

  savingStatus = false;
  statusError: string | null = null;

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    const parsed = Number(idParam);

    if (!idParam || Number.isNaN(parsed) || parsed <= 0) {
      this.error = 'Невалидно ID на поръчка.';
      this.loading = false;
      return;
    }

    this.orderId = parsed;

    this.loadStatuses();
    this.loadOrder();
  }

  private loadStatuses(): void {
    this.adminOrderService.getStatuses().subscribe({
      next: (s) => (this.statuses = s),
      error: (err) => console.error(err),
    });
  }

  private loadOrder(): void {
    this.loading = true;
    this.error = null;

    this.adminOrderService.getOrderDetails(this.orderId).subscribe({
      next: (dto) => {
        this.order = dto;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при зареждане на детайлите за поръчката.';
        this.loading = false;
      },
    });
  }

  goBack(): void {
    this.router.navigate(['/admin/orders']);
  }

  onStatusChange(newStatus: string): void {
    if (!this.order) return;
    if (!newStatus || newStatus === this.order.status) return;

    this.savingStatus = true;
    this.statusError = null;

    this.adminOrderService.updateStatus(this.order.id, newStatus).subscribe({
      next: () => {
        if (this.order) this.order.status = newStatus;
        this.savingStatus = false;
      },
      error: (err) => {
        console.error(err);
        this.statusError = 'Неуспешна промяна на статуса.';
        this.savingStatus = false;
      },
    });
  }

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