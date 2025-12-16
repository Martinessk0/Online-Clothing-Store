import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryDto } from '../../../models/category/category-dto';
import { ProductCreateDto } from '../../../models/product/product-create-dto';
import { Product } from '../../../models/product/product-dto';
import { AdminProductsService } from '../../../services/admin-product-service';
import { CategoryService } from '../../../services/category-service';

@Component({
  selector: 'app-admin-product',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './admin-product.component.html',
  styleUrl: './admin-product.component.scss'
})
export class AdminProductComponent implements OnInit {
  private readonly fb = inject(FormBuilder);

  products: Product[] = [];
  categories: CategoryDto[] = [];

  loading = false;
  error: string | null = null;

  search = '';

  isModalOpen = false;
  mode: 'create' | 'edit' = 'create';
  selectedProduct: Product | null = null;

  form = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(2)]],
    description: [''],
    price: [0, [Validators.required, Validators.min(0)]],
    brand: [''],
    size: [''],
    color: [''],
    stock: [0, [Validators.required, Validators.min(0)]],
    categoryId: [null as number | null, Validators.required],
  });

  constructor(
    private adminProductsService: AdminProductsService,
    private adminCategoriesService: CategoryService
  ) { }

  ngOnInit(): void {
    this.loadProducts();
    this.loadCategories();
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

  getCategoryName(categoryId: number): string {
    const cat = this.categories.find((c) => c.id === categoryId);
    return cat ? cat.name : `ID: ${categoryId}`;
  }

  loadProducts(): void {
    this.loading = true;
    this.error = null;

    this.adminProductsService.getProducts().subscribe({
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

  loadCategories(): void {
    this.adminCategoriesService.getAll().subscribe({
      next: (categories) => (this.categories = categories),
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при зареждане на категориите.';
      },
    });
  }

  openCreate(): void {
    this.mode = 'create';
    this.selectedProduct = null;
    this.isModalOpen = true;

    this.form.reset({
      name: '',
      description: '',
      price: 0,
      brand: '',
      size: '',
      color: '',
      stock: 0,
      categoryId: null,
    });
  }

  openEdit(product: Product): void {
    this.mode = 'edit';
    this.selectedProduct = product;
    this.isModalOpen = true;

    this.form.patchValue({
      name: product.name,
      description: product.description,
      price: product.price,
      brand: product.brand,
      size: product.size,
      color: product.color,
      stock: product.stock,
      categoryId: product.categoryId,
    });
  }

  closeModal(): void {
    this.isModalOpen = false;
    this.selectedProduct = null;
  }

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const value = this.form.value;

    const dto = {
      name: value.name!,
      description: value.description || '',
      price: value.price!,
      brand: value.brand || '',
      size: value.size || '',
      color: value.color || '',
      stock: value.stock!,
      categoryId: value.categoryId!,
    };

    if (this.mode === 'create') {
      this.adminProductsService.createProduct(dto).subscribe({
        next: () => {
          this.closeModal();
          this.loadProducts();
        },
        error: (err) => {
          console.error(err);
          this.error = 'Грешка при създаване на продукта.';
        },
      });
    } else if (this.mode === 'edit' && this.selectedProduct) {
      this.adminProductsService.updateProduct(this.selectedProduct.id, dto).subscribe({
        next: () => {
          this.closeModal();
          this.loadProducts();
        },
        error: (err) => {
          console.error(err);
          this.error = 'Грешка при редакция на продукта.';
        },
      });
    }
  }

  confirmDelete(product: Product): void {
    const confirmed = confirm(
      `Сигурни ли сте, че искате да изтриете продукта "${product.name}"?`
    );
    if (!confirmed) return;

    this.adminProductsService.deleteProduct(product.id).subscribe({
      next: () => this.loadProducts(),
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при изтриване на продукта.';
      },
    });
  }
}