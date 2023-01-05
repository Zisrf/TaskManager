using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess;

namespace TaskManager.Tests.Handlers;

public class HandlerTestBase : IDisposable
{
    protected readonly TaskManagerDatabaseContext Context;

    protected HandlerTestBase()
    {
        var optionBuilder = new DbContextOptionsBuilder<TaskManagerDatabaseContext>();

        DbContextOptions<TaskManagerDatabaseContext> options =
            optionBuilder.UseSqlite($"Data Source={Guid.NewGuid()}.db").Options;

        Context = new TaskManagerDatabaseContext(options);
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();

        GC.SuppressFinalize(this);
    }
}