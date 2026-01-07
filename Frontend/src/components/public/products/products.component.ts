import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';
import { FormsModule } from '@angular/forms';
import { ProductFilterDto } from '../../../models/product/product-filter-dto';
import { RecommendationService } from '../../../services/recommendation-service';
import { ActivatedRoute, Router } from '@angular/router';
import { PagedResult } from '../../../models/pagedResult/paged-result';
import { ReviewFormComponent } from '../review/review-form.component';


@Component({
  selector: 'app-products',
  imports: [CommonModule, FormsModule, ProductCardComponent, CommonModule, ReviewFormComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];
  loading = false;
  error: string | null = null;
  search = '';

  currentPage = 1;
  pageSize = 12;
  totalCount = 0;

  filter: ProductFilterDto = {};
  brands: string[] = [];
  sizes: string[] = [];
  colors: string[] = [];

  constructor(
  private productService: ProductService,
  private recommendationService: RecommendationService,
  private route: ActivatedRoute,
  private router: Router
) {}


  ngOnInit(): void {
  this.route.queryParams.subscribe(params => {
    this.search = params['keyword'] || '';

    this.filter = {
      keyword: params['keyword'] || undefined,
      brand: params['brand'] || undefined,
      size: params['size'] || undefined,
      color: params['color'] || undefined,
      minPrice: params['minPrice'] ? +params['minPrice'] : undefined,
      maxPrice: params['maxPrice'] ? +params['maxPrice'] : undefined,
      inStockOnly: params['inStockOnly'] === 'true',
      sortBy: params['sortBy'] || undefined
    };

    this.currentPage = params['page'] ? +params['page'] : 1;

    this.applyFilter(false); 
  });

  this.loadFilterOptions();
}


loadFilterOptions(): void {
  this.productService.getFilterOptions().subscribe({
    next: (options) => {
      this.brands = options.brands;
      this.sizes = options.sizes;
      this.colors = options.colors;
    },
    error: () => {
      this.error = 'Грешка при зареждане на филтрите.';
    }
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

  applyFilter(updateUrl: boolean = true): void {
  this.currentPage = updateUrl ? 1 : this.currentPage;
  this.loading = true;
  this.error = null;

  this.filter.keyword = this.search?.trim() || undefined;

  if (updateUrl) {
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: {
        ...this.filter,
        page: this.currentPage
      },
      queryParamsHandling: 'merge'
    });
  }

  this.productService
    .filterProducts(this.filter, this.currentPage, this.pageSize)
    .subscribe({
      next: (result: PagedResult<Product>) => {
        this.products = result.items;
        this.totalCount = result.totalCount;
        this.loading = false;
      },
      error: () => {
        this.error = 'Грешка при филтриране на продуктите.';
        this.loading = false;
      }
    });
}

changePage(page: number): void {
  if (page < 1 || page > this.totalPages) return;

  this.currentPage = page;
  this.router.navigate([], {
    relativeTo: this.route,
    queryParams: {
      page: this.currentPage
    },
    queryParamsHandling: 'merge'
  });
  
  this.applyFilter(false); 
}

  clearFilters(): void {
  this.filter = {};
  this.search = '';
  this.currentPage = 1;

  this.router.navigate([], {
    relativeTo: this.route,
    queryParams: {
      page: 1
    },
    queryParamsHandling: '' 
  });

  this.applyFilter(false);
}

  get totalPages(): number {
  return Math.ceil(this.totalCount / this.pageSize);
}

getPages(): number[] {
  return Array.from({ length: this.totalPages }, (_, i) => i + 1);
}

readonly pageWindowSize = 1;

get visiblePages(): number[] {
  const pages: number[] = [];

  const start = Math.max(
    2,
    this.currentPage - this.pageWindowSize
  );

  const end = Math.min(
    this.totalPages - 1,
    this.currentPage + this.pageWindowSize
  );

  for (let i = start; i <= end; i++) {
    pages.push(i);
  }

  return pages;
}

get showLeftEllipsis(): boolean {
  return this.visiblePages.length > 0 && this.visiblePages[0] > 2;
}

get showRightEllipsis(): boolean {
  if (this.visiblePages.length === 0) return false;

  const lastVisible = this.visiblePages[this.visiblePages.length - 1];
  return lastVisible < this.totalPages - 1;
}



}
