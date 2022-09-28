using System;
using CqrsPattern.Domain.Base.Handlers;

namespace CqrsPattern.Domain.Features.Users.Commands;

public class RemoveUser : ICommand
{
    public Guid Id { get; set; }
}
