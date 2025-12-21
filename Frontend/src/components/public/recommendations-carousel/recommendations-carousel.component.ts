import {
  Component,
  ElementRef,
  Input,
  OnChanges,
  OnDestroy,
  OnInit,
  SimpleChanges,
  ViewChild
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Subscription, timer } from 'rxjs';

import { TranslateModule } from '@ngx-translate/core';

import { Product } from '../../../models/product/product-dto';
import { ProductService } from '../../../services/product-service';
import { RecommendationService } from '../../../services/recommendation-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';

type CarouselSource = 'recommended' | 'all';

@Component({
  selector: 'app-recommendations-carousel',
  standalone: true,
  imports: [CommonModule, RouterModule, TranslateModule, ProductCardComponent],
  templateUrl: './recommendations-carousel.component.html',
  styleUrl: './recommendations-carousel.component.scss'
})
export class RecommendationsCarouselComponent implements OnInit, OnChanges, OnDestroy {
  /**
   * IMPORTANT:
   * title трябва да е translation key, напр. 'HOME.RECOMMENDED_TITLE'
   * (и в HTML: {{ title | translate }})
   */
  @Input() title: string = 'HOME.RECOMMENDED_TITLE';

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
  ) {}

  ngOnInit(): void {
    this.load();
  }

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

    // малък delay, за да е сигурно че trackRef е наличен след render
    setTimeout(() => {
      const el = this.trackRef?.nativeElement;
      if (!el) return;

      this.autoSub.add(timer(this.rotateMs, this.rotateMs).subscribe(() => this.next()));
    });
  }

  load(): void {
    this.loading = true;

    // ако искаш по-късно да поддържаш 'all', тук просто сменяш req$
    const req$ = this.recommendationService.getRecommended();

    this.sub.add(
      req$.subscribe({
        next: (items) => {
          this.products = items ?? [];
          this.loading = false;
          this.restartAutoRotate();
        },
        error: () => {
          this.loading = false;
          this.products = [];
        }
      })
    );
  }

  next(): void {
    this.scrollByPage(1);
  }

  prev(): void {
    this.scrollByPage(-1);
  }

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
