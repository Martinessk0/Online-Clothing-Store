import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { ProductCreateDto } from '../models/product/product-create-dto';
import { Product } from '../models/product/product-dto';
import { ProductUpdateDto } from '../models/product/product-update-dto';
import { ProductFilterDto } from '../models/product/product-filter-dto';
import { PagedResult } from '../models/pagedResult/paged-result';
import { ProductFilterOptions } from '../models/product/product-filter-options';


@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly baseUrl = `${environment.apiUrl}/Product`;

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseUrl}/${id}`);
  }

  createProduct(dto: ProductCreateDto): Observable<Product> {
    return this.http.post<Product>(this.baseUrl, dto);
  }

  updateProduct(id: number, dto: ProductUpdateDto): Observable<Product> {
    return this.http.put<Product>(`${this.baseUrl}/${id}`, dto);
  }

  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  filterProducts(
  filter: ProductFilterDto,
  page: number,
  pageSize: number
): Observable<PagedResult<Product>> {
  return this.http.post<PagedResult<Product>>(
    `${this.baseUrl}/filter?page=${page}&pageSize=${pageSize}`,
    filter
  );
}

getFilterOptions(): Observable<ProductFilterOptions> {
  return this.http.get<ProductFilterOptions>(
    `${this.baseUrl}/filter-options`
  );
}


}
