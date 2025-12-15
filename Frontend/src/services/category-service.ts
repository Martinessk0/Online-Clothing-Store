import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { CategoryDto } from '../models/category/category-dto';
import { CategoryCreate } from '../models/category/category-create-dto';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  /** GET: /api/Category */
  getAll(): Observable<CategoryDto[]> {
    return this.http.get<CategoryDto[]>(`${this.apiUrl}/category`);
  }

  /** POST: /api/Category */
  create(payload: CategoryCreate): Observable<CategoryDto> {
    return this.http.post<CategoryDto>(`${this.apiUrl}/category`, payload);
  }

  /** PUT: /api/Category/{id} */
  edit(id: number, payload: CategoryCreate): Observable<CategoryDto> {
    return this.http.put<CategoryDto>(`${this.apiUrl}/category/${id}`, payload);
  }

  /** DELETE: /api/Category/{id} */
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/category/${id}`);
  }
}
