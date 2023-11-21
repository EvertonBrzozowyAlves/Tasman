using Tasman.Shared.Library.Models;

namespace Tasman.Domain.API.Models;

public class TaskType : Entity
{
    public string Name { get; set; }
    public List<Task> Tasks { get; set; } = new();

    public TaskType(Guid createdBy, string name)
    {
        CreatedBy = createdBy;
        Name = name;
    }

    protected TaskType()
    {
    }
}