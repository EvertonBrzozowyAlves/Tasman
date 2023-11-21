using Tasman.Domain.API.Models;

namespace Tasman.Domain.API.EventStore;

public class TaskTypeNameUpdatedEvent : IEventStoreEntity<TaskType>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }

    public string GetEventName()
    {
        return $"{nameof(TaskType)}-{Id}";
    }
}

//markup interface
public interface IEventStoreEntity<T>
{
}