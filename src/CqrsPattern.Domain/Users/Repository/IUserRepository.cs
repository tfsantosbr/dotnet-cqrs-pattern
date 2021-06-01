using System;
using NotificationPattern.Domain.Entities;

namespace CqrsPattern.Domain.Users.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(Guid id);
        void Update(User user);
        bool AnyUser(Guid userId);
        void Remove(User user);
    }
}