import { HttpClient } from '@angular/common/http';
import { TranslateLoader } from '@ngx-translate/core';
import { Observable } from 'rxjs';

export class CustomTranslateLoader implements TranslateLoader {
  constructor(private http: HttpClient) {}

  getTranslation(lang: string): Observable<any> {
    // зарежда: /assets/i18n/bg.json и /assets/i18n/en.json
    return this.http.get(`/assets/i18n/${lang}.json`);
  }
}
