using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using Task = TaskManager.Core.Entities.Task;

namespace TaskManager.Application.Abstractions.DataAccess;

public interface ITaskManagerDatabaseContext
{
    DbSet<Task> Tasks { get; }
    DbSet<TaskGroup> Groups { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}