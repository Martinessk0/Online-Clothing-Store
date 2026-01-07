import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { UserProfile } from '../../../models/auth/user-profile';
import { TwoFactorSetupResponse } from '../../../models/auth/two-factor-setup';
import { TwoFactorEnableResponse } from '../../../models/auth/two-factor-enable';
import * as QRCode from 'qrcode';


@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);

  profile: UserProfile | null = null;
  isLoading = true;
  isSaving = false;
  isEditing = false;
  error: string | null = null;

  twoFaSetup: TwoFactorSetupResponse | null = null;
  twoFaCode = '';
  twoFaError: string | null = null;
  recoveryCodes: string[] | null = null;
  is2faBusy = false;
  qrDataUrl: string | null = null;

  editModel = {
    firstName: '' as string | null,
    lastName: '' as string | null,
    phoneNumber: '' as string | null,
    city: '' as string | null,
    address: '' as string | null
  };

  ngOnInit(): void {
    this.loadProfile();
  }

  get displayName(): string {
    const first = this.profile?.firstName?.trim() || '';
    const last = this.profile?.lastName?.trim() || '';
    const combined = `${first} ${last}`.trim();

    if (combined.length > 0) return combined;
    if (this.profile?.email) return this.profile.email.split('@')[0];
    return 'Потребител';
  }

  get avatarLetter(): string {
    const first = this.profile?.firstName?.trim();
    const last = this.profile?.lastName?.trim();
    const source =
      (first && first.length > 0 && first) ||
      (last && last.length > 0 && last) ||
      this.profile?.email ||
      'U';

    return source.charAt(0).toUpperCase();
  }

  loadProfile(): void {
    this.isLoading = true;
    this.error = null;

    this.authService.getProfile().subscribe({
      next: (data) => {
        this.profile = data;
        this.editModel.firstName = data.firstName ?? '';
        this.editModel.lastName = data.lastName ?? '';
        this.editModel.phoneNumber = data.phoneNumber ?? '';
        this.editModel.city = data.city ?? '';
        this.editModel.address = data.address ?? '';
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Възникна грешка при зареждане на профила.';
        this.isLoading = false;
      }
    });
  }

  startEdit(): void {
    if (!this.profile) return;
    this.editModel.firstName = this.profile.firstName ?? '';
    this.editModel.lastName = this.profile.lastName ?? '';
    this.editModel.phoneNumber = this.profile.phoneNumber ?? '';
    this.editModel.city = this.profile.city ?? '';
    this.editModel.address = this.profile.address ?? '';
    this.isEditing = true;
  }

  cancelEdit(): void {
    this.isEditing = false;
    if (!this.profile) return;
    this.editModel.firstName = this.profile.firstName ?? '';
    this.editModel.lastName = this.profile.lastName ?? '';
    this.editModel.phoneNumber = this.profile.phoneNumber ?? '';
    this.editModel.city = this.profile.city ?? '';
    this.editModel.address = this.profile.address ?? '';
  }

  save(): void {
    if (!this.profile) return;
    this.isSaving = true;
    this.error = null;

    this.authService
      .updateProfile({
        firstName: this.editModel.firstName || '',
        lastName: this.editModel.lastName || '',
        phoneNumber: this.editModel.phoneNumber || '',
        city: this.editModel.city || '',
        address: this.editModel.address || ''
      })
      .subscribe({
        next: (updated) => {
          this.profile = updated;
          this.isSaving = false;
          this.isEditing = false;
        },
        error: (err) => {
          console.error(err);
          this.error = 'Неуспешно запазване на промените.';
          this.isSaving = false;
        }
      });
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/home-page']);
  }

  start2faSetup(): void {
    this.twoFaError = null;
    this.recoveryCodes = null;
    this.is2faBusy = true;

    this.authService.getTwoFactorSetup().subscribe({
      next: async (res) => {
        this.twoFaSetup = res;

        this.qrDataUrl = null;
        if (res.authenticatorUri) {
          await this.buildQr(res.authenticatorUri);
        }

        this.is2faBusy = false;
      },
      error: (err) => {
        this.twoFaError = err?.error?.message ?? 'Неуспешно зареждане на 2FA setup.';
        this.is2faBusy = false;
      }
    });
  }

  enable2fa(): void {
    if (!this.twoFaCode.trim()) return;

    this.twoFaError = null;
    this.is2faBusy = true;

    this.authService.enableTwoFactor(this.twoFaCode).subscribe({
      next: (res: TwoFactorEnableResponse) => {
        this.recoveryCodes = res.recoveryCodes;
        this.twoFaCode = '';
        this.is2faBusy = false;
        this.loadProfile(); // refresh
      },
      error: (err) => {
        this.twoFaError = err?.error?.message ?? 'Грешен код.';
        this.is2faBusy = false;
      }
    });
  }

  disable2fa(): void {
    this.twoFaError = null;
    this.is2faBusy = true;

    this.authService.disableTwoFactor().subscribe({
      next: () => {
        this.twoFaSetup = null;
        this.recoveryCodes = null;
        this.is2faBusy = false;
        this.loadProfile();
      },
      error: (err) => {
        this.twoFaError = err?.error?.message ?? 'Неуспешно изключване на 2FA.';
        this.is2faBusy = false;
      }
    });
  }

  private async buildQr(uri: string): Promise<void> {
    this.qrDataUrl = await QRCode.toDataURL(uri, {
      width: 220,
      margin: 1,
      errorCorrectionLevel: 'M'
    });
  }

}
