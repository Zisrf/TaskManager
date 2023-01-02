using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Tasks;

namespace TaskManager.DataAccess.Configurations.Tasks;

public class BaseTaskConfiguration : IEntityTypeConfiguration<BaseTask>
{
    public void Configure(EntityTypeBuilder<BaseTask> builder)
    {
        builder.HasDiscriminator()
            .HasValue<RootTask>(nameof(RootTask))
            .HasValue<Subtask>(nameof(Subtask));
    }
}