using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Events;
using Microsoft.Extensions.Logging;

namespace CqrsPattern.Domain.Features.Users.Handlers.EventHandlers;

public class UserRemovedEventHandler : IEventHandler<UserRemoved>
{
    private readonly ILogger<UserRemovedEventHandler> _logger;

    public UserRemovedEventHandler(ILogger<UserRemovedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(UserRemoved eventData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("USER REMOVED");

        // send e-mail...
        // send message to a message broker...
        // etc ...

        return Task.CompletedTask;
    }
}
