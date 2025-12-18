import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Product } from '../models/product/product-dto';
import { TrackInteractionRequest } from '../models/recommendation/track-interaction-request';

@Injectable({
  providedIn: 'root',
})
export class RecommendationService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiUrl;

  private readonly anonKey = 'clothing_store_anon_id';

  private getAnonymousId(): string {
    let id = localStorage.getItem(this.anonKey);
    if (!id) {
      id = crypto.randomUUID();
      localStorage.setItem(this.anonKey, id);
    }
    return id;
  }

  trackInteraction(request: Omit<TrackInteractionRequest, 'anonymousId'>): void {
    const anonymousId = this.getAnonymousId();

    this.http
      .post<void>(`${this.baseUrl}/Tracking`, {
        ...request,
        anonymousId,
      })
      .subscribe({
        next: () => {},
        error: () => {
        },
      });
  }

  getRecommended(categoryId?: number): Observable<Product[]> {
    const anonymousId = this.getAnonymousId();

    const params: any = { anonymousId };
    if (categoryId != null) {
      params.categoryId = categoryId;
    }

    return this.http.get<Product[]>(`${this.baseUrl}/Product/recommended`, {
      params,
    });
  }
}
