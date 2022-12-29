using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Core.Entities;
using Task = TaskManager.Core.Entities.Task;

namespace TaskManager.DataAccess;

public class TaskManagerDatabaseContext : DbContext, ITaskManagerDatabaseContext
{
    public TaskManagerDatabaseContext(DbContextOptions<TaskManagerDatabaseContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Task> Tasks { get; protected init; } = null!;
    public DbSet<TaskGroup> Groups { get; protected init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}