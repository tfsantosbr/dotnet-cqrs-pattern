using System;
using CqrsPattern.Domain.Features.Users.Models;
using CqrsPattern.Domain.Features.Users;

namespace CqrsPattern.Domain.Features.Users.Repository;

public interface IUserRepository
{
    IEnumerable<UserItem> FindUsers(UserParameters parameters);
    void Add(User user);
    User? GetById(Guid id);
    void Update(User user);
    bool AnyUser(Guid userId);
    void Remove(User user);
}
