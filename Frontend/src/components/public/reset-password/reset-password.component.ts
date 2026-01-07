import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { ResetPasswordRequest } from '../../../models/auth/reset-password-request';

@Component({
  selector: 'app-reset-password',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.scss'
})
export class ResetPasswordComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  private readonly authService = inject(AuthService);

  submitted = false;
  backendError: string | null = null;
  successMessage: string | null = null;
  loading = false;

  userId: string | null = null;
  token: string | null = null;

  form = this.fb.group({
    newPassword: ['', [Validators.required, Validators.minLength(6)]],
    confirmPassword: ['', [Validators.required]]
  });

  get f() {
    return this.form.controls;
  }

  ngOnInit(): void {
    this.userId = this.route.snapshot.queryParamMap.get('userId');
    this.token = this.route.snapshot.queryParamMap.get('token');

    if (!this.userId || !this.token) {
      this.backendError = 'Невалиден или изтекъл линк за смяна на паролата.';
    }
  }

  onSubmit(): void {
    this.submitted = true;
    this.backendError = null;
    this.successMessage = null;

    if (this.form.invalid || !this.userId || !this.token) {
      return;
    }

    const newPassword = this.form.value.newPassword!;
    const confirmPassword = this.form.value.confirmPassword!;

    if (newPassword !== confirmPassword) {
      this.backendError = 'Паролите не съвпадат.';
      return;
    }

    this.loading = true;

    const payload: ResetPasswordRequest = {
      userId: this.userId,
      token: this.token,
      newPassword,
      confirmPassword
    };

    this.authService.resetPassword(payload).subscribe({
      next: (res) => {
        this.loading = false;
        this.successMessage =
          res?.message || 'Паролата беше сменена успешно. Можеш да влезеш с новата парола.';

        // Леко quality-of-life – прехвърляме към login
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      },
      error: (err) => {
        this.loading = false;
        const msg =
          err?.error?.message ??
          (typeof err?.error === 'string' ? err.error : '');
        this.backendError = msg || 'Неуспешна смяна на паролата.';
      }
    });
  }
}
