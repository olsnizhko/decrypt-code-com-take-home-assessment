import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { DashboardSummary, Organization, OrganizationSummary, Project } from '../models/api.models';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly http = inject(HttpClient);
  private readonly base = '/api';

  getDashboard(): Observable<DashboardSummary> {
    return this.http.get<DashboardSummary>(`${this.base}/dashboard`).pipe(
      catchError((error) => this.handleError(error))
    );
  }

  getOrganizations(params?: Record<string, string | number | boolean>): Observable<Organization[]> {
    return this.http.get<Organization[]>(`${this.base}/organizations`, {
      params: this.toHttpParams(params)
    }).pipe(catchError((error) => this.handleError(error)));
  }

  getOrganization(id: string): Observable<Organization> {
    return this.http.get<Organization>(`${this.base}/organizations/${id}`).pipe(
      catchError((error) => this.handleError(error))
    );
  }

  getOrganizationSummary(id: string): Observable<OrganizationSummary> {
    return this.http.get<OrganizationSummary>(`${this.base}/organizations/${id}/summary`).pipe(
      catchError((error) => this.handleError(error))
    );
  }

  getUsers(params?: Record<string, string | number | boolean>): Observable<unknown> {
    return this.http.get(`${this.base}/users`, {
      params: this.toHttpParams(params)
    }).pipe(catchError((error) => this.handleError(error)));
  }

  getUser(id: string): Observable<unknown> {
    return this.http.get(`${this.base}/users/${id}`).pipe(
      catchError((error) => this.handleError(error))
    );
  }

  getProjects(params?: Record<string, string | number | boolean>): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.base}/projects`, {
      params: this.toHttpParams(params)
    }).pipe(catchError((error) => this.handleError(error)));
  }

  getProject(id: string): Observable<Project> {
    return this.http.get<Project>(`${this.base}/projects/${id}`).pipe(
      catchError((error) => this.handleError(error))
    );
  }

  getTimeEntries(params?: Record<string, string | number | boolean>): Observable<unknown> {
    return this.http.get(`${this.base}/time-entries`, {
      params: this.toHttpParams(params)
    }).pipe(catchError((error) => this.handleError(error)));
  }

  getInvoices(params?: Record<string, string | number | boolean>): Observable<unknown> {
    return this.http.get(`${this.base}/invoices`, {
      params: this.toHttpParams(params)
    }).pipe(catchError((error) => this.handleError(error)));
  }

  private toHttpParams(params?: Record<string, string | number | boolean>): HttpParams | undefined {
    if (!params) {
      return undefined;
    }

    let httpParams = new HttpParams();
    for (const [key, value] of Object.entries(params)) {
      httpParams = httpParams.set(key, String(value));
    }

    return httpParams;
  }

  private handleError(error: HttpErrorResponse) {
    const message =
      typeof error.error === 'string' && error.error
        ? error.error
        : error.message || 'Request failed';

    return throwError(() => new Error(message));
  }
}
