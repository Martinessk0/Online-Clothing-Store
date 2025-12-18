import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { RecommendationsCarouselComponent } from '../recommendations-carousel/recommendations-carousel.component';

@Component({
  selector: 'app-home-page',
  imports: [CommonModule, RouterModule,RecommendationsCarouselComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {
}