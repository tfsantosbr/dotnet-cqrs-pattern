using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Events;
using CqrsPattern.Domain.Features.Users.Repository;

namespace CqrsPattern.Domain.Features.Users.Handlers;

public class UpdateUserPasswordCommandHandler : ICommandHandler<UpdateUserPassword>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventHandler<UserPasswordUpdated> _userPasswordUpdatedEventHandler;

    public UpdateUserPasswordCommandHandler(
        IUserRepository userRepository, IEventHandler<UserPasswordUpdated> userPasswordUpdatedEventHandler)
    {
        _userRepository = userRepository;
        _userPasswordUpdatedEventHandler = userPasswordUpdatedEventHandler;
    }

    public async Task Handle(UpdateUserPassword command, CancellationToken cancellationToken)
    {
        // business logic

        var user = _userRepository.GetById(command.Id);

        if (user is null)
            throw new ArgumentNullException(nameof(user));

        user.UpdatePassword(command.Password);

        _userRepository.Update(user);

        // send event

        var userPasswordUpdated = new UserPasswordUpdated
        {
            Id = user.Id,
            Password = user.Password
        };

        await _userPasswordUpdatedEventHandler.Handle(userPasswordUpdated, cancellationToken);
    }
}
