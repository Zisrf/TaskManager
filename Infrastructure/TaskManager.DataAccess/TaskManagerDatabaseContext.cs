using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Core.Groups;
using TaskManager.Core.Tasks;

namespace TaskManager.DataAccess;

public class TaskManagerDatabaseContext : DbContext, ITaskManagerDatabaseContext
{
    public TaskManagerDatabaseContext(DbContextOptions<TaskManagerDatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<RootTask> RootTasks { get; protected init; } = null!;
    public DbSet<BaseTask> AllTasks { get; protected init; } = null!;
    public DbSet<TaskGroup> TaskGroups { get; protected init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}