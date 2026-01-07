import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { OrderDto } from '../../../models/order/order';
import { OrderService } from '../../../services/order-service';

@Component({
  selector: 'app-my-orders',
  imports: [CommonModule, RouterLink],
  templateUrl: './my-orders.component.html',
  styleUrl: './my-orders.component.scss'
})
export class MyOrdersComponent implements OnInit {
  private readonly orderService = inject(OrderService);

  orders: OrderDto[] = [];
  loading = false;
  error: string | null = null;

  ngOnInit(): void {
    this.loadOrders();
  }

   loadOrders(): void {
    this.loading = true;
    this.error = null;

    this.orderService.getMyOrders().subscribe({
      next: (orders) => {
        this.orders = orders;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);

        if (err.status === 403) {
          this.error =
            'Трябва да потвърдиш имейла си, за да виждаш своите поръчки.';
        } else {
          this.error = 'Възникна грешка при зареждане на поръчките.';
        }

        this.loading = false;
      }
    });
  }

}