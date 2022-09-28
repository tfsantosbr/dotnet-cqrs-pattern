namespace CqrsPattern.Api.Extensions;
using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Events;
using CqrsPattern.Domain.Features.Users.Handlers;
using CqrsPattern.Domain.Features.Users.Handlers.CommandHandlers;
using CqrsPattern.Domain.Features.Users.Handlers.EventHandlers;
using CqrsPattern.Domain.Features.Users.Repository;
using CqrsPattern.Domain.Features.Users;

public static class DomainServiceExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<ICommandHandler<CreateUser, User>, CreateUserCommandHandler>();
        services.AddTransient<ICommandHandler<UpdateUserDetails>, UpdateUserDetailsCommandHandler>();
        services.AddTransient<ICommandHandler<UpdateUserPassword>, UpdateUserPasswordCommandHandler>();
        services.AddTransient<ICommandHandler<RemoveUser>, RemoveUserCommandHandler>();

        services.AddTransient<IEventHandler<UserCreated>, UserCreatedEventHandler>();
        services.AddTransient<IEventHandler<UserDetailsUpdated>, UserDetailsUpdatedEventHandler>();
        services.AddTransient<IEventHandler<UserPasswordUpdated>, UserPasswordUpdatedEventHandler>();
        services.AddTransient<IEventHandler<UserRemoved>, UserRemovedEventHandler>();

        return services;
    }
}
