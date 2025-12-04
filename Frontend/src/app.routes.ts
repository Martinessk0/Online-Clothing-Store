import { Routes } from '@angular/router';
import { publicRoutes } from './routes/public-routing';

export const routes: Routes = [
    ...publicRoutes,
    // ...adminRoutes,
    { path: '**', redirectTo: '' }
];
