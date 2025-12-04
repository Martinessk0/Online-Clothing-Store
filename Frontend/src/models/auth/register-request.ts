export interface RegisterRequest {
  email: string;
  password: string;
  confirmPassword: string;

  firstName: string;
  lastName: string;

  phoneNumber?: string | null;
  city?: string | null;
  address?: string | null;
}
