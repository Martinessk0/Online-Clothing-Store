import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { ContactRequest } from '../models/contact/contact-request';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private readonly baseUrl = `${environment.apiUrl}/Contact`;

  constructor(private http: HttpClient) {}

  sendContact(payload: ContactRequest): Observable<void> {
    return this.http.post<void>(this.baseUrl, payload);
  }
}
