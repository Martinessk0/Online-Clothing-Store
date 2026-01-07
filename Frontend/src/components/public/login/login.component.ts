import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { LoginRequest } from '../../../models/auth/login-request';
import { CartService } from '../../../services/cart-service';

@Component({
  selector: 'app-login',
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
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
  needs2fa = false;

  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    twoFactorCode: [''],
    recoveryCode: [''],
    useRecovery: [false],
  });

  get f() {
    return this.form.controls;
  }

  get useRecoveryValue(): boolean {
    return !!this.form.get('useRecovery')?.value;
  }

  onUseRecoveryChanged(): void {
    if (this.useRecoveryValue) {
      this.f.twoFactorCode.setValue('');
    } else {
      this.f.recoveryCode.setValue('');
    }
  }

  onSubmit(): void {
    this.submitted = true;
    this.backendError = null;

    if (this.form.invalid) return;

    if (this.needs2fa) {
      if (!this.useRecoveryValue && !this.f.twoFactorCode.value?.trim()) {
        this.backendError = 'Въведи кода от Authenticator приложението.';
        return;
      }
      if (this.useRecoveryValue && !this.f.recoveryCode.value?.trim()) {
        this.backendError = 'Въведи recovery code.';
        return;
      }
    }

    const payload: LoginRequest = {
      email: this.f.email.value ?? '',
      password: this.f.password.value ?? '',
      twoFactorCode: this.needs2fa && !this.useRecoveryValue ? (this.f.twoFactorCode.value ?? '') : undefined,
      recoveryCode: this.needs2fa && this.useRecoveryValue ? (this.f.recoveryCode.value ?? '') : undefined,
    };

    this.authService.login(payload).subscribe({
      next: (res) => {
        if (res.requiresTwoFactor) {
          this.needs2fa = true;
          this.backendError = 'Въведи кода от Authenticator приложението.';
          return;
        }

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
