import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Project } from '../models/api.models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-projects-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './projects-page.component.html',
  styleUrl: './projects-page.component.css'
})
export class ProjectsPageComponent implements OnInit {
  private readonly api = inject(ApiService);

  list: Project[] | null = null;
  error: string | null = null;

  ngOnInit(): void {
    this.api.getProjects().subscribe({
      next: (list) => {
        this.list = list;
      },
      error: (error: Error) => {
        this.error = error.message;
      }
    });
  }

  getBadge(status: string): string {
    return status === 'active' || status === 'completed' ? status : 'draft';
  }

  displayDate(value?: string | null): string {
    return value || '-';
  }
}
