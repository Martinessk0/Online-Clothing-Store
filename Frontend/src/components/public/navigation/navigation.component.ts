import { Component, inject, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

import { AuthService } from '../../../services/auth-service';
import { ThemeService } from '../../../services/theme-service';
import { CartService } from '../../../services/cart-service';
import { LanguageService } from '../../../services/language.service';

import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [CommonModule, RouterModule, TranslateModule],
  templateUrl: './navigation.component.html'
})
export class NavigationComponent {
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly themeService = inject(ThemeService);
  private readonly cartService = inject(CartService);
  private readonly language = inject(LanguageService);

  isMobileMenuOpen = false;
  isProfileMenuOpen = false;

  // Theme
  isDark = computed(() => this.themeService.theme() === 'dark');

  // ===== LANGUAGE =====
  currentLang(): 'bg' | 'en' {
    return this.language.currentLang();
  }

  switchLang(lang: 'bg' | 'en'): void {
    this.language.setLang(lang); // 👈 ВАЖНО: setLang, не setLanguage
  }

  // ===== AUTH =====
  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  get isAdmin(): boolean {
    return this.authService.isAdmin();
  }

  // ===== CART =====
  get cartQuantity(): number {
    return this.cartService.cart.totalQuantity;
  }

  // ===== UI =====
  toggleMobileMenu(): void {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
    if (this.isMobileMenuOpen) {
      this.isProfileMenuOpen = false;
    }
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
