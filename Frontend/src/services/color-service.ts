import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { ColorDto } from '../models/color/color-dto';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  private readonly baseUrl = `${environment.apiUrl}/Color`;

  constructor(private http: HttpClient) {}

  getColors(): Observable<ColorDto[]> {
    return this.http.get<ColorDto[]>(this.baseUrl);
  }
}
