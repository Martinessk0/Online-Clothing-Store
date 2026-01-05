import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Review } from '../models/review/review-dto';

@Injectable({ providedIn: 'root' })
export class ReviewService {
  private baseUrl = '/api/reviews';

  constructor(private http: HttpClient) {}

  getByProduct(productId: number): Observable<Review[]> {
    return this.http.get<Review[]>(`${this.baseUrl}/product/${productId}`);
  }

  create(data: { productId: number; rating: number; comment?: string }) {
    return this.http.post(this.baseUrl, data);
  }

  update(
    reviewId: number,
    data: { rating: number; comment?: string }
  ) {
    return this.http.put(`${this.baseUrl}/${reviewId}`, data);
  }

  setVisibility(reviewId: number, isVisible: boolean) {
    return this.http.patch(
      `${this.baseUrl}/${reviewId}/visibility?isVisible=${isVisible}`,
      {}
    );
  }
}
