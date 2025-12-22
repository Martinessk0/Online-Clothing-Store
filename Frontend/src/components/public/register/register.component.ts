import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { RegisterRequest } from '../../../models/auth/register-request';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, TranslateModule],
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  private readonly fb = inject(FormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  submitted = false;

  backendError: string | null = null;
  backendErrorKey: string | null = null;

  form = this.fb.group(
    {
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.maxLength(20)]],
      city: ['', [Validators.maxLength(100)]],
      address: ['', [Validators.maxLength(200)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]]
    },
    {
      validators: (group: any) => {
        const pass = group.get('password')?.value;
        const confirm = group.get('confirmPassword')?.value;
        return pass === confirm ? null : { passwordMismatch: true };
      }
    }
  );

  get f() {
    return this.form.controls;
  }

  get passwordMismatch(): boolean {
    return !!this.form.errors?.['passwordMismatch'] && this.submitted;
  }

  onSubmit(): void {
    this.submitted = true;
    this.backendError = null;
    this.backendErrorKey = null;

    if (this.form.invalid) return;

    const payload: RegisterRequest = {
      email: this.f.email.value ?? '',
      password: this.f.password.value ?? '',
      confirmPassword: this.f.confirmPassword.value ?? '',
      firstName: this.f.firstName.value ?? '',
      lastName: this.f.lastName.value ?? '',
      phoneNumber: this.f.phoneNumber.value || null,
      city: this.f.city.value || null,
      address: this.f.address.value || null
    };

    this.authService.register(payload).subscribe({
      next: () => this.router.navigate(['/login']),
      error: (err) => {
        const msg = err?.error?.message ?? null;
        this.backendError = msg;
        if (!msg) this.backendErrorKey = 'REGISTER.ERROR_GENERIC';
      }
    });
  }
}
