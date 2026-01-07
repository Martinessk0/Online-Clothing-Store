import { Component, inject, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../../services/auth-service';
import { ThemeService } from '../../../services/theme-service';
import { CartService } from '../../../services/cart-service';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './navigation.component.html'
})
export class NavigationComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly themeService = inject(ThemeService);
  private readonly cartService = inject(CartService);

  isMobileMenuOpen = false;
  isProfileMenuOpen = false;

  isDark = computed(() => this.themeService.theme() === 'dark');

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  get isAdmin(): boolean {
    console.log('this.authService.isAdmin()',this.authService.isAdmin());
    return this.authService.isAdmin();
  }

  get cartQuantity(): number {
    return this.cartService.cart.totalQuantity;
  }

  toggleMobileMenu(): void {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
    if (this.isMobileMenuOpen) this.isProfileMenuOpen = false;
  }

  toggleTheme(): void {
    this.themeService.toggleTheme();
  }

  logout(): void {
    this.authService.logout();
    this.cartService.reloadForCurrentUser(false);
    this.router.navigate(['/']);
    this.isMobileMenuOpen = false;
    this.isProfileMenuOpen = false;
  }

  closeMenus(): void {
    this.isMobileMenuOpen = false;
    this.isProfileMenuOpen = false;
  }
}