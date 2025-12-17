import { OrderItemDto } from "./order-item";

export interface OrderDto {
  id: number;
  customerName: string;
  email: string;
  totalAmount: number;
  status: string;
  createdAt: string;
  items: OrderItemDto[];
}