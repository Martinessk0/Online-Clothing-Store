import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { AuthResponseModel } from "../models/auth/auth-response";
import { LoginRequest } from "../models/auth/login-request";
import { RegisterRequest } from "../models/auth/register-request";
import { environment } from "../environments/environment";
import { jwtDecode } from 'jwt-decode';
import { UserProfile } from "../models/auth/user-profile";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  // пример: 'https://localhost:7155/api'
  private apiUrl: string = environment.apiUrl;
  private tokenKey = 'token';

  constructor(private http: HttpClient) {}

  login(data: LoginRequest): Observable<AuthResponseModel> {
    return this.http
      .post<AuthResponseModel>(`${this.apiUrl}/auth/login`, data)
      .pipe(
        map((response) => {
          if (response.token) {
            localStorage.setItem(this.tokenKey, response.token);
          }
          return response;
        })
      );
  }

  register(data: RegisterRequest): Observable<AuthResponseModel> {
    return this.http
      .post<AuthResponseModel>(`${this.apiUrl}/auth/register`, data)
      .pipe(
        map((response) => {
          if (response.token) {
            localStorage.setItem(this.tokenKey, response.token);
          }
          return response;
        })
      );
  }

  getProfile() : Observable<UserProfile> {
    return this.http.get<UserProfile>(`${this.apiUrl}/auth/profile`);
  }

  updateProfile(payload: {
    firstName?: string;
    lastName?: string;
    phoneNumber?: string;
    city?: string;
    address?: string;
  }): Observable<UserProfile> {
    return this.http.put<UserProfile>(`${this.apiUrl}/auth/profile`, payload);
  }

  public isLoggedIn(): boolean {
    const token = this.getToken();
    return token != null && !this.isTokenExpired(token);
  }

  public isAdmin(): boolean {
    const token = this.getToken();
    if (!token) return false;

    const decoded: any = jwtDecode(token);
    const roles = decoded.role ?? decoded.roles;

    if (Array.isArray(roles)) {
      return roles.includes('Admin');
    }

    if (typeof roles === 'string') {
      return roles === 'Admin';
    }

    return false;
  }

  public logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  public getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  private isTokenExpired(token: string): boolean {
    try {
      const decoded: any = jwtDecode(token);
      if (!decoded.exp) {
        this.logout();
        return true;
      }

      const expired = Date.now() >= decoded.exp * 1000;
      if (expired) {
        this.logout();
      }
      return expired;
    } catch {
      this.logout();
      return true;
    }
  }
}