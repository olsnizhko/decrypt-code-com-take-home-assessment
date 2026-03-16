using Backend.Contracts.Responses;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? orgId, [FromQuery] string? role, [FromQuery] string? active) =>
        Ok(userService.GetUsers(orgId, role, active));

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var user = userService.GetUser(id);
        return user is null
            ? NotFound(new ErrorResponse("User not found"))
            : Ok(user);
    }
}
