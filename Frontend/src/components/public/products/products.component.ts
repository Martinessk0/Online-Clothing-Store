import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-products',
  imports: [CommonModule,ProductCardComponent,],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  loading = false;
  error: string | null = null;
  search = '';

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.loading = true;
    this.error = null;

    this.productService.getProducts().subscribe({
      next: (products) => {
        this.products = products;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при зареждане на продуктите.';
        this.loading = false;
      },
    });
  }

  get filteredProducts(): Product[] {
    const term = this.search?.trim().toLowerCase();
    if (!term) return this.products;

    return this.products.filter((p) => {
      const name = p.name.toLowerCase();
      const desc = (p.description || '').toLowerCase();
      const brand = (p.brand || '').toLowerCase();
      return (
        name.includes(term) ||
        desc.includes(term) ||
        brand.includes(term)
      );
    });
  }
}