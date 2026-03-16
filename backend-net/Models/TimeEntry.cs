namespace Backend.Models;

public sealed class TimeEntry
{
    public required string Id { get; init; }
    public required string UserId { get; init; }
    public required string ProjectId { get; init; }
    public required string Date { get; init; }
    public required decimal Hours { get; init; }
    public required string Description { get; init; }
}
