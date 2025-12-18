export interface ProductFilterDto {
  keyword?: string;
  minPrice?: number;
  maxPrice?: number;
  brand?: string;
  size?: string;
  color?: string;
  inStockOnly?: boolean;
  sortBy?: 'PriceAsc' | 'PriceDesc' | 'Newest' | 'Oldest';
}