import { Routes } from '@angular/router';
import { LayoutComponent } from '../components/public/layout/layout.component';
import { RegisterComponent } from '../components/public/register/register.component';
import { LoginComponent } from '../components/public/login/login.component';
import { HomePageComponent } from '../components/public/home-page/home-page.component';
import { ProfileComponent } from '../components/public/profile/profile.component';
import { authGuard } from '../guards/auth-guard';


export const publicRoutes: Routes = [
  {
    path: '',
    component: LayoutComponent,
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
        path: 'register',
        component: RegisterComponent,
      },
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [authGuard], 
      },
    ],
  },
];
