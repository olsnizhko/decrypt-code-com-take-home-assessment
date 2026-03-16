import { CommonModule } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { EMPTY, distinctUntilChanged, map, switchMap } from 'rxjs';
import { OrganizationSummary } from '../models/api.models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-organization-detail-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './organization-detail-page.component.html',
  styleUrl: './organization-detail-page.component.css'
})
export class OrganizationDetailPageComponent implements OnInit {
  private readonly api = inject(ApiService);
  private readonly route = inject(ActivatedRoute);
  private readonly destroyRef = inject(DestroyRef);

  summary: OrganizationSummary | null = null;
  error: string | null = null;

  ngOnInit(): void {
    this.route.paramMap
      .pipe(
        map((params) => params.get('id')),
        distinctUntilChanged(),
        switchMap((id) => {
          if (!id) {
            this.summary = null;
            this.error = 'Organization id is required';
            return EMPTY;
          }

          this.summary = null;
          this.error = null;

          return this.api.getOrganizationSummary(id);
        }),
        takeUntilDestroyed(this.destroyRef)
      )
      .subscribe({
        next: (summary) => {
          this.summary = summary;
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
