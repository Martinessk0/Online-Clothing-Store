import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CartService } from '../../../services/cart-service';
import { CartItem } from '../../../models/cart/cart-item';
import { OrderCreateDto } from '../../../models/order/order-create';
import { OrderService } from '../../../services/order-service';

@Component({
  selector: 'app-checkout',
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent {
  private readonly fb = inject(FormBuilder);
  private readonly cartService = inject(CartService);
  private readonly orderService = inject(OrderService);
  private readonly router = inject(Router);

  loading = false;
  backendError: string | null = null;
  successOrderId: number | null = null;

  form = this.fb.group({
    customerName: ['', [Validators.required, Validators.minLength(2)]],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required, Validators.minLength(6)]],
    address: ['', [Validators.required, Validators.minLength(5)]],
    paymentMethod: ['CashOnDelivery', Validators.required]
  });

  get items(): CartItem[] {
    return this.cartService.cart.items;
  }

  get total(): number {
    return this.cartService.cart.totalAmount;
  }

  get f() {
    return this.form.controls;
  }

  submit(): void {
    if (this.form.invalid || !this.items.length) {
      this.form.markAllAsTouched();
      return;
    }

    const payload: OrderCreateDto = {
      customerName: this.f.customerName.value ?? '',
      email: this.f.email.value ?? '',
      phone: this.f.phone.value ?? '',
      address: this.f.address.value ?? '',
      paymentMethod: this.f.paymentMethod.value as any,
      items: this.items.map(i => ({
        productId: i.productId,
        productVariantId: i.variantId ?? null,
        quantity: i.quantity
      }))
    };

    this.loading = true;
    this.backendError = null;

    this.orderService.createOrder(payload).subscribe({
      next: res => {
        this.loading = false;
        this.successOrderId = res.orderId;
        this.cartService.clear();
      },
      error: err => {
        console.error(err);
        this.loading = false;
        this.backendError =
          err?.error?.message ?? 'Възникна грешка при създаване на поръчката.';
      }
    });
  }
}
