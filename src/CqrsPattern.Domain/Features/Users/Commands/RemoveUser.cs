using System;

namespace CqrsPattern.Domain.Features.Users.Commands;

public class RemoveUser
{
    public Guid Id { get; set; }
}
