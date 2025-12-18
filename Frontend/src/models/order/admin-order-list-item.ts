export interface AdminOrderListItemDto {
  id: number;
  customerName: string;
  email: string;
  phone: string;
  address: string;
  totalAmount: number;
  status: string;
  createdAt: string;
  itemsCount: number;
}
