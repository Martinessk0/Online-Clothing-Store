import { Routes } from '@angular/router';


export const publicRoutes: Routes = [
  {
    path: '',
    // component: LayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'home-page',
        pathMatch: 'full',
      },
      {
        path: 'home-page',
        // component: HomeComponent,
      },
      {
        path: 'register',
        // component: RegisterComponent,
      },
      {
        path: 'login',
        // component: LoginComponent,
      },
      {
        path: 'profile',
        // component: ProfileComponent,
        // canActivate: [loginGuard], 
      },
    ],
  },
];
