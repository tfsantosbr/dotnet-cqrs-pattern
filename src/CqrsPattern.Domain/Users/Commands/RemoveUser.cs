using System;

namespace CqrsPattern.Domain.Users.Commands;

public class RemoveUser
{
    public Guid Id { get; set; }
}
