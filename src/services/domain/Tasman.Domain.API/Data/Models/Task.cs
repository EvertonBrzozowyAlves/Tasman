using Tasman.Domain.API.Models;

namespace Tasman.Domain.API.Data.Models;

public class Task : Entity
{
    public Guid TaskTypeId { get; set; }
    public string Description { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    //EF
    protected Task()
    {
    }

    public Task(Guid createdBy, Guid taskTypeId, string description, DateTime startedAt)
    {
        CreatedBy = createdBy;
        TaskTypeId = taskTypeId;
        Description = description;
        StartedAt = startedAt;
    }
}