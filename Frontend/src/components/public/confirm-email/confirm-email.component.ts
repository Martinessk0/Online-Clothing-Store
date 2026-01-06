import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../services/auth-service';

@Component({
  selector: 'app-confirm-email',
  imports: [CommonModule],
  templateUrl: './confirm-email.component.html'
})
export class ConfirmEmailComponent implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly authService = inject(AuthService);

  status: 'loading' | 'success' | 'error' = 'loading';
  message = 'Потвърждаваме имейла...';

  ngOnInit(): void {
    const userId = this.route.snapshot.queryParamMap.get('userId');
    const token = this.route.snapshot.queryParamMap.get('token');

    if (!userId || !token) {
      this.status = 'error';
      this.message = 'Невалиден линк за потвърждение.';
      return;
    }

    this.authService.confirmEmail(userId!, token!).subscribe({
      next: () => {
        this.status = 'success';
        this.message =
          'Имейлът е потвърден успешно. Вече можеш да ползваш всички функционалности.';
      },
      error: (err) => {
        console.error(err);
        this.status = 'error';
        this.message = err.error?.message || 'Неуспешно потвърждение на имейла.';
      }
    });
  }
}
