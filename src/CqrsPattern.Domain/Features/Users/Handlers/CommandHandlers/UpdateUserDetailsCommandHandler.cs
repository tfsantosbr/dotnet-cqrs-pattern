using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Events;
using CqrsPattern.Domain.Features.Users.Repository;

namespace CqrsPattern.Domain.Features.Users.Handlers;

public class UpdateUserDetailsCommandHandler : ICommandHandler<UpdateUserDetails>
{
    private readonly IUserRepository _userRepository;
    private readonly IEventHandler<UserDetailsUpdated> _userDetailsUpdatedEventHandler;

    public UpdateUserDetailsCommandHandler(
        IUserRepository userRepository, IEventHandler<UserDetailsUpdated> userDetailsUpdatedEventHandler)
    {
        _userRepository = userRepository;
        _userDetailsUpdatedEventHandler = userDetailsUpdatedEventHandler;
    }

    public async Task Handle(UpdateUserDetails command, CancellationToken cancellationToken)
    {
        // business logic

        var user = _userRepository.GetById(command.Id);

        if (user is null)
            throw new ArgumentNullException(nameof(user));

        user.UpdateDetails(
            firstName: command.FirstName,
            lastName: command.LastName,
            email: command.Email,
            birthDate: command.BirthDate
        );

        _userRepository.Update(user);

        // send event

        var userDetailsUpdated = new UserDetailsUpdated
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate,
            Email = user.Email
        };

        await _userDetailsUpdatedEventHandler.Handle(userDetailsUpdated);
    }
}
