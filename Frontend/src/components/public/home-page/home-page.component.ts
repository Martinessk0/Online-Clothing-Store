import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Product } from '../../../models/product/product-dto';
import { RecommendationService } from '../../../services/recommendation-service';
import { ProductCardComponent } from '../../shared/product-card/product-card.component';

@Component({
  selector: 'app-home-page',
  imports: [CommonModule, RouterModule,ProductCardComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit {
  recommended: Product[] = [];
  loading = false;

  constructor(private recommendationService: RecommendationService) {}

  ngOnInit(): void {
    this.loading = true;
    this.recommendationService.getRecommended()
      .subscribe({
        next: (products) => {
          this.recommended = products;
          this.loading = false;
        },
        error: () => {
          this.loading = false;
        }
      });
  }
}