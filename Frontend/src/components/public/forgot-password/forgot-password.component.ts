import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-forgot-password',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss'
})
export class ForgotPasswordComponent {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);

  submitted = false;
  backendError: string | null = null;
  successMessage: string | null = null;
  loading = false;

  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]]
  });

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    this.backendError = null;
    this.successMessage = null;

    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    const email = this.form.value.email!;

    this.authService.requestPasswordReset(email).subscribe({
      next: (res) => {
        this.loading = false;
        this.successMessage =
          res?.message ||
          'Ако имейлът съществува в системата, изпратихме ти линк за смяна на паролата.';
      },
      error: (err) => {
        this.loading = false;
        const msg =
          err?.error?.message ??
          (typeof err?.error === 'string' ? err.error : '');
        this.backendError = msg || 'Възникна грешка. Опитай отново след малко.';
      }
    });
  }
}
