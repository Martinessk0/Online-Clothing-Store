export interface AuthResponseModel {
  token: string;
  expiresAtUtc?: string;
  requiresTwoFactor?: boolean;
}
