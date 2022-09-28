using System;
using CqrsPattern.Domain.Base.Handlers;

namespace CqrsPattern.Domain.Features.Users.Events;

public class UserPasswordUpdated : IEvent
{
    public Guid Id { get; set; }
    public string Password { get; set; } = default!;
}
