using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasman.Domain.API.Models;

namespace Tasman.Domain.API.Data.ModelConfigurations;

public class TaskTypeConfiguration : IEntityTypeConfiguration<TaskType>
{
    public void Configure(EntityTypeBuilder<TaskType> builder)
    {
        builder.ToTable("TaskTypes");
        builder.HasKey(p => p.Id).HasName("PK_TaskTypes");
        builder.Property(p => p.Id).HasColumnType("UNIQUEIDENTIFIER").HasColumnName("Id").IsRequired();
        builder.Property(p => p.CreatedAt).HasColumnType("DATETIME").HasColumnName("CreatedAt").IsRequired();
        builder.Property(p => p.IsDeleted).HasColumnType("BIT").HasColumnName("IsDeleted").IsRequired();
        builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").HasColumnName("Name").IsRequired();
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}