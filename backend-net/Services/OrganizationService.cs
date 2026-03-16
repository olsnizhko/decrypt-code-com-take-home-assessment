using Backend.Contracts.Responses;
using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public interface IOrganizationService
{
    IEnumerable<Organization> GetOrganizations(string? tier, string? industry);
    Organization? GetOrganization(string id);
    OrganizationSummaryResponse? GetOrganizationSummary(string id);
}

public sealed class OrganizationService(MockStore store) : IOrganizationService
{
    public IEnumerable<Organization> GetOrganizations(string? tier, string? industry)
    {
        IEnumerable<Organization> data = store.Organizations;

        if (!string.IsNullOrWhiteSpace(tier))
        {
            data = data.Where(org => org.Tier == tier);
        }

        if (!string.IsNullOrWhiteSpace(industry))
        {
            data = data.Where(org => org.Industry == industry);
        }

        return data;
    }

    public Organization? GetOrganization(string id) =>
        store.Organizations.FirstOrDefault(org => org.Id == id);

    public OrganizationSummaryResponse? GetOrganizationSummary(string id)
    {
        var organization = GetOrganization(id);
        if (organization is null)
        {
            return null;
        }

        var projects = store.Projects.Where(project => project.OrgId == organization.Id).ToList();
        var users = store.Users.Where(user => user.OrgId == organization.Id).ToList();
        var invoices = store.Invoices.Where(invoice => invoice.OrgId == organization.Id).ToList();

        return new OrganizationSummaryResponse(
            organization,
            projects.Count,
            users.Count,
            invoices.Sum(invoice => invoice.Amount),
            organization.Settings.Currency);
    }
}
