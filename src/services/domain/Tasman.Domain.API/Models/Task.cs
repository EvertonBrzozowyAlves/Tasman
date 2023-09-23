using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Models;

public class Task : Entity
{
    public Guid TaskTypeId { get; set; }
    public string Description { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    public Task(Guid createdBy, Guid taskTypeId, string description, DateTime startedAt)
    {
        CreatedBy = createdBy;
        TaskTypeId = taskTypeId;
        Description = description;
        StartedAt = startedAt;
    }
}