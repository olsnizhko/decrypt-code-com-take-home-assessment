using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/time-entries")]
public sealed class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll(
        [FromQuery] string? userId,
        [FromQuery] string? projectId,
        [FromQuery] string? from,
        [FromQuery] string? to) =>
        Ok(timeEntryService.GetTimeEntries(userId, projectId, from, to));
}
