using Backend.Contracts.Responses;
using Backend.Data;

namespace Backend.Services;

public interface IDashboardService
{
    DashboardResponse GetDashboard();
}

public sealed class DashboardService(MockStore store) : IDashboardService
{
    public DashboardResponse GetDashboard() =>
        new(
            store.Organizations.Count,
            store.Users.Count,
            store.Projects.Count,
            store.Projects.Count(project => project.Status == "active"),
            store.TimeEntries.Count,
            store.Invoices.Sum(invoice => invoice.Amount));
}
