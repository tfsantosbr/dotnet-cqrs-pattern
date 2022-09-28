using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Events;
using CqrsPattern.Domain.Features.Users.Repository;
using NotificationPattern.Domain.Entities;

namespace CqrsPattern.Domain.Features.Users.Handlers.CommandHandlers;

public class CreateUserCommandHandler : ICommandHandler<CreateUser, User>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventHandler<UserCreated> _userCreatedEventHandler;

    public CreateUserCommandHandler(
        IUserRepository userRepository, IEventHandler<UserCreated> userCreatedEventHandler)
    {
        _userRepository = userRepository;
        _userCreatedEventHandler = userCreatedEventHandler;
    }

    public async Task<User> Handle(CreateUser command, CancellationToken cancellationToken)
    {
        // business logic

        var user = new User(
            firstName: command.FirstName,
            lastName: command.LastName,
            email: command.Email,
            password: command.Password,
            birthDate: command.BirthDate
            );

        _userRepository.Add(user);

        // send event

        var userCreated = new UserCreated
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate,
            Email = user.Email,
            Password = user.Password
        };

        await _userCreatedEventHandler.Handle(userCreated, cancellationToken);

        // return user

        return user;
    }
}
