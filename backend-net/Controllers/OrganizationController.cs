using Backend.Contracts.Responses;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/organizations")]
public sealed class OrganizationController(IOrganizationService organizationService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? tier, [FromQuery] string? industry) =>
        Ok(organizationService.GetOrganizations(tier, industry));

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var organization = organizationService.GetOrganization(id);
        return organization is null
            ? NotFound(new ErrorResponse("Organization not found"))
            : Ok(organization);
    }

    [HttpGet("{id}/summary")]
    public IActionResult GetSummary(string id)
    {
        var summary = organizationService.GetOrganizationSummary(id);
        return summary is null
            ? NotFound(new ErrorResponse("Organization not found"))
            : Ok(summary);
    }
}
