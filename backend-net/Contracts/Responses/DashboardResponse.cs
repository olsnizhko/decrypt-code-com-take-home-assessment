namespace Backend.Contracts.Responses;

public sealed record DashboardResponse(
    int TotalOrganizations,
    int TotalUsers,
    int TotalProjects,
    int ActiveProjects,
    int TotalTimeEntries,
    decimal TotalInvoiced);
