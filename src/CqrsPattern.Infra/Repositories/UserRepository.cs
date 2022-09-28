using CqrsPattern.Domain.Users.Models;
using CqrsPattern.Domain.Users.Repository;
using NotificationPattern.Domain.Entities;

namespace NotificationPattern.Domain.Users.Repository;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public IEnumerable<UserItem> FindUsers(UserParameters parameters)
    {
        var query = _users.AsQueryable();

        if (parameters.Name is not null)
        {
            query = query.Where(u =>
                u.FirstName.StartsWith(parameters.Name) ||
                u.LastName.StartsWith(parameters.Name)
                );
        }

        var items = query.Select(u => new UserItem
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName
        });

        return items;
    }

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetById(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public void Update(User user)
    {
        var currentUser = GetById(user.Id);

        if (currentUser != null) currentUser = user;
    }

    public bool AnyUser(Guid userId)
    {
        return _users.Any(u => u.Id == userId);
    }

    public void Remove(User user)
    {
        _users.Remove(user);
    }
}
