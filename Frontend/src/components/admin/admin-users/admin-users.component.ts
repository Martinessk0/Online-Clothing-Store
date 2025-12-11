import { Component, OnInit } from '@angular/core';
import { UserProfile } from '../../../models/auth/user-profile';
import { AdminUsersService } from '../../../services/admin-users-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin-users',
  imports: [CommonModule],
  templateUrl: './admin-users.component.html',
  styleUrl: './admin-users.component.scss'
})
export class AdminUsersComponent implements OnInit {
  users: UserProfile[] = [];
  loading = false;
  error: string | null = null;

  constructor(private adminUsersService: AdminUsersService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.loading = true;
    this.error = null;

    this.adminUsersService.getUsers().subscribe({
      next: (users) => {
        this.users = users;
        this.loading = false;
      },
      error: () => {
        this.error = 'Грешка при зареждане на потребителите.';
        this.loading = false;
      },
    });
  }

  isAdmin(user: UserProfile): boolean {
    return (user.roles ?? []).includes('Admin');
  }

  toggleAdmin(user: UserProfile): void {
    const newValue = !this.isAdmin(user);

    this.adminUsersService.setAdmin(user.id, newValue).subscribe({
      next: () => {
        if (newValue) {
          user.roles = [...(user.roles ?? []), 'Admin'];
        } else {
          user.roles = (user.roles ?? []).filter((r) => r !== 'Admin');
        }
      },
      error: () => {
        this.error = 'Грешка при промяна на ролите.';
      },
    });
  }
}