import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators, AbstractControl } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CartService } from '../../../services/cart-service';
import { CartItem } from '../../../models/cart/cart-item';
import { OrderCreateDto } from '../../../models/order/order-create';
import { OrderService } from '../../../services/order-service';
import { SpeedyOfficePickerComponent, SpeedyPickedOffice } from '../../shared/speedy-office-picker/speedy-office-picker.component';
import { PaypalApiService } from '../../../services/paypal-api.service';
import { PaypalLoaderService } from '../../../services/paypal-loader.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-checkout',
  imports: [CommonModule, ReactiveFormsModule, RouterLink, SpeedyOfficePickerComponent],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent {
  private readonly fb = inject(FormBuilder);
  private readonly cartService = inject(CartService);
  private readonly orderService = inject(OrderService);
  private readonly router = inject(Router);
  private readonly paypalLoader = inject(PaypalLoaderService);
  private readonly paypalApi = inject(PaypalApiService);

  loading = false;
  backendError: string | null = null;
  backendErrorsList: string[] = [];
  successOrderId: number | null = null;
  speedyPickerOpen = false;
  selectedSpeedyOffice: SpeedyPickedOffice | null = null;
  paypalRendering = false;
  paypalOrderId: number | null = null;

  form = this.fb.group({
    customerName: ['', [Validators.required, Validators.minLength(2)]],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required, Validators.minLength(6)]],
    address: ['', [Validators.required, Validators.minLength(5)]],
    paymentMethod: ['CashOnDelivery', Validators.required],
    deliveryMethod: ['Address', Validators.required],
  });

  get items(): CartItem[] {
    return this.cartService.cart.items;
  }

  get total(): number {
    return this.cartService.cart.totalAmount;
  }

  get f() {
    return this.form.controls;
  }

  isInvalid(name: keyof CheckoutComponent['form']['controls']): boolean {
    const c = this.form.get(name as string);
    return !!c && c.invalid && (c.dirty || c.touched);
  }

  errorText(name: keyof CheckoutComponent['form']['controls']): string | null {
    const c = this.form.get(name as string);
    if (!c || !(c.dirty || c.touched) || !c.errors) return null;

    if (c.errors['required']) return 'Полето е задължително.';
    if (c.errors['email']) return 'Моля, въведи валиден имейл.';
    if (c.errors['minlength']) {
      const req = c.errors['minlength'].requiredLength;
      return `Минимална дължина: ${req} символа.`;
    }

    if (c.errors['server']) return String(c.errors['server']);

    return 'Невалидна стойност.';
  }

  submit(): void {
    this.backendError = null;
    this.backendErrorsList = [];
    this.form.setErrors(null);

    if (this.f.paymentMethod.value === 'PayPal') {
      this.backendError = 'Моля, използвай PayPal бутоните по-долу.';
      return;
    }

    if (this.form.invalid || !this.items.length) {
      this.form.markAllAsTouched();
      return;
    }

    const payload: OrderCreateDto = {
      customerName: this.f.customerName.value ?? '',
      email: this.f.email.value ?? '',
      phone: this.f.phone.value ?? '',
      address: this.f.address.value ?? '',
      paymentMethod: this.f.paymentMethod.value as any,
      items: this.items.map(i => ({
        productId: i.productId,
        productVariantId: i.variantId ?? null,
        quantity: i.quantity
      })),
      speedyOfficeId: this.selectedSpeedyOffice?.id ?? null,
      speedyOfficeLabel: this.selectedSpeedyOffice?.label ?? null
    };

    this.loading = true;

    this.orderService.createOrder(payload).subscribe({
      next: res => {
        this.loading = false;
        this.successOrderId = res.orderId;
        this.cartService.clear();
      },
      error: err => {
        console.error(err);
        this.loading = false;
        this.applyBackendErrors(err);
      }
    });
  }

  private applyBackendErrors(err: any): void {
    const message = err?.error?.message;
    if (message) this.backendError = message;

    const errorsObj = err?.error?.errors;
    if (errorsObj && typeof errorsObj === 'object') {
      const flat: string[] = [];

      for (const key of Object.keys(errorsObj)) {
        const msgs = Array.isArray(errorsObj[key]) ? errorsObj[key] : [String(errorsObj[key])];
        for (const m of msgs) flat.push(m);

        const controlName = this.mapBackendFieldToControl(key);
        if (controlName) {
          const ctrl = this.form.get(controlName);
          if (ctrl) {
            ctrl.setErrors({ ...(ctrl.errors ?? {}), server: msgs.join(' ') });
            ctrl.markAsTouched();
          }
        }
      }

      this.backendErrorsList = flat;
      if (!this.backendError && flat.length) {
        this.backendError = 'Моля, провери въведените данни.';
      }
      return;
    }

    const fallback =
      err?.error?.detail ||
      err?.message ||
      'Възникна грешка при създаване на поръчката.';
    this.backendError = this.backendError ?? fallback;
  }

  private mapBackendFieldToControl(field: string): string | null {
    const clean = field.split('.').pop() ?? field;

    const map: Record<string, string> = {
      CustomerName: 'customerName',
      customerName: 'customerName',
      Email: 'email',
      email: 'email',
      Phone: 'phone',
      phone: 'phone',
      Address: 'address',
      address: 'address',
      PaymentMethod: 'paymentMethod',
      paymentMethod: 'paymentMethod'
    };

    return map[clean] ?? null;
  }

  openSpeedyPicker(): void {
    this.speedyPickerOpen = true;
  }

  onSpeedyPicked(office: SpeedyPickedOffice): void {
    this.selectedSpeedyOffice = office;

    this.form.patchValue({
      deliveryMethod: 'SpeedyOffice',
      address: `Speedy офис: ${office.label}`
    });

    this.form.get('address')?.markAsDirty();
    this.form.get('address')?.markAsTouched();
  }

  async renderPayPalButtons(containerId = 'paypal-buttons'): Promise<void> {
    this.backendError = null;
    this.backendErrorsList = [];

    if (this.paypalRendering) return;

    if (this.form.invalid || !this.items.length) {
      this.form.markAllAsTouched();
      return;
    }

    this.paypalRendering = true;

    try {
      await this.paypalLoader.load();

      const el = document.getElementById(containerId);
      if (!el) return;
      el.innerHTML = '';

      window.paypal.Buttons({
        createOrder: async () => {
          // 1) Създаваме order в нашия бекенд (резервира стока)
          const payload: OrderCreateDto = {
            customerName: this.f.customerName.value ?? '',
            email: this.f.email.value ?? '',
            phone: this.f.phone.value ?? '',
            address: this.f.address.value ?? '',
            paymentMethod: 'PayPal',
            items: this.items.map(i => ({
              productId: i.productId,
              productVariantId: i.variantId ?? null,
              quantity: i.quantity
            })),
            speedyOfficeId: this.selectedSpeedyOffice?.id ?? null,
            speedyOfficeLabel: this.selectedSpeedyOffice?.label ?? null
          };

          const res = await this.orderService.createOrder(payload).toPromise();
          this.paypalOrderId = res!.orderId;

          // 2) Create PayPal order през нашия бекенд
          const pp = await this.paypalApi.create(this.paypalOrderId).toPromise();
          return pp!.paypalOrderId;
        },

        onCancel: async () => {
          try {
            if (this.paypalOrderId) {
              // await this.paypalApi.cancel(this.paypalOrderId).toPromise();
            }
          } catch (e) {
            console.error('Cancel endpoint failed', e);
          } finally {
            this.paypalOrderId = null;
          }

          await this.swalBase().fire({
            icon: 'info',
            title: 'Плащането е прекъснато',
            text: 'Не беше извършено плащане. Можеш да опиташ отново или да избереш наложен платеж.',
            confirmButtonText: 'ОК'
          });
        },

        onApprove: async (data: any) => {
          if (!this.paypalOrderId) {
            this.backendError = 'Липсва номер на поръчка.';
            return;
          }

          await this.paypalApi.capture(this.paypalOrderId, data.orderID).toPromise();

          this.successOrderId = this.paypalOrderId;
          this.cartService.clear();
        },

        onError: (err: any) => {
          console.error(err);
          this.backendError = 'PayPal грешка. Моля, пробвай пак.';
          this.router.navigate(['/cart']);
        }
      }).render(`#${containerId}`);
    } catch (e) {
      console.error(e);
      this.backendError = 'Не успях да заредя PayPal.';
    } finally {
      this.paypalRendering = false;
    }
  }

  private isDark(): boolean {
    return document.documentElement.classList.contains('dark');
  }

  private swalBase() {
    const dark = this.isDark();
    return Swal.mixin({
      background: dark ? '#0f172a' : '#ffffff',
      color: dark ? '#e2e8f0' : '#0f172a'
    });
  }
}
