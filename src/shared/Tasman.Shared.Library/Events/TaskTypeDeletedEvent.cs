using Tasman.Shared.Library.Aggregates;

namespace Tasman.Shared.Library.Events;

public class TaskTypeDeletedEvent : IEvent<TaskType>
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