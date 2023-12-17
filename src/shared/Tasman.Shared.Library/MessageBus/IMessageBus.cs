using Tasman.Shared.Library.Aggregates;
using Tasman.Shared.Library.Events;

namespace Tasman.Shared.Library.MessageBus;

public interface IMessageBus
{
    public void Publish<T>(T message) where T : IEvent<IAggregate>;
    public void Consume<T>(string queueName, Action<T?> executeAfterConsumed) where T : IEvent<IAggregate>;
}