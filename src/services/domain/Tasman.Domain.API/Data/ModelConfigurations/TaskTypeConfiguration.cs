using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasman.Domain.API.Data.Models;

namespace Tasman.Domain.API.Data.ModelConfigurations;

public class NewsConfiguration : IEntityTypeConfiguration<TaskType>
{
    public void Configure(EntityTypeBuilder<TaskType> builder)
    {
    }
}
