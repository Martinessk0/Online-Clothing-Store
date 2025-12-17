import { Injectable, inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Cart } from '../models/cart/cart';
import { CartItem } from '../models/cart/cart-item';
import { Product } from '../models/product/product-dto';
import { ProductVariant } from '../models/product/product-variant';
import { AuthService } from './auth-service';

const CART_KEY_PREFIX = 'clothing_store_cart_';
const GUEST_KEY = CART_KEY_PREFIX + 'guest';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private readonly authService = inject(AuthService);

  private readonly cartSubject = new BehaviorSubject<Cart>({
    items: [],
    totalAmount: 0,
    totalQuantity: 0
  });
  readonly cart$ = this.cartSubject.asObservable();

  private storageKey: string = GUEST_KEY;

  constructor() {
    // при стартиране – зареждаме кошницата за текущия потребител (или guest)
    this.reloadForCurrentUser(false);
  }

  /** Кой ключ да ползваме за даден user */
  private getStorageKeyForUser(userId: string | null): string {
    if (!userId) {
      return GUEST_KEY;
    }

    return CART_KEY_PREFIX + userId;
  }

  /** Зарежда кошница за текущия потребител */
  reloadForCurrentUser(mergeGuestIntoUser: boolean): void {
    const userId = this.authService.getUserId();

    const targetKey = this.getStorageKeyForUser(userId);
    this.storageKey = targetKey;

    // ако искаш guest количката да се прехвърля към user при логин,
    // сложи mergeGuestIntoUser = true при login
    if (userId && mergeGuestIntoUser) {
      const guestCart = this.safeParse(localStorage.getItem(GUEST_KEY));
      const userCart = this.safeParse(localStorage.getItem(targetKey));

      const merged = this.mergeCarts(userCart, guestCart);

      localStorage.removeItem(GUEST_KEY);
      localStorage.setItem(targetKey, JSON.stringify(merged));

      this.cartSubject.next(this.recalculate(merged));
      return;
    }

    const cart = this.safeParse(localStorage.getItem(targetKey));
    this.cartSubject.next(this.recalculate(cart));
  }

  /** Безопасно парсване от localStorage */
  private safeParse(raw: string | null): Cart {
    if (!raw) {
      return { items: [], totalAmount: 0, totalQuantity: 0 };
    }

    try {
      const parsed = JSON.parse(raw) as Cart;
      if (!Array.isArray(parsed.items)) {
        return { items: [], totalAmount: 0, totalQuantity: 0 };
      }
      return this.recalculate(parsed);
    } catch {
      return { items: [], totalAmount: 0, totalQuantity: 0 };
    }
  }

  /** Слива два коша (примерно user + guest) */
  private mergeCarts(target: Cart, source: Cart): Cart {
    const map = new Map<string, CartItem>();

    const keyFn = (i: CartItem) => `${i.productId}_${i.variantId ?? 'null'}`;

    for (const i of target.items) {
      map.set(keyFn(i), { ...i });
    }
    for (const i of source.items) {
      const key = keyFn(i);
      const existing = map.get(key);
      if (existing) {
        existing.quantity += i.quantity;
      } else {
        map.set(key, { ...i });
      }
    }

    return this.recalculate({
      items: Array.from(map.values()),
      totalAmount: 0,
      totalQuantity: 0
    });
  }

  /** Пресмята тотали и пази в localStorage */
  private saveCart(cart: Cart): void {
    const normalized = this.recalculate(cart);
    localStorage.setItem(this.storageKey, JSON.stringify(normalized));
    this.cartSubject.next(normalized);
  }

  private recalculate(cart: Cart): Cart {
    const totalAmount = cart.items.reduce(
      (sum, item) => sum + item.price * item.quantity,
      0
    );
    const totalQuantity = cart.items.reduce(
      (sum, item) => sum + item.quantity,
      0
    );

    return {
      ...cart,
      items: [...cart.items],
      totalAmount,
      totalQuantity
    };
  }

  get cart(): Cart {
    return this.cartSubject.value;
  }

  /** Добавяне на продукт в кошницата */
  addProduct(
    product: Product,
    quantity = 1,
    variant?: ProductVariant | null
  ): void {
    if (quantity <= 0) {
      quantity = 1;
    }

    const current: Cart = {
      ...this.cart,
      items: [...this.cart.items]
    };

    const variantId = variant?.id ?? null;

    const existing = current.items.find(
      (i) =>
        i.productId === product.id && (i.variantId ?? null) === variantId
    );

    if (existing) {
      existing.quantity += quantity;
    } else {
      const pickedVariant = variant ?? product.variants?.[0] ?? null;

      const newItem: CartItem = {
        productId: product.id,
        variantId: pickedVariant?.id ?? null,
        name: product.name,
        price: product.price,
        quantity,
        colorName: pickedVariant?.colorName ?? null,
        size: pickedVariant?.size ?? null,
        imageUrl: product.images?.[0]?.url ?? null
      };

      current.items.push(newItem);
    }

    this.saveCart(current);
  }

  updateQuantity(
    productId: number,
    variantId: number | null,
    quantity: number
  ): void {
    const current: Cart = {
      ...this.cart,
      items: [...this.cart.items]
    };

    const item = current.items.find(
      (i) =>
        i.productId === productId &&
        (i.variantId ?? null) === (variantId ?? null)
    );

    if (!item) {
      return;
    }

    if (quantity <= 0) {
      this.removeItem(productId, variantId);
      return;
    }

    item.quantity = quantity;
    this.saveCart(current);
  }

  removeItem(productId: number, variantId: number | null): void {
    const current: Cart = {
      ...this.cart,
      items: this.cart.items.filter(
        (i) =>
          !(
            i.productId === productId &&
            (i.variantId ?? null) === (variantId ?? null)
          )
      )
    };

    this.saveCart(current);
  }

  clear(): void {
    this.saveCart({ items: [], totalAmount: 0, totalQuantity: 0 });
  }
}
