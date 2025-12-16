export interface ProductCreateDto {
  name: string;
  description: string;
  price: number;
  brand: string;
  size: string;
  color: string;
  stock: number;
  categoryId: number;
}