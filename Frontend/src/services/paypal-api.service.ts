import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Injectable({ providedIn: 'root' })
export class PaypalApiService {
  constructor(private http: HttpClient) {}

  create(orderId: number) {
    return this.http.post<{ paypalOrderId: string }>(
      `${environment.apiUrl}/paypal/create`,
      { orderId }
    );
  }

  capture(orderId: number, paypalOrderId: string) {
    return this.http.post<{ success: boolean }>(
      `${environment.apiUrl}/paypal/capture`,
      { orderId, payPalOrderId: paypalOrderId }
    );
  }
}
