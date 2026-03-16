import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Organization } from '../models/api.models';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-organizations-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './organizations-page.component.html',
  styleUrl: './organizations-page.component.css'
})
export class OrganizationsPageComponent implements OnInit {
  private readonly api = inject(ApiService);

  list: Organization[] | null = null;
  error: string | null = null;

  ngOnInit(): void {
    this.api.getOrganizations().subscribe({
      next: (list) => {
        this.list = list;
      },
      error: (error: Error) => {
        this.error = error.message;
      }
    });
  }
}
