using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Events;
using Microsoft.Extensions.Logging;

namespace CqrsPattern.Domain.Features.Users.Handlers.EventHandlers;

public class UserDetailsUpdatedEventHandler : IEventHandler<UserDetailsUpdated>
{
    private readonly ILogger<UserDetailsUpdatedEventHandler> _logger;

    public UserDetailsUpdatedEventHandler(ILogger<UserDetailsUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserDetailsUpdated eventData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("USER DETAILS UPDATED");

        // send e-mail...
        // send message to a message broker...
        // etc ...

        return Task.CompletedTask;
    }
}
