using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tasman.Domain.API.Data.ModelConfigurations;

public class TaskConfiguration : IEntityTypeConfiguration<Models.Task>
{
    public void Configure(EntityTypeBuilder<Models.Task> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(p => p.Id).HasName("PK_Tasks");
        builder.HasOne(p => p.TaskType).WithMany(p => p.Tasks).HasForeignKey(p => p.TaskTypeId).HasConstraintName("FK_Tasks_TaskTypes");
        builder.Property(p => p.Id).HasColumnType("UNIQUEIDENTIFIER").HasColumnName("Id").IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnType("DATETIME").HasColumnName("CreatedAt").IsRequired();
        builder.Property(p => p.IsDeleted).HasColumnType("BIT").HasColumnName("IsDeleted").IsRequired();
        builder.Property(p => p.Description).HasColumnType("VARCHAR(100)").HasColumnName("Description").IsRequired();
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}