import { Injectable, signal } from '@angular/core';

type Theme = 'light' | 'dark';

@Injectable({ providedIn: 'root' })
export class ThemeService {
  private readonly storageKey = 'theme';
  theme = signal<Theme>('light');

  constructor() {
    const saved = localStorage.getItem(this.storageKey) as Theme | null;
    const initial: Theme = saved === 'dark' || saved === 'light' ? saved : 'light';
    this.applyTheme(initial);
  }

  toggleTheme(): void {
    const next: Theme = this.theme() === 'dark' ? 'light' : 'dark';
    this.applyTheme(next);
  }

  private applyTheme(theme: Theme): void {
    this.theme.set(theme);
    localStorage.setItem(this.storageKey, theme);

    const root = document.documentElement;
    root.classList.toggle('dark', theme === 'dark');
  }
}
