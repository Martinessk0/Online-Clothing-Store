import { Routes } from '@angular/router';
import { adminGuard } from '../guards/admin-guard';
import { authGuard } from '../guards/auth-guard';
import { LayoutComponent } from '../components/admin/layout/layout.component';
import { HomePageComponent } from '../components/admin/home-page/home-page.component';
import { AdminUsersComponent } from '../components/admin/admin-users/admin-users.component';


export const adminRoutes: Routes = [
  {
    path: 'admin',
    component: LayoutComponent,
    canActivate: [authGuard,adminGuard], 
    children: [
      {
        path: '',
        redirectTo: 'home-page',
        pathMatch: 'full',
      },
      {
        path: 'home-page',
        component: HomePageComponent,
      },
      {
        path: 'users',
        component: AdminUsersComponent,
      },
    ],
  },
];
