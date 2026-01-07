export interface UserProfile {
  id: string;
  email: string;

  firstName?: string | null;
  lastName?: string | null;
  phoneNumber?: string | null;

  roles?: string[];
  createdAt?: string | null;

  city?: string | null;
  address?: string | null;

  emailConfirmed?: boolean;
}
