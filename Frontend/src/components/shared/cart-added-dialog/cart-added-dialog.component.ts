import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartAddedDialogService, CartAddedDialogState } from '../../../services/cart-added-dialog.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart-added-dialog',
  imports: [CommonModule],
  templateUrl: './cart-added-dialog.component.html',
  styleUrl: './cart-added-dialog.component.scss'
})
export class CartAddedDialogComponent implements OnInit, OnDestroy {
  private readonly dialog = inject(CartAddedDialogService);
  private readonly router = inject(Router);

  state: CartAddedDialogState = { open: false };
  private sub?: Subscription;

  ngOnInit(): void {
    this.sub = this.dialog.state$.subscribe(s => (this.state = s));
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  continueShopping(): void {
    this.dialog.close();
  }

  goToCart(): void {
    this.dialog.close();
    this.router.navigate(['/cart']); // смени ако route-а ти е друг
  }
}