import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product/product-dto';

export type CartAddedDialogState =
  | { open: false }
  | { open: true; productName: string };

@Injectable({ providedIn: 'root' })
export class CartAddedDialogService {
  private readonly _state$ = new BehaviorSubject<CartAddedDialogState>({ open: false });
  readonly state$ = this._state$.asObservable();

  open(product: Product | null | undefined): void {
    const productName = product?.name?.trim() || 'Продуктът';
    this._state$.next({ open: true, productName });
  }

  close(): void {
    this._state$.next({ open: false });
  }
}
