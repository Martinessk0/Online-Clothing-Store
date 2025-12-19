import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

declare global { interface Window { paypal?: any; } }

@Injectable({ providedIn: 'root' })
export class PaypalLoaderService {
  private loading?: Promise<void>;

  load(): Promise<void> {
    if (window.paypal) return Promise.resolve();
    if (this.loading) return this.loading;

    this.loading = new Promise<void>((resolve, reject) => {
      const s = document.createElement('script');
      s.src =
        `https://www.paypal.com/sdk/js?client-id=${encodeURIComponent(environment.paypalClientId)}` +
        `&currency=${encodeURIComponent(environment.paypalCurrency)}` +
        `&intent=capture`;
      s.onload = () => resolve();
      s.onerror = () => reject(new Error('PayPal SDK load failed'));
      document.body.appendChild(s);
    });

    return this.loading;
  }
}
