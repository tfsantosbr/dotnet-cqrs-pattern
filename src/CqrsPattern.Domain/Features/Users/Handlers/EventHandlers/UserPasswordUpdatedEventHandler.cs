using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Events;
using Microsoft.Extensions.Logging;

namespace CqrsPattern.Domain.Features.Users.Handlers.EventHandlers;

public class UserPasswordUpdatedEventHandler : IEventHandler<UserPasswordUpdated>
{
    private readonly ILogger<UserPasswordUpdatedEventHandler> _logger;

    public UserPasswordUpdatedEventHandler(ILogger<UserPasswordUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserPasswordUpdated eventData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("USER PASSWORD UPDATED");

        // send e-mail...
        // send message to a message broker...
        // etc ...

        return Task.CompletedTask;
    }
}
