import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output, OnChanges, SimpleChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReviewService } from '../../../services/review-service';
import { Review } from '../../../models/review/review-dto';

@Component({
  selector: 'app-review-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './review-form.component.html',
})
export class ReviewFormComponent implements OnChanges {
  @Input() productId!: number;
  @Input() review?: Review;

  @Output() reviewSubmitted = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  rating = 5;
  comment = '';
  submitting = false;
  error: string | null = null;

  constructor(private reviewService: ReviewService) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['review'] && this.review) {
      this.rating = this.review.rating;
      this.comment = this.review.comment ?? '';
    }
  }

  submit(): void {
    if (this.rating < 1 || this.rating > 5) return;

    this.submitting = true;
    this.error = null;

    const request$ = this.review
      ? this.reviewService.update(this.review.id, {
          rating: this.rating,
          comment: this.comment,
        })
      : this.reviewService.create({
          productId: this.productId,
          rating: this.rating,
          comment: this.comment,
        });

    request$.subscribe({
      next: () => {
        this.reset();
        this.reviewSubmitted.emit();
        this.submitting = false;
      },
      error: () => {
        this.error = this.review
          ? 'Грешка при редакция.'
          : 'Не можеш да добавиш отзив (вероятно вече имаш такъв).';
        this.submitting = false;
      },
    });
  }

  reset(): void {
    this.rating = 5;
    this.comment = '';
    this.review = undefined;
  }

  cancelEdit(): void {
    this.reset();
    this.cancelled.emit();
  }
}
