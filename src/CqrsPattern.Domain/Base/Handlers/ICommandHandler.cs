namespace CqrsPattern.Domain.Base.Handlers;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default!);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellationToken = default!);
}
