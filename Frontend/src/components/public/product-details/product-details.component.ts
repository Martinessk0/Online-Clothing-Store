import { CommonModule } from '@angular/common';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { CartService } from '../../../services/cart-service';
import { ProductVariant } from '../../../models/product/product-variant';
import { RecommendationService } from '../../../services/recommendation-service';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss',
})
export class ProductDetailsComponent implements OnInit, OnDestroy {
  product: Product | null = null;
  loading = false;
  error: string | null = null;

  selectedImageUrl: string | null = null;
  selectedVariant: ProductVariant | null = null;

  // кога е отворен детайлът
  private enterTimestamp = 0;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService,
    private recommendationService: RecommendationService
  ) {}

  ngOnInit(): void {
    this.enterTimestamp = Date.now(); // започваме да мерим време

    const idParam = this.route.snapshot.paramMap.get('id');
    const id = idParam ? Number(idParam) : NaN;

    if (!id) {
      this.error = 'Невалиден продукт.';
      return;
    }

    this.loadProduct(id);
  }

  ngOnDestroy(): void {
    if (!this.product) return;

    const diffMs = Date.now() - this.enterTimestamp;
    const seconds = Math.max(1, Math.round(diffMs / 1000));

    this.recommendationService.trackInteraction({
      type: 'ProductView',
      productId: this.product.id,
      categoryId: this.product.categoryId,
      durationSeconds: seconds,
    });
  }

  private loadProduct(id: number): void {
    this.loading = true;
    this.error = null;

    this.productService.getProduct(id).subscribe({
      next: (p) => {
        this.product = p;
        this.loading = false;

        const mainImage = p.images?.find((i) => i.isMain);
        this.selectedImageUrl = mainImage?.url || p.images?.[0]?.url || null;

        const mainVariant = p.variants?.[0] ?? null;
        this.selectedVariant = mainVariant;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Грешка при зареждане на продукта.';
        this.loading = false;
      },
    });
  }

  selectImage(url: string): void {
    this.selectedImageUrl = url;
  }

  selectVariant(variant: ProductVariant): void {
    this.selectedVariant = variant;
  }

  addToCart(): void {
    if (!this.product) return;

    this.cartService.addProduct(
      this.product,
      1,
      this.selectedVariant ?? undefined
    );
    this.recommendationService.trackInteraction({
      type: 'AddToCart',
      productId: this.product.id,
      categoryId: this.product.categoryId,
    });
  }

  getTotalStock(): number {
    if (!this.product?.variants?.length) return 0;
    return this.product.variants.reduce((sum, v) => sum + v.stock, 0);
  }
}
