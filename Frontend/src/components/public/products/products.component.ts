import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { TranslateModule } from '@ngx-translate/core';

import { Product } from '../../../models/product/product-dto';
import { ProductFilterDto } from '../../../models/product/product-filter-dto';
import { ProductService } from '../../../services/product-service';
import { RecommendationService } from '../../../services/recommendation-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ProductCardComponent, TranslateModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  loading = false;

  // ВАЖНО: държим ключ за превод, не директен текст
  errorKey: string | null = null;

  search = '';
  filter: ProductFilterDto = {};

  brands: string[] = [];
  sizes: string[] = [];
  colors: string[] = [];

  constructor(
    private productService: ProductService,
    private recommendationService: RecommendationService
  ) {}

  ngOnInit(): void {
    this.loadProducts();
    this.loadFilterOptions();
  }

  loadFilterOptions(): void {
    this.productService.getProducts().subscribe({
      next: (products) => {
        this.brands = Array.from(new Set(products.map(p => p.brand).filter(Boolean))).sort();

        this.sizes = Array.from(
          new Set(
            products.flatMap(p => (p.variants ?? []).map(v => v.size).filter(Boolean))
          )
        ).sort();

        this.colors = Array.from(
          new Set(
            products.flatMap(p => (p.variants ?? []).map(v => v.colorName).filter(Boolean))
          )
        ).sort();
      },
      error: (err) => {
        console.error(err);
        // 1 общ error message за страницата
        this.errorKey = 'PRODUCTS.ERROR_FILTERS_LOAD';
      }
    });
  }

  loadProducts(): void {
    this.loading = true;
    this.errorKey = null;

    this.productService.getProducts().subscribe({
      next: (products) => {
        this.products = products ?? [];
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorKey = 'PRODUCTS.ERROR_PRODUCTS_LOAD';
        this.loading = false;
      },
    });
  }

  // Search tracking (ако го ползваш)
  onSearchChange(term: string): void {
    this.search = term;
    const value = term.trim();
    if (!value) return;

    this.recommendationService.trackInteraction({
      type: 'Search',
      payload: value,
    });
  }

  clearFilters(): void {
    this.filter = {};
    this.search = '';
    this.applyFilter();
  }

  applyFilter(): void {
    this.loading = true;
    this.errorKey = null;

    // keyword от search
    this.filter.keyword = this.search?.trim() || undefined;

    this.productService.filterProducts(this.filter).subscribe({
      next: (products) => {
        this.products = products ?? [];
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.errorKey = 'PRODUCTS.ERROR_FILTER_PRODUCTS';
        this.loading = false;
      }
    });
  }

  get filteredProducts(): Product[] {
    return this.products;
  }
}
