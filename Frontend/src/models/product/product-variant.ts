export interface ProductVariant {
  id: number;
  colorId: number;
  colorName: string;
  colorHex?: string | null;
  size: string;
  stock: number;
}
