using Tasman.Domain.API.Models;

namespace Tasman.Domain.API.Data.Models;

public class TaskType : Entity
{
    public string Name { get; set; }

    //EF
    protected TaskType()
    {
    }

    public TaskType(Guid createdBy, string name)
    {
        CreatedBy = createdBy;
        Name = name;
    }
}