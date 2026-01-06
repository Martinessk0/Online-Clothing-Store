import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { LoginRequest } from '../../../models/auth/login-request';
import { CartService } from '../../../services/cart-service';

@Component({
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly cartService = inject(CartService);

  submitted = false;
  backendError: string | null = null;

  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  get f() {
    return this.form.controls;
  }

   onSubmit(): void {
    this.submitted = true;
    this.backendError = null;

    if (this.form.invalid) {
      return;
    }

    const payload: LoginRequest = {
      email: this.f.email.value ?? '',
      password: this.f.password.value ?? ''
    };

    this.authService.login(payload).subscribe({
      next: (res) => {
        this.cartService.reloadForCurrentUser(false);
        this.router.navigate(['/']);
      },
      error: (err) => {
        const msg =
          err?.error?.message ??
          (typeof err?.error === 'string' ? err.error : '');

        if (msg === 'Email is not confirmed.' || msg === 'Email is not confirmed') {
          this.backendError = 'Имейлът не е потвърден. Моля, провери пощата си.';
        } else {
          this.backendError = msg || 'Невалиден имейл или парола.';
        }
      }
    });
  }
}