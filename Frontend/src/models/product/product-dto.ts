import { ProductImage } from "./product-image";
import { ProductVariant } from "./product-variant";

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  brand: string;
  categoryId: number;
  averageRating: number;
  reviewsCount: number;
  variants: ProductVariant[];
  images: ProductImage[];
}