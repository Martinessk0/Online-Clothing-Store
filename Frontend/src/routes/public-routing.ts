import { Routes } from '@angular/router';
import { LayoutComponent } from '../components/public/layout/layout.component';
import { RegisterComponent } from '../components/public/register/register.component';
import { LoginComponent } from '../components/public/login/login.component';
import { HomePageComponent } from '../components/public/home-page/home-page.component';
import { ProfileComponent } from '../components/public/profile/profile.component';
import { authGuard } from '../guards/auth-guard';
import { ProductsComponent } from '../components/public/products/products.component';
import { ProductDetailsComponent } from '../components/public/product-details/product-details.component';
import { CartComponent } from '../components/public/cart/cart.component';
import { CheckoutComponent } from '../components/public/checkout/checkout.component';
import { MyOrdersComponent } from '../components/public/my-orders/my-orders.component';
import { OrderDetailsComponent } from '../components/public/order-details/order-details.component';
import { AboutComponent } from '../components/public/about/about.component';
import { TermsComponent } from '../components/public/terms/terms.component';
import { PrivacyComponent } from '../components/public/privacy/privacy.component';
import { ContactComponent } from '../components/public/contact/contact.component';


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
        path: 'products',
        component: ProductsComponent,
      },
      {
        path: 'products/:id',
        component: ProductDetailsComponent,
      },
      {
        path: 'cart',
        component: CartComponent,
      },
      {
        path: 'checkout',
        component: CheckoutComponent,
      },
      {
        path: 'about',
        component: AboutComponent,
      },
      { path: 'terms', component: TermsComponent },
      { path: 'privacy', component: PrivacyComponent },
      { path: 'contact', component: ContactComponent },
      {
        path: 'orders',
        component: MyOrdersComponent,
        canActivate: [authGuard],
      },
      {
        path: 'orders/:id',
        component: OrderDetailsComponent,
        canActivate: [authGuard],
      },
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [authGuard],
      },
    ],
  },
];
