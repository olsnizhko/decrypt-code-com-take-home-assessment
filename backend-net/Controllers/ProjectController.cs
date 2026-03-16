using Backend.Contracts.Responses;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/projects")]
public sealed class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? orgId, [FromQuery] string? status) =>
        Ok(projectService.GetProjects(orgId, status));

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var project = projectService.GetProject(id);
        return project is null
            ? NotFound(new ErrorResponse("Project not found"))
            : Ok(project);
    }
}
