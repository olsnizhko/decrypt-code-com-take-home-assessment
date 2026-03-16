using Backend.Models;

namespace Backend.Contracts.Responses;

public sealed record ProjectDetailsResponse(
    string Id,
    string OrgId,
    string Name,
    string Status,
    int BudgetHours,
    string? StartDate,
    string? EndDate,
    string Description,
    Organization? Organization,
    decimal TotalHoursLogged);
