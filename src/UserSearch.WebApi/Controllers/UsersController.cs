using Microsoft.AspNetCore.Mvc;
using UserSearch.Application;

namespace UserSearch.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly Mediator.Mediator _mediator;

    public UsersController(ILogger<UsersController> logger, Mediator.Mediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<UserDto>> Get([FromQuery] string searchTerm)
        => await _mediator.Send(new SearchUsersCommand(searchTerm));
}