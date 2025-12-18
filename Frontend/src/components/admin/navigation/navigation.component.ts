import { CommonModule } from '@angular/common';
import { Component, computed, inject } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { ThemeService } from '../../../services/theme-service';

type AdminLink = { label: string; path: string; exact?: boolean };

@Component({
  selector: 'app-navigation',
  imports: [CommonModule, RouterModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {
   private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly themeService = inject(ThemeService);

  isMobileMenuOpen = false;

  readonly isDarkMode = computed(() => this.themeService.theme() === 'dark');

  readonly adminLinks: AdminLink[] = [
    { label: 'Табло', path: '/admin', exact: true },
    { label: 'Продукти', path: '/admin/products' },
    { label: 'Категории', path: '/admin/categories' },
    { label: 'Поръчки', path: '/admin/orders' },
    { label: 'Потребители', path: '/admin/users' },
  ];

  get isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  toggleMobileMenu(): void {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
  }

  toggleTheme(): void {
    this.themeService.toggleTheme();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
    this.isMobileMenuOpen = false;
  }

  closeMobileMenu(): void {
    this.isMobileMenuOpen = false;
  }
}
