using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Events;
using Microsoft.Extensions.Logging;

namespace CqrsPattern.Domain.Features.Users.Handlers.EventHandlers;

public class UserCreatedEventHandler : IEventHandler<UserCreated>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserCreated eventData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("USER CREATED");

        // send e-mail...
        // send message to a message broker...
        // etc ...

        return Task.CompletedTask;
    }
}
