import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { AdminOrderListItemDto } from '../models/order/admin-order-list-item';
import { AdminOrderDetailsDto } from '../models/order/admin-order-details';

@Injectable({
  providedIn: 'root'
})
export class AdminOrderService {
  private readonly baseUrl = `${environment.apiUrl}/admin/orders`;

  constructor(private http: HttpClient) { }

  getOrders(): Observable<AdminOrderListItemDto[]> {
    return this.http.get<AdminOrderListItemDto[]>(this.baseUrl);
  }

  getStatuses(): Observable<string[]> {
    return this.http.get<string[]>(`${this.baseUrl}/statuses`);
  }

  updateStatus(id: number, status: string): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}/status`, { status });
  }

  getOrderDetails(orderId: number) {
    return this.http.get<AdminOrderDetailsDto>(`${this.baseUrl}/${orderId}`);
  }

}
