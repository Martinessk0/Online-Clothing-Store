import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AdminCardComponent } from '../admin-card/admin-card.component';
import { AdminDashboardStats } from '../../../models/admin/admin-dashboard-stats';
import { AdminDashboardService } from '../../../services/admin-dashboard-service';

@Component({
  selector: 'app-home-page',
  imports: [CommonModule,RouterLink,AdminCardComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent implements OnInit {

  stats?: AdminDashboardStats;
  loading = false;
  error: string | null = null;

  constructor(private adminDashboardService: AdminDashboardService) {}

  ngOnInit(): void {
    this.loading = true;

    this.adminDashboardService.getStats().subscribe({
      next: (stats) => {
        this.stats = stats;
        this.loading = false;
      },
      error: () => {
        this.error = 'Грешка при зареждане на статистиката.';
        this.loading = false;
      }
    });
  }
}
