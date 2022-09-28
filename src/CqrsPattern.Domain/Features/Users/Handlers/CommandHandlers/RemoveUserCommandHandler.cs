using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Events;
using CqrsPattern.Domain.Features.Users.Repository;

namespace CqrsPattern.Domain.Features.Users.Handlers.CommandHandlers;

public class RemoveUserCommandHandler : ICommandHandler<RemoveUser>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventHandler<UserRemoved> _userRemovedEventHandler;

    public RemoveUserCommandHandler(
        IUserRepository userRepository, IEventHandler<UserRemoved> userRemovedEventHandler)
    {
        _userRepository = userRepository;
        _userRemovedEventHandler = userRemovedEventHandler;
    }

    public async Task Handle(RemoveUser command, CancellationToken cancellationToken)
    {
        // validations

        var user = _userRepository.GetById(command.Id);

        if (user is null)
            throw new ArgumentNullException(nameof(user));

        _userRepository.Remove(user);

        // send event

        var userRemoved = new UserRemoved
        {
            Id = user.Id
        };

        await _userRemovedEventHandler.Handle(userRemoved);
    }
}
