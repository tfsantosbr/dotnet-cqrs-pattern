using CqrsPattern.Domain.Base.Handlers;
using CqrsPattern.Domain.Features.Users.Commands;
using CqrsPattern.Domain.Features.Users.Events;
using CqrsPattern.Domain.Features.Users.Handlers.CommandHandlers;
using CqrsPattern.Domain.Features.Users.Handlers.EventHandlers;
using CqrsPattern.Domain.Features.Users.Repository;
using NotificationPattern.Domain.Entities;
using NotificationPattern.Domain.Features.Users.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICommandHandler<CreateUser, User>, CreateUserCommandHandler>();

builder.Services.AddTransient<IEventHandler<UserCreated>, UserCreatedEventHandler>();
builder.Services.AddTransient<IEventHandler<UserDetailsUpdated>, UserDetailsUpdatedEventHandler>();
builder.Services.AddTransient<IEventHandler<UserPasswordUpdated>, UserPasswordUpdatedEventHandler>();
builder.Services.AddTransient<IEventHandler<UserRemoved>, UserRemovedEventHandler>();

builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
