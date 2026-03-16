using Backend.Models;

namespace Backend.Contracts.Responses;

public sealed record OrganizationSummaryResponse(
    Organization Organization,
    int ProjectCount,
    int UserCount,
    decimal TotalInvoiced,
    string Currency);
