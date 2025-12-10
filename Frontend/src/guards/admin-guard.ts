import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth-service';
import Swal from 'sweetalert2'

export const adminGuard: CanActivateFn = async (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  if (authService.isLoggedIn() && authService.isAdmin()) {
    return true;
  }
 
    await Swal.fire({
    icon: 'error',
    title: 'Access Denied',
    text: "You don't have access to this page.",
    confirmButtonText: 'OK'
  });

  return router.createUrlTree(['/']);
};
