import { OrderItemDto } from "./order-item";
import type { PaymentMethod } from "./order-create";

export interface OrderDto {
  id: number;
  customerName: string;
  email: string;
  phone: string;
  address: string;
  paymentMethod: PaymentMethod;
  totalAmount: number;
  status: string;
  createdAt: string;
  items: OrderItemDto[];
}
