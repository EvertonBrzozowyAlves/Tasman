namespace Tasman.Domain.API.Models;

public abstract class Entity
{
    protected Guid Id { get; set; }
    protected DateTime CreatedAt { get; set; }
    protected bool IsDeleted { get; set; }

    public Entity()
    {
       Id = Guid.NewGuid();
       CreatedAt = DateTime.UtcNow;
       IsDeleted = false; 
    }
}