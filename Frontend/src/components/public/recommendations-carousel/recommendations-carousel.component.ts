import { AfterViewInit, Component, ElementRef, Input, OnChanges, OnDestroy, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Subscription, timer } from 'rxjs';
import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { RecommendationService } from '../../../services/recommendation-service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';

type CarouselSource = 'recommended' | 'all';

@Component({
  selector: 'app-recommendations-carousel',
  imports: [CommonModule, RouterModule, ProductCardComponent],
  templateUrl: './recommendations-carousel.component.html',
  styleUrl: './recommendations-carousel.component.scss'
})
export class RecommendationsCarouselComponent implements OnInit ,OnChanges, OnDestroy {
  @Input() title = 'Препоръчани за теб';
  @Input() source: CarouselSource = 'recommended';
  @Input() autoRotate = true;
  @Input() rotateMs = 3500;

  @ViewChild('track', { static: false }) trackRef?: ElementRef<HTMLElement>;

  products: Product[] = [];
  loading = false;

  private sub = new Subscription();
  private autoSub = new Subscription();

  constructor(
    private recommendationService: RecommendationService,
    private productService: ProductService
  ) { }

  ngOnInit(): void { this.load(); }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['autoRotate'] || changes['rotateMs']) {
      this.restartAutoRotate();
    }
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
    this.autoSub.unsubscribe();
  }

  private restartAutoRotate(): void {
    this.autoSub.unsubscribe();
    this.autoSub = new Subscription();

    if (!this.autoRotate) return;
    if (!this.products?.length) return;

    setTimeout(() => {
      const el = this.trackRef?.nativeElement;
      if (!el) return;

      this.autoSub.add(
        timer(this.rotateMs, this.rotateMs).subscribe(() => this.next())
      );
    });
  }

  load(): void {
    this.loading = true;

    const req$ = this.recommendationService.getRecommended();
    this.sub.add(req$.subscribe({
      next: (items) => {
        this.products = items ?? [];
        this.loading = false;
        this.restartAutoRotate();
      },
      error: () => {
        this.loading = false;
        this.products = [];
      }
    }));
  }

  next(): void { this.scrollByPage(1); }
  prev(): void { this.scrollByPage(-1); }

  private scrollByPage(direction: 1 | -1): void {
    const el = this.trackRef?.nativeElement;
    if (!el) return;

    const step = el.clientWidth;
    const atEnd = Math.ceil(el.scrollLeft + el.clientWidth) >= el.scrollWidth - 1;

    if (direction === 1 && atEnd) {
      el.scrollTo({ left: 0, behavior: 'smooth' });
      return;
    }

    el.scrollBy({ left: direction * step, behavior: 'smooth' });
  }
}