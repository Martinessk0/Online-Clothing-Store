import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../environments/environment";
import { UserProfile } from "../models/auth/user-profile";

@Injectable({
  providedIn: 'root',
})
export class AdminUsersService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsers(): Observable<UserProfile[]> {
    return this.http.get<UserProfile[]>(`${this.apiUrl}/admin/users`);
  }

  setAdmin(userId: string, isAdmin: boolean): Observable<UserProfile> {
    return this.http.post<UserProfile>(`${this.apiUrl}/admin/users/${userId}/roles`, {
      isAdmin,
    });
  }
}
