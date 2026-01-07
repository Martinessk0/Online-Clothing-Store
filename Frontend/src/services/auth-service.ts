import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, map } from "rxjs";
import { AuthResponseModel } from "../models/auth/auth-response";
import { LoginRequest } from "../models/auth/login-request";
import { RegisterRequest } from "../models/auth/register-request";
import { environment } from "../environments/environment";
import { jwtDecode } from 'jwt-decode';
import { UserProfile } from "../models/auth/user-profile";
import { TwoFactorSetupResponse } from "../models/auth/two-factor-setup";
import { TwoFactorEnableResponse } from "../models/auth/two-factor-enable";
import { ResetPasswordRequest } from "../models/auth/reset-password-request";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  // пример: 'https://localhost:7155/api'
  private apiUrl: string = environment.apiUrl;
  private tokenKey = 'token';

  constructor(private http: HttpClient) { }

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

  getProfile(): Observable<UserProfile> {
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

    try {
      const decoded: any = jwtDecode(token);

      const rolesClaim =
        decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ??
        decoded.role ??
        decoded.roles;

      console.log('rolesClaim:', rolesClaim, 'type:', typeof rolesClaim);

      if (Array.isArray(rolesClaim)) {
        return rolesClaim.includes('Admin');
      }

      if (typeof rolesClaim === 'string') {
        return rolesClaim.split(',').includes('Admin');
      }

      return false;
    } catch {
      return false;
    }
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

  public getUserId(): string | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const decoded: any = jwtDecode(token);

      const nameIdClaim =
        decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] ??
        decoded.nameid ??
        null;

      return nameIdClaim ?? null;
    } catch {
      return null;
    }
  }

  confirmEmail(userId: string, token: string) {
    return this.http.get<{ message: string }>(
      `${this.apiUrl}/auth/confirm-email`,
      {
        params: { userId, token }
      }
    );
  }

  getTwoFactorSetup(): Observable<TwoFactorSetupResponse> {
    return this.http.get<TwoFactorSetupResponse>(`${this.apiUrl}/auth/2fa/setup`);
  }

  enableTwoFactor(code: string): Observable<TwoFactorEnableResponse> {
    return this.http.post<TwoFactorEnableResponse>(`${this.apiUrl}/auth/2fa/enable`, { code });
  }

  disableTwoFactor(): Observable<{ message: string }> {
    return this.http.post<{ message: string }>(`${this.apiUrl}/auth/2fa/disable`, {});
  }

  requestPasswordReset(email: string) {
    return this.http.post<{ message: string }>(
      `${this.apiUrl}/auth/forgot-password`,
      { email }
    );
  }

  resetPassword(payload: ResetPasswordRequest) {
    return this.http.post<{ message: string }>(
      `${this.apiUrl}/auth/reset-password`,
      payload
    );
  }

}