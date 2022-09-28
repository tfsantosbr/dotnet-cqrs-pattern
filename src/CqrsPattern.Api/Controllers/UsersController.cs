using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Handlers;
using CqrsPattern.Domain.Features.Users.Models;
using CqrsPattern.Domain.Features.Users.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CqrsPattern.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly UserCommandsHandler _handler;
    private readonly IUserRepository _userRepository;

    public UsersController(UserCommandsHandler handler, IUserRepository userRepository)
    {
        _handler = handler;
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult FindUsers([FromQuery] UserParameters parameters)
    {
        var users = _userRepository.FindUsers(parameters);

        return Ok(users);
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUser request)
    {
        var user = _handler.Handle(request);

        var userDetails = new UserDetails
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = $"{user.BirthDate:yyyy-MM-dd}",
            Email = user.Email
        };

        return Created($"users/{userDetails.Id}", userDetails);
    }

    [HttpGet("{userId}")]
    public IActionResult GetUserById(Guid userId)
    {
        var user = _userRepository.GetById(userId);

        if (user is null)
            return NotFound();

        var userDetails = new UserDetails
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = $"{user.BirthDate:yyyy-MM-dd}",
            Email = user.Email
        };

        return Ok(userDetails);
    }

    [HttpDelete]
    public IActionResult RemoveUser(Guid userId)
    {
        if (!_userRepository.AnyUser(userId))
            return NotFound();

        _handler.Handle(new RemoveUser { Id = userId });

        return NoContent();
    }

    [HttpPut("details")]
    public IActionResult UpdateUserDetails(UpdateUserDetails request)
    {
        if (!_userRepository.AnyUser(request.Id))
        {
            return NotFound();
        }

        _handler.Handle(request);

        return NoContent();
    }

    [HttpPut("password")]
    public IActionResult UpdateUserPassword(UpdateUserPassword request)
    {
        if (!_userRepository.AnyUser(request.Id))
        {
            return NotFound();
        }

        _handler.Handle(request);

        return NoContent();
    }
}
