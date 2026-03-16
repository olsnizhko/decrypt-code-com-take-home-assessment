import { Routes } from '@angular/router';
import { DashboardPageComponent } from './pages/dashboard-page.component';
import { OrganizationDetailPageComponent } from './pages/organization-detail-page.component';
import { OrganizationsPageComponent } from './pages/organizations-page.component';
import { ProjectDetailPageComponent } from './pages/project-detail-page.component';
import { ProjectsPageComponent } from './pages/projects-page.component';

export const routes: Routes = [
  { path: '', component: DashboardPageComponent },
  { path: 'organizations', component: OrganizationsPageComponent },
  { path: 'organizations/:id', component: OrganizationDetailPageComponent },
  { path: 'projects', component: ProjectsPageComponent },
  { path: 'projects/:id', component: ProjectDetailPageComponent }
];
