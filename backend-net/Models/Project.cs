namespace Backend.Models;

public sealed class Project
{
    public required string Id { get; init; }
    public required string OrgId { get; init; }
    public required string Name { get; init; }
    public required string Status { get; init; }
    public required int BudgetHours { get; init; }
    public string? StartDate { get; init; }
    public string? EndDate { get; init; }
    public required string Description { get; init; }
}
