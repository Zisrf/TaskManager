using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Tasks;

namespace TaskManager.DataAccess.Configurations.Tasks;

public class RootTaskConfiguration : IEntityTypeConfiguration<RootTask>
{
    public void Configure(EntityTypeBuilder<RootTask> builder)
    {
        builder.Navigation(x => x.Subtasks).HasField("_subtasks");
    }
}