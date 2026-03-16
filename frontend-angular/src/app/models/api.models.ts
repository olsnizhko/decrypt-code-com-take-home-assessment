export interface DashboardSummary {
  totalOrganizations: number;
  totalUsers: number;
  totalProjects: number;
  activeProjects: number;
  totalTimeEntries: number;
  totalInvoiced?: number | null;
}

export interface Organization {
  id: string | number;
  name: string;
  industry: string;
  tier: 'enterprise' | 'professional' | 'starter' | string;
  contactEmail: string;
}

export interface OrganizationSummary {
  organization: Organization;
  projectCount: number;
  userCount: number;
  totalInvoiced?: number | null;
  currency: string;
}

export interface ProjectOrganization {
  name: string;
}

export interface Project {
  id: string | number;
  name: string;
  status: 'active' | 'completed' | 'draft' | string;
  budgetHours: number;
  startDate?: string | null;
  endDate?: string | null;
  totalHoursLogged?: number | null;
  organization?: ProjectOrganization | null;
}
