namespace Tasman.Domain.API.Models;

public class TaskType : Entity
{
    private Guid UserId { get; set; }
    private string Name { get; set; }

    public TaskType(Guid userId, string name)
    {
       UserId = userId;
       Name = name; 
    }
}