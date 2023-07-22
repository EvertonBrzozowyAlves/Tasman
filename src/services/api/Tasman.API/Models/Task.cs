namespace Tasman.API.Models;

public class Task : Entity
{
   private Guid UserId { get; set; } 
   private TaskType TaskType { get; set; }
   private string? Description { get; set; }
   private DateTime StartedAt { get; set; }
   private DateTime? FinishedAt { get; set; }

   public Task(Guid userId, TaskType taskType, string? description, DateTime startedAt, DateTime? finishedAt)
   {
        UserId = userId;
        TaskType = taskType;
        Description = description;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
   }
}