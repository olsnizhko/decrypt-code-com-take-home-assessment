using Backend.Contracts.Responses;
using Backend.Data;
using Backend.Models;

namespace Backend.Services;

public interface IProjectService
{
    IEnumerable<Project> GetProjects(string? orgId, string? status);
    ProjectDetailsResponse? GetProject(string id);
}

public sealed class ProjectService(MockStore store) : IProjectService
{
    public IEnumerable<Project> GetProjects(string? orgId, string? status)
    {
        IEnumerable<Project> data = store.Projects;

        if (!string.IsNullOrWhiteSpace(orgId))
        {
            data = data.Where(project => project.OrgId == orgId);
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            data = data.Where(project => project.Status == status);
        }

        return data;
    }

    public ProjectDetailsResponse? GetProject(string id)
    {
        var project = store.Projects.FirstOrDefault(candidate => candidate.Id == id);
        if (project is null)
        {
            return null;
        }

        var organization = store.Organizations.FirstOrDefault(org => org.Id == project.OrgId);
        var totalHoursLogged = store.TimeEntries
            .Where(entry => entry.ProjectId == project.Id)
            .Sum(entry => entry.Hours);

        return new ProjectDetailsResponse(
            project.Id,
            project.OrgId,
            project.Name,
            project.Status,
            project.BudgetHours,
            project.StartDate,
            project.EndDate,
            project.Description,
            organization,
            totalHoursLogged);
    }
}
