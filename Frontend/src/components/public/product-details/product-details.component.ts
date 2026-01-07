import { CommonModule } from '@angular/common';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { CartService } from '../../../services/cart-service';
import { ProductVariant } from '../../../models/product/product-variant';
import { RecommendationService } from '../../../services/recommendation-service';
import { Review } from '../../../models/review/review-dto';
import { ReviewService } from '../../../services/review-service';
import { ReviewFormComponent } from '../review/review-form.component';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule, ReviewFormComponent],
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

  reviews: Review[] = [];
  editingReview?: Review;
  editRating = 5;
  editComment = '';
  canReview = false;
  showNewReviewForm = false; // only for creating a new review
   // only for editing

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService,
    private recommendationService: RecommendationService,
    private reviewService: ReviewService,
    public authService: AuthService 
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
    this.loadReviews(id);
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

   loadProduct(id: number): void {
    this.loading = true;
    this.error = null;

    this.productService.getProduct(id).subscribe({
      next: (p) => {
        this.product = p;
        this.loading = false;

          this.loadCanReview(p.id);

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

  //Reviews
  startEdit(review: Review): void {
    this.editingReview = review;
    this.editRating = review.rating;
    this.editComment = review.comment ?? '';
  }

  cancelEdit(): void {
    this.editingReview = undefined;
  }

  saveEdit(): void {
    if (!this.editingReview) return;

    this.reviewService
      .update(this.editingReview.id, {
        rating: this.editRating,
        comment: this.editComment,
      })
      .subscribe({
        next: () => {
          this.editingReview = undefined;
          this.loadReviews(this.product!.id);
        },
      });
  }

   loadReviews(productId: number): void {

    const includeHidden = this.authService.isAdmin();

    this.reviewService.getByProduct(productId, includeHidden).subscribe({
      next: (r) => {
        this.reviews = r;
        this.showNewReviewForm = false;
        this.editingReview = undefined;
      },
      error: () => (this.reviews = [])
  });
}


loadCanReview(productId: number) {
  if (!this.authService.isLoggedIn()) return;

  this.reviewService.canReview(productId).subscribe({
    next: r => this.canReview = r.canReview,
    error: () => this.canReview = false
  });
}

openReviewForm(): void {
  this.editingReview = undefined; // new review
  this.showNewReviewForm = true;
}

closeReviewForm(): void {
  this.showNewReviewForm = false;
  this.editingReview = undefined;
}

onNewReviewSubmitted() {
  this.showNewReviewForm = false;
  this.loadReviews(this.product!.id);
  this.refreshProduct(); 
}

onEditReviewSubmitted() {
  this.editingReview = undefined;
  this.loadReviews(this.product!.id);
  this.refreshProduct(); 
}



refreshProduct() {
  if (!this.product) return;
  this.productService.getProduct(this.product.id).subscribe({
    next: p => this.product = p, // now AverageRating updates in the UI
    error: err => console.error(err)
  });
}

toggleReviewVisibility(review: Review, isVisible: boolean) {
  this.reviewService.setVisibility(review.id, isVisible).subscribe({
    next: () => {
      review.isVisible = isVisible;
      this.refreshProduct();     
      this.loadReviews(this.product!.id);
    },
    error: err => console.error(err)
  });
}



}
