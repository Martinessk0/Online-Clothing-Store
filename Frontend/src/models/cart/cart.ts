import { CartItem } from './cart-item';

export interface Cart {
  items: CartItem[];
  totalAmount: number;
  totalQuantity: number;
}
