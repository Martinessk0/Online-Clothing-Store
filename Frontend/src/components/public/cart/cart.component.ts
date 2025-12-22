import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

import { CartService } from '../../../services/cart-service';
import { CartItem } from '../../../models/cart/cart-item';
import { CartCardComponent } from '../../shared/cart-card/cart-card.component';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    CartCardComponent,
    TranslateModule
  ],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss'
})
export class CartComponent {
  private readonly cartService = inject(CartService);

  get items(): CartItem[] {
    return this.cartService.cart.items;
  }

  get total(): number {
    return this.cartService.cart.totalAmount;
  }

  get totalQuantity(): number {
    return this.cartService.cart.totalQuantity;
  }

  updateQuantity(item: CartItem, quantity: number): void {
    this.cartService.updateQuantity(
      item.productId,
      item.variantId ?? null,
      quantity
    );
  }

  remove(item: CartItem): void {
    this.cartService.removeItem(
      item.productId,
      item.variantId ?? null
    );
  }

  clear(): void {
    this.cartService.clear();
  }
}
