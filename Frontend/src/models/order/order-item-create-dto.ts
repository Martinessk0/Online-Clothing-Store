export interface OrderCreateItemDto {
  productId: number;
  productVariantId?: number | null;
  quantity: number;
}
