using Tasman.Shared.Library.Aggregates;

namespace Tasman.Shared.Library.Events;

public interface IEvent<T> where T : IAggregate;