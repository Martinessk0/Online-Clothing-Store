import { Injectable, signal } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

type Lang = 'bg' | 'en';

@Injectable({ providedIn: 'root' })
export class LanguageService {
  private readonly STORAGE_KEY = 'app_lang';

  // държим езика като signal
  private readonly _lang = signal<Lang>('bg');

  constructor(private translate: TranslateService) {
    // по желание: list с позволени езици
    this.translate.addLangs(['bg', 'en']);
    this.translate.setDefaultLang('bg');
  }

  /** Викаш го веднъж при старт (AppComponent) */
  init(defaultLang: Lang = 'bg'): void {
    const saved = localStorage.getItem(this.STORAGE_KEY) as Lang | null;

    const lang: Lang =
      saved === 'bg' || saved === 'en'
        ? saved
        : defaultLang;

    this.apply(lang);
  }

  /** Викаш го при клик BG/EN */
  setLang(lang: Lang): void {
    this.apply(lang);
    localStorage.setItem(this.STORAGE_KEY, lang);
  }

  /** За темплейта – за да знаеш кой е активен */
  currentLang(): Lang {
    return this._lang();
  }

  private apply(lang: Lang): void {
    this._lang.set(lang);
    this.translate.use(lang);
  }
}
