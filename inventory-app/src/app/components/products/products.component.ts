import { Component } from '@angular/core';
import { CustomerProductsComponent } from '../customer-products/customer-products.component';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CustomerProductsComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {

}
