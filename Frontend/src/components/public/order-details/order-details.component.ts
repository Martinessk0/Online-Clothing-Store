import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { OrderDto } from '../../../models/order/order';
import { OrderService } from '../../../services/order-service';

@Component({
  selector: 'app-order-details',
  imports: [CommonModule, RouterLink],
  templateUrl: './order-details.component.html',
  styleUrl: './order-details.component.scss'
})
export class OrderDetailsComponent  implements OnInit {
  private readonly orderService = inject(OrderService);
  private readonly route = inject(ActivatedRoute);

  order: OrderDto | null = null;
  loading = false;
  error: string | null = null;

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    const id = idParam ? Number(idParam) : NaN;

    if (!id || Number.isNaN(id)) {
      this.error = 'Невалидна поръчка.';
      return;
    }

    this.loadOrder(id);
  }

  private loadOrder(id: number): void {
    this.loading = true;
    this.error = null;

    this.orderService.getOrder(id).subscribe({
      next: (order: any) => {
        this.order = order;
        this.loading = false;
      },
      error: (err : any) => {
        console.error(err);
        this.error = 'Поръчката не беше намерена или нямаш достъп до нея.';
        this.loading = false;
      }
    });
  }

  get totalItems(): number {
    return this.order?.items?.reduce((sum, i) => sum + i.quantity, 0) ?? 0;
  }

  get paymentMethodLabel(): string {
  if (!this.order) {
    return '';
  }

  switch (this.order.paymentMethod) {
    case 'CashOnDelivery':
      return 'Наложен платеж';
    case 'BankTransfer':
      return 'Банков превод';
    default:
      return this.order.paymentMethod;
  }
}
}