using System;

namespace CqrsPattern.Domain.Users.Events;

public class UserCreated
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime BirthDate { get; set; }
}
