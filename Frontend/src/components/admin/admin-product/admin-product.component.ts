import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CategoryDto } from '../../../models/category/category-dto';
import { ProductCreateDto } from '../../../models/product/product-create-dto';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { CategoryService } from '../../../services/category-service';
import { ColorDto } from '../../../models/color/color-dto';
import { ColorService } from '../../../services/color-service';
import { ProductImageCreateDto } from '../../../models/product/product-image-create-dto';
import { ProductImageUploadService } from '../../../services/product-image-upload-service';

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
  colors: ColorDto[] = [];
  images: ProductImageCreateDto[] = [];
  uploadingImage = false;

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
    categoryId: [null as number | null, Validators.required],
    variants: this.fb.array([this.createVariantGroup()]),
  });

  constructor(
    private productService: ProductService,
    private adminCategoriesService: CategoryService,
    private colorService: ColorService,
    private productImageUploadService: ProductImageUploadService
  ) { }

  ngOnInit(): void {
    this.loadProducts();
    this.loadCategories();
    this.loadColors();
  }

  // ---------- getters / helpers ----------

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

  get variants(): FormArray {
    return this.form.get('variants') as FormArray;
  }

  private createVariantGroup() {
    return this.fb.group({
      colorId: [null as number | null, Validators.required],
      size: ['', [Validators.required]],
      stock: [0, [Validators.required, Validators.min(0)]],
    });
  }

  getVariantSizes(product: Product): string {
    const sizes = Array.from(
      new Set(
        (product.variants || [])
          .map((v) => v.size)
          .filter((s) => !!s)
      )
    );
    return sizes.length ? sizes.join(', ') : '—';
  }

  getVariantColors(product: Product): string {
    const colors = Array.from(
      new Set(
        (product.variants || [])
          .map((v) => v.colorName)
          .filter((c) => !!c)
      )
    );
    return colors.length ? colors.join(', ') : '—';
  }

  getTotalStock(product: Product): number {
    return (product.variants || []).reduce((sum, v) => sum + (v.stock ?? 0), 0);
  }

  // ---------- data loading ----------

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

  loadCategories(): void {
    this.adminCategoriesService.getAll().subscribe({
      next: (categories) => (this.categories = categories),
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при зареждане на категориите.';
      },
    });
  }

  loadColors(): void {
    this.colorService.getColors().subscribe({
      next: (colors: any) => (this.colors = colors),
      error: (err: any) => {
        console.error(err);
        this.error = 'Грешка при зареждане на цветовете.';
      },
    });
  }

  // ---------- variants UI ----------

  addVariant(): void {
    this.variants.push(this.createVariantGroup());
  }

  removeVariant(index: number): void {
    if (this.variants.length === 1) {
      // поне 1 ред да остане
      this.variants.at(0).reset({
        colorId: null,
        size: '',
        stock: 0,
      });
      return;
    }

    this.variants.removeAt(index);
  }

  // ---------- modal ----------

  openCreate(): void {
    this.mode = 'create';
    this.selectedProduct = null;
    this.isModalOpen = true;

    this.form.reset({
      name: '',
      description: '',
      price: 0,
      brand: '',
      categoryId: null,
    });

    this.variants.clear();
    this.variants.push(this.createVariantGroup());

    this.images = [];
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
      categoryId: product.categoryId,
    });

    this.variants.clear();

    if (product.variants && product.variants.length) {
      product.variants.forEach((v) => {
        this.variants.push(
          this.fb.group({
            colorId: [v.colorId, Validators.required],
            size: [v.size, Validators.required],
            stock: [v.stock, [Validators.required, Validators.min(0)]],
          })
        );
      });
    } else {
      this.variants.push(this.createVariantGroup());
    }

    this.images = (product.images || []).map((img) => ({
      url: img.url,
      publicId: '',
      isMain: img.isMain,
    }));
  }

  closeModal(): void {
    this.isModalOpen = false;
    this.selectedProduct = null;
  }

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (!input.files || !input.files.length) return;

    const file = input.files[0];
    this.uploadingImage = true;

    this.productImageUploadService.uploadProductImage(file).subscribe({
      next: (res) => {
        this.uploadingImage = false;

        this.images.push({
          url: res.url,
          publicId: res.publicId,
          isMain: this.images.length === 0,
        });
      },
      error: (err) => {
        console.error(err);
        this.uploadingImage = false;
        this.error = 'Грешка при качване на снимката.';
      },
    });

    input.value = '';
  }

  setAsMain(index: number): void {
    this.images = this.images.map((img, i) => ({
      ...img,
      isMain: i === index,
    }));
  }

  removeImage(index: number): void {
    this.images.splice(index, 1);

    if (this.images.length > 0 && !this.images.some(i => i.isMain)) {
      this.images[0].isMain = true;
    }
  }

  // ---------- save / delete ----------

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const value = this.form.value;

    const dto: ProductCreateDto = {
      name: value.name!,
      description: value.description || '',
      price: value.price!,
      brand: value.brand || '',
      categoryId: value.categoryId!,
      variants: this.variants.controls.map((ctrl: any) => {
        const v = ctrl.value as {
          colorId: number | null;
          size: string;
          stock: number;
        };

        return {
          colorId: v.colorId!,
          size: v.size,
          stock: v.stock,
        };
      }),
      images: this.images,
    };

    if (this.mode === 'create') {
      this.productService.createProduct(dto).subscribe({
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
      this.productService.updateProduct(this.selectedProduct.id, dto).subscribe({
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

    this.productService.deleteProduct(product.id).subscribe({
      next: () => this.loadProducts(),
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при изтриване на продукта.';
      },
    });
  }
}