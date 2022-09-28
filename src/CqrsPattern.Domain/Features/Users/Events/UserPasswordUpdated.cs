using System;

namespace CqrsPattern.Domain.Features.Users.Events;

public class UserPasswordUpdated
{
    public Guid Id { get; set; }
    public string Password { get; set; } = default!;
}
