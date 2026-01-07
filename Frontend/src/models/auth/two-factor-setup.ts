export interface TwoFactorSetupResponse {
  isTwoFactorEnabled: boolean;
  sharedKey: string;
  authenticatorUri: string;
}
