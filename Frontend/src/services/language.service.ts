import { Injectable, signal } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private readonly _currentLang = signal<'bg' | 'en'>('bg');

  constructor(private translate: TranslateService) {
    this.translate.addLangs(['bg', 'en']);
    this.translate.setDefaultLang('bg');

    const savedLang = (localStorage.getItem('lang') as 'bg' | 'en') ?? 'bg';
    this.setLanguage(savedLang);
  }

  // IMPORTANT:
  // връща string, НЕ signal
  currentLang(): 'bg' | 'en' {
    return this._currentLang();
  }

  setLanguage(lang: 'bg' | 'en'): void {
    this._currentLang.set(lang);
    this.translate.use(lang);
    localStorage.setItem('lang', lang);
  }
}
