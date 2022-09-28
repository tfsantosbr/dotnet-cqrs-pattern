using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Models;
using CqrsPattern.Domain.Features.Users.Repository;
using Microsoft.AspNetCore.Mvc;
using NotificationPattern.Domain.Entities;

namespace CqrsPattern.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ICommandHandler<CreateUser, User> _createUserCommandHandler;
    private readonly ICommandHandler<UpdateUserDetails> _updateUserDetailsCommandHandler;
    private readonly ICommandHandler<UpdateUserPassword> _updateUserPasswordCommandHandler;
    private readonly ICommandHandler<RemoveUser> _removeUserCommandHandler;

    public UsersController(
        IUserRepository userRepository, 
        ICommandHandler<CreateUser, User> createUserCommandHandler, 
        ICommandHandler<UpdateUserDetails> updateUserDetailsCommandHandler, 
        ICommandHandler<UpdateUserPassword> updateUserPasswordCommandHandler, 
        ICommandHandler<RemoveUser> removeUserCommandHandler)
    {
        _userRepository = userRepository;
        _createUserCommandHandler = createUserCommandHandler;
        _updateUserDetailsCommandHandler = updateUserDetailsCommandHandler;
        _updateUserPasswordCommandHandler = updateUserPasswordCommandHandler;
        _removeUserCommandHandler = removeUserCommandHandler;
    }

    [HttpGet]
    public IActionResult FindUsers([FromQuery] UserParameters parameters)
    {
        var users = _userRepository.FindUsers(parameters);

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUser request, CancellationToken cancellationToken)
    {
        var createdUser = await _createUserCommandHandler.Handle(request, cancellationToken);

        var userDetails = new UserDetails
        {
            Id = createdUser.Id,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            BirthDate = $"{createdUser.BirthDate:yyyy-MM-dd}",
            Email = createdUser.Email
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

        _removeUserCommandHandler.Handle(new RemoveUser { Id = userId });

        return NoContent();
    }

    [HttpPut("details")]
    public IActionResult UpdateUserDetails(UpdateUserDetails request)
    {
        if (!_userRepository.AnyUser(request.Id))
        {
            return NotFound();
        }

        _updateUserDetailsCommandHandler.Handle(request);

        return NoContent();
    }

    [HttpPut("password")]
    public IActionResult UpdateUserPassword(UpdateUserPassword request)
    {
        if (!_userRepository.AnyUser(request.Id))
        {
            return NotFound();
        }

        _updateUserPasswordCommandHandler.Handle(request);

        return NoContent();
    }
}
