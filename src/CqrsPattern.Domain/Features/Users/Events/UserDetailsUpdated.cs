using System;

namespace CqrsPattern.Domain.Features.Users.Events;

public class UserDetailsUpdated
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime BirthDate { get; set; }
}
