import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CartItem } from '../../../models/cart/cart-item';

@Component({
  selector: 'app-cart-card',
  imports: [CommonModule, RouterLink],
  templateUrl: './cart-card.component.html',
  styleUrl: './cart-card.component.scss'
})
export class CartCardComponent {
  @Input({ required: true }) item!: CartItem;

  @Output() remove = new EventEmitter<void>();
  @Output() quantityChange = new EventEmitter<number>();

  onRemoveClick(): void {
    this.remove.emit();
  }

  onQuantityInputChange(event: Event): void {
    const value = Number((event.target as HTMLInputElement).value) || 1;
    this.quantityChange.emit(value);
  }
}
