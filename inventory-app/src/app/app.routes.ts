import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { ContactComponent } from './components/contact/contact.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { OwnerDashboardComponent } from './components/owner-dashboard/owner-dashboard.component';
import { OwnerProductsComponent } from './components/owner-products/owner-products.component';
import { CustomerProductsComponent } from './components/customer-products/customer-products.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { OrdersComponent } from './components/orders/orders.component';
import { OrderStatusComponent } from './components/order-status/order-status.component';

export const routes: Routes = [
    {path:'',component:HomeComponent},
    {path:'products',component:ProductsComponent},
    {path:'contact',component:ContactComponent},
    {path:'login',component:LoginComponent},
    {path:'signup',component:SignupComponent},
    {path:'owner',component:OwnerDashboardComponent},
    {path:'owner-products',component:OwnerProductsComponent},
    {path:'catalog',component:CustomerProductsComponent},
    {path:'product/:id',component:ProductDetailComponent},
    {path:'cart',component:CartComponent},
    {path:'checkout',component:CheckoutComponent},
    {path:'orders',component:OrdersComponent},
    {path:'order-status/:id',component:OrderStatusComponent}
];
