using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Abstractions.DataAccess;

namespace TaskManager.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection collection,
        Action<DbContextOptionsBuilder> configuration)
    {
        collection.AddDbContext<ITaskManagerDatabaseContext, TaskManagerDatabaseContext>(configuration);
        // collection.AddScoped<TaskManagerDatabaseContext>(x => x.GetRequiredService<TaskManagerDatabaseContext>());

        return collection;
    }
}