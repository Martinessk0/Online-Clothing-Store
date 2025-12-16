import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

export interface ProductImageUploadResponse {
  url: string;
  publicId: string;
}

@Injectable({ providedIn: 'root' })
export class ProductImageUploadService {
  private readonly baseUrl = `${environment.apiUrl}/Image/product`;

  constructor(private http: HttpClient) {}

  uploadProductImage(file: File): Observable<ProductImageUploadResponse> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post<ProductImageUploadResponse>(this.baseUrl, formData);
  }
}
