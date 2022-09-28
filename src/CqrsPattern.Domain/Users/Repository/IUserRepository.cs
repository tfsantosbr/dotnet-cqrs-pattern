using System;
using CqrsPattern.Domain.Users.Models;
using NotificationPattern.Domain.Entities;

namespace CqrsPattern.Domain.Users.Repository;

public interface IUserRepository
{
    IEnumerable<UserItem> FindUsers(UserParameters parameters);
    void Add(User user);
    User? GetById(Guid id);
    void Update(User user);
    bool AnyUser(Guid userId);
    void Remove(User user);
}
