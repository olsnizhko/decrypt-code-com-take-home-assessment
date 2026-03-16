namespace Backend.Models;

public sealed class Invoice
{
    public required string Id { get; init; }
    public required string OrgId { get; init; }
    public required string ProjectId { get; init; }
    public required decimal Amount { get; init; }
    public required string Currency { get; init; }
    public required string Status { get; init; }
    public string? DueDate { get; init; }
    public string? IssuedAt { get; init; }
    public required string Description { get; init; }
}
