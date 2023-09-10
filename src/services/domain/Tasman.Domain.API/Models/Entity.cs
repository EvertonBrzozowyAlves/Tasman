namespace Tasman.Domain.API.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? CreatedBy { get; set; }

    public Entity(Guid? createdBy = null)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
        CreatedBy = createdBy;
    }
}