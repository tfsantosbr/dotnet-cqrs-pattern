using System;
using CqrsPattern.Domain.Base.Handlers;

namespace CqrsPattern.Domain.Features.Users.Events;

public class UserRemoved : IEvent
{
    public Guid Id { get; set; }
}
