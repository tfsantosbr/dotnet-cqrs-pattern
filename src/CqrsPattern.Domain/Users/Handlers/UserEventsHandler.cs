using CqrsPattern.Domain.Users.Events;
using Microsoft.Extensions.Logging;

namespace CqrsPattern.Domain.Users.Handlers
{
    public class UserEventsHandler
    {
        private readonly ILogger<UserEventsHandler> _logger;

        public UserEventsHandler(ILogger<UserEventsHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(UserCreated notification)
        {
            _logger.LogInformation("USER CREATED");
        }

        public void Handle(UserDetailsUpdated notification)
        {
            _logger.LogInformation("USER DETAILS UPDATED");
        }

        public void Handle(UserPasswordUpdated notification)
        {
            _logger.LogInformation("USER PASSWORD UPDATED");
        }

        public void Handle(UserRemoved notification)
        {
            _logger.LogInformation("USER REMOVED");
        }
    }
}