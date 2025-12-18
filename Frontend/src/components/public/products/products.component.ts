import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { FormsModule } from '@angular/forms';
import { ProductFilterDto } from '../../../models/product/product-filter-dto';
import { RecommendationService } from '../../../services/recommendation-service';

@Component({
  selector: 'app-products',
  imports: [CommonModule, FormsModule, ProductCardComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  loading = false;
  error: string | null = null;
  search = '';

  filter: ProductFilterDto = {};
  brands: string[] = [];
  sizes: string[] = [];
  colors: string[] = [];

  constructor(private productService: ProductService) {}
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
      this.brands = Array.from(new Set(products.map(p => p.brand))).sort();
      this.sizes = Array.from(
        new Set(products.flatMap(p => p.variants.map(v => v.size)))
      ).sort();
      this.colors = Array.from(
        new Set(products.flatMap(p => p.variants.map(v => v.colorName)))
      ).sort();
    },
    error: (err) => {
      console.error(err);
      this.error = 'Грешка при зареждане на филтрите.';
    }
  });
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
  //Kato dobavim search
  onSearchChange(term: string): void {
    this.search = term;
    const value = term.trim();
    if (!value) {
      return;
    }

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
  this.error = null;

  // Add the search keyword to the filter
  this.filter.keyword = this.search?.trim() || undefined;

  this.productService.filterProducts(this.filter).subscribe({
    next: (products) => {
      this.products = products;
      this.loading = false;
    },
    error: (err) => {
      console.error(err);
      this.error = 'Грешка при филтриране на продуктите.';
      this.loading = false;
    }
  });
}
get filteredProducts(): Product[] {
    return this.products;
  }
}
