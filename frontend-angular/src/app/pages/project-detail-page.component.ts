import { CommonModule } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { EMPTY, distinctUntilChanged, map, switchMap } from 'rxjs';
import { Project } from '../models/api.models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-project-detail-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './project-detail-page.component.html',
  styleUrl: './project-detail-page.component.css'
})
export class ProjectDetailPageComponent implements OnInit {
  private readonly api = inject(ApiService);
  private readonly route = inject(ActivatedRoute);
  private readonly destroyRef = inject(DestroyRef);

  project: Project | null = null;
  error: string | null = null;

  ngOnInit(): void {
    this.route.paramMap
      .pipe(
        map((params) => params.get('id')),
        distinctUntilChanged(),
        switchMap((id) => {
          if (!id) {
            this.project = null;
            this.error = 'Project id is required';
            return EMPTY;
          }

          this.project = null;
          this.error = null;

          return this.api.getProject(id);
        }),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe({
        next: (project) => {
          this.project = project;
        },
        error: (error: Error) => {
          this.error = error.message;
        }
      });
  }

  displayDate(value?: string | null): string {
    return value || '-';
  }
}
