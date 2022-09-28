using System;
using System.Text.Json.Serialization;
using CqrsPattern.Domain.Base.Handlers;

namespace CqrsPattern.Domain.Features.Users.Commands;

public class UpdateUserPassword : ICommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
