namespace CqrsPattern.Domain.Users.Models;

public class UserItem
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}
