using System;

namespace CqrsPattern.Domain.Users.Events
{
    public class UserRemoved
    {
        public Guid Id { get; set; }
    }
}