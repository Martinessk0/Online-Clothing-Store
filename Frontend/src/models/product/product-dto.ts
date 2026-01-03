import { ProductImage } from "./product-image";
import { ProductVariant } from "./product-variant";
import { Review } from "../review/review-dto";

export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  brand: string;
  categoryId: number;
  averageRating: number;
  reviewsCount: number;
  reviews: Review[];
  variants: ProductVariant[];
  images: ProductImage[];
}