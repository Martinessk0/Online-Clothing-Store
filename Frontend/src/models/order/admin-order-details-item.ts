export interface AdminOrderDetailsItemDto {
  productId: number;
  productVariantId?: number | null;

  productName: string;
  imageUrl?: string | null;

  colorName?: string | null;
  size?: string | null;

  quantity: number;
  unitPrice: number;
  lineTotal: number;
}