export interface OrderItemDto {
  productId: number;
  productVariantId?: number | null;
  name: string;
  colorName?: string | null;
  size?: string | null;
  quantity: number;
  unitPrice: number;
  lineTotal: number;
}