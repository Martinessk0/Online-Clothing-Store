import { Routes } from '@angular/router';
import { publicRoutes } from './routes/public-routing';
import { adminRoutes } from './routes/admin-routing';

export const routes: Routes = [
    ...publicRoutes,
    ...adminRoutes,
    { path: '**', redirectTo: '' }
];
