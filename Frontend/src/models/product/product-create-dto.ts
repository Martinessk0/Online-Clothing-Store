import { ProductImageCreateDto } from "./product-image-create-dto";
import { ProductVariantCreateDto } from "./product-variant-create-dto";

export interface ProductCreateDto {
  name: string;
  description: string;
  price: number;
  brand: string;
  categoryId: number;
  variants: ProductVariantCreateDto[];
  images: ProductImageCreateDto[];
}