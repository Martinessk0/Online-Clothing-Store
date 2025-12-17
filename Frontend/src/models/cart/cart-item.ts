export interface CartItem {
  productId: number;
  variantId?: number | null;
  name: string;
  price: number;
  quantity: number;
  colorName?: string | null;
  size?: string | null;
  imageUrl?: string | null;
}
