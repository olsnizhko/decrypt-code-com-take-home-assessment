namespace Backend.Models;

public sealed class Organization
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Slug { get; init; }
    public required string Industry { get; init; }
    public required string Tier { get; init; }
    public required string ContactEmail { get; init; }
    public required string CreatedAt { get; init; }
    public required string Description { get; init; }
    public required OrganizationSettings Settings { get; init; }
    public required OrganizationMetadata Metadata { get; init; }
}

public sealed class OrganizationSettings
{
    public required string Timezone { get; init; }
    public required string Currency { get; init; }
    public required bool AllowOvertime { get; init; }
    public required string DefaultLocale { get; init; }
}

public sealed class OrganizationMetadata
{
    public required string Source { get; init; }
    public int? LegacyId { get; init; }
    public string? MigratedAt { get; init; }
}
