using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Tasks;

namespace TaskManager.DataAccess.Configurations.Tasks;

public class SubtasksConfiguration : IEntityTypeConfiguration<Subtask>
{
    public void Configure(EntityTypeBuilder<Subtask> builder)
    {
        builder.HasOne(x => x.RootTask);
    }
}