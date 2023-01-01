using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Groups;
using TaskManager.Core.Tasks;

namespace TaskManager.Application.Abstractions.DataAccess;

public interface ITaskManagerDatabaseContext
{
    DbSet<RootTask> RootTasks { get; }
    DbSet<BaseTask> AllTasks { get; }

    DbSet<TaskGroup> TaskGroups { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}