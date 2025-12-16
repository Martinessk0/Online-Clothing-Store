import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';

@Component({
  selector: 'app-product-details',
  imports: [CommonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit {
  product: Product | null = null;
  loading = false;
  error: string | null = null;

  selectedImageUrl: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.loadProduct(id);
  }

  loadProduct(id: number): void {
    this.loading = true;
    this.error = null;

    this.productService.getProduct(id).subscribe({
      next: (p) => {
        this.product = p;
        this.loading = false;

        const main = p.images?.find((i) => i.isMain);
        this.selectedImageUrl = main?.url || p.images?.[0]?.url || null;
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

  getTotalStock(): number {
    if (!this.product?.variants?.length) return 0;
    return this.product.variants.reduce((sum, v) => sum + v.stock, 0);
  }
}