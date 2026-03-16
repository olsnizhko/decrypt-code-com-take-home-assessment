import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { DashboardSummary } from '../models/api.models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-dashboard-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard-page.component.html',
  styleUrl: './dashboard-page.component.css'
})
export class DashboardPageComponent implements OnInit {
  private readonly api = inject(ApiService);

  data: DashboardSummary | null = null;
  error: string | null = null;

  ngOnInit(): void {
    this.api.getDashboard().subscribe({
      next: (data) => {
        this.data = data;
      },
      error: (error: Error) => {
        this.error = error.message;
      }
    });
  }

  formatNumber(value?: number | null): string {
    return value?.toLocaleString() ?? '';
  }
}
