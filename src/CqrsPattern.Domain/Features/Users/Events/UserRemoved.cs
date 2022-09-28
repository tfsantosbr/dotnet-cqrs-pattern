using System;

namespace CqrsPattern.Domain.Features.Users.Events;

public class UserRemoved
{
    public Guid Id { get; set; }
}
