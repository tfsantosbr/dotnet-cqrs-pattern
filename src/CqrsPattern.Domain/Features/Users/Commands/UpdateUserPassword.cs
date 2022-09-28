using System;

namespace CqrsPattern.Domain.Features.Users.Commands;

public class UpdateUserPassword
{
    public Guid Id { get; set; }
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}