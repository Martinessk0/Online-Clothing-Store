import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Product } from '../../../models/product/product-dto';
import { CartService } from '../../../services/cart-service';

@Component({
  selector: 'app-product-card',
  imports: [CommonModule, RouterLink],
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss'
})
export class ProductCardComponent {
   private readonly cartService = inject(CartService);

  @Input({ required: true }) product!: Product;

  get mainImageUrl(): string {
    if (!this.product?.images?.length) {
      return 'assets/images/placeholder-product.jpg';
    }
    const main = this.product.images.find((i) => i.isMain);
    return main?.url ?? this.product.images[0].url;
  }

  get totalStock(): number {
    if (!this.product?.variants?.length) return 0;
    return this.product.variants.reduce((sum, v) => sum + v.stock, 0);
  }

  get colors(): string {
    if (!this.product?.variants?.length) return '—';
    const names = Array.from(new Set(this.product.variants.map((v) => v.colorName)));
    return names.join(', ');
  }

  addToCart(): void {
    if (!this.product) return;

    const firstVariant = this.product.variants?.[0] ?? null;
    this.cartService.addProduct(this.product, 1, firstVariant ?? undefined);
  }
}
