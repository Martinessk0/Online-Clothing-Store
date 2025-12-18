import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { FormsModule } from '@angular/forms';
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

  constructor(
    private productService: ProductService,
    private recommendationService: RecommendationService
  ) {}

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
