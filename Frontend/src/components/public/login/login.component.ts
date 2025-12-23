import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

import { AuthService } from '../../../services/auth-service';
import { LoginRequest } from '../../../models/auth/login-request';
import { CartService } from '../../../services/cart-service';

import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink, TranslateModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly cartService = inject(CartService);
  private readonly translate = inject(TranslateService);

  submitted = false;
  backendError: string | null = null;

  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  get f() {
    return this.form.controls;
  }

  errorTextEmail(): string | null {
    const c = this.f.email;
    if (!(c.dirty || c.touched || this.submitted) || !c.errors) return null;

    if (c.errors['required']) return this.translate.instant('LOGIN.VALIDATION.REQUIRED');
    if (c.errors['email']) return this.translate.instant('LOGIN.VALIDATION.EMAIL');
    return this.translate.instant('LOGIN.VALIDATION.INVALID');
  }

  errorTextPassword(): string | null {
    const c = this.f.password;
    if (!(c.dirty || c.touched || this.submitted) || !c.errors) return null;

    if (c.errors['required']) return this.translate.instant('LOGIN.VALIDATION.REQUIRED');
    if (c.errors['minlength']) {
      const n = c.errors['minlength']?.requiredLength ?? 6;
      return this.translate.instant('LOGIN.VALIDATION.MIN_LENGTH', { n });
    }
    return this.translate.instant('LOGIN.VALIDATION.INVALID');
  }

  onSubmit(): void {
    this.submitted = true;
    this.backendError = null;

    if (this.form.invalid) return;

    const payload: LoginRequest = {
      email: this.f.email.value ?? '',
      password: this.f.password.value ?? ''
    };

    this.authService.login(payload).subscribe({
      next: () => {
        this.cartService.reloadForCurrentUser(false);
        this.router.navigate(['/']);
      },
      error: (err) => {
        // ако бекендът върне message - показваме него, иначе наш текст
        this.backendError =
          err?.error?.message ?? this.translate.instant('LOGIN.ERROR_INVALID');
      }
    });
  }
}
