import { AdminOrderDetailsItemDto } from "./admin-order-details-item";

export interface AdminOrderDetailsDto {
  id: number;
  createdAt: string;
  status: string;

  customerName: string;
  email: string;
  phone: string;
  address: string;

  totalAmount: number;

  paymentMethod?: string;
  paidAt?: string | null;
  speedyOfficeId?: number | null;
  speedyOfficeLabel?: string | null;
  payPalOrderId?: string | null;

  items: AdminOrderDetailsItemDto[];
}