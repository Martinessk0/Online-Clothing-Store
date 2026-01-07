export interface LoginRequest {
  email: string;
  password: string;
  twoFactorCode?: string;
  recoveryCode?: string;
}
