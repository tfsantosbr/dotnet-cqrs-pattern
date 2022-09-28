using System;

namespace CqrsPattern.Domain.Features.Users.Models;

public class UserDetails
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string BirthDate { get; set; } = default!;
};
