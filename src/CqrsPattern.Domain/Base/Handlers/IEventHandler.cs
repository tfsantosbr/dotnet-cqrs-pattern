namespace CqrsPattern.Domain.Base.Handlers;

public interface IEventHandler<in TEvent, TResponse> where TEvent : IEvent
{
    Task<TResponse> Handle(TEvent eventData, CancellationToken cancellationToken = default!);
}

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task Handle(TEvent eventData, CancellationToken cancellationToken = default!);
}
