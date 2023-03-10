using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Core.Groups;

namespace TaskManager.DataAccess.Configurations.Groups;

public class TaskGroupConfiguration : IEntityTypeConfiguration<TaskGroup>
{
    public void Configure(EntityTypeBuilder<TaskGroup> builder)
    {
        builder.Navigation(x => x.RootTasks).HasField("_rootTasks");

        builder.HasMany(x => x.RootTasks).WithMany();
    }
}