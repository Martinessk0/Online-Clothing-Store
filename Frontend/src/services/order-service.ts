import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { OrderDto } from '../models/order/order';
import { OrderCreateDto } from '../models/order/order-create';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private readonly baseUrl = `${environment.apiUrl}/Order`;

  constructor(private http: HttpClient) {}

  createOrder(dto: OrderCreateDto): Observable<{ orderId: number }> {
    return this.http.post<{ orderId: number }>(this.baseUrl, dto);
  }

  getOrder(id: number): Observable<OrderDto> {
    return this.http.get<OrderDto>(`${this.baseUrl}/${id}`);
  }
}
