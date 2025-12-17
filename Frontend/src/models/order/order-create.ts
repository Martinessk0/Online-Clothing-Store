import { OrderCreateItemDto } from "./order-item-create-dto";

export type PaymentMethod = 'CashOnDelivery' | 'BankTransfer';

export interface OrderCreateDto {
  customerName?: string | null;
  email?: string | null;
  phone?: string | null;
  address?: string | null;
  paymentMethod: PaymentMethod;
  items: OrderCreateItemDto[];
}
