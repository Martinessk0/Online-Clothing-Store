import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserProfile } from '../../../models/auth/user-profile';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-profile',
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss'
})
export class ProfileComponent implements OnInit {
  private readonly authService = inject(AuthService);

  profile: UserProfile | null = null;
  isLoading = true;
  error: string | null = null;
  isSaving = false;

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    this.isLoading = true;
    this.error = null;

    this.authService.getProfile().subscribe({
      next: (data) => {
        this.profile = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Възникна грешка при зареждане на профила.';
        console.error(err);
        this.isLoading = false;
      },
    });
  }

  save(): void {
    if (!this.profile) return;

    this.isSaving = true;
    this.error = null;

    this.authService.updateProfile(this.profile).subscribe({
      next: (data) => {
        this.profile = data;
        this.isSaving = false;
      },
      error: (err) => {
        this.error = 'Неуспешно запазване на промените.';
        console.error(err);
        this.isSaving = false;
      },
    });
  }
}