using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess;

var optionBuilder = new DbContextOptionsBuilder<TaskManagerDatabaseContext>();

DbContextOptions<TaskManagerDatabaseContext> options =
    optionBuilder.UseSqlite($"Data Source=consoletest.db").UseLazyLoadingProxies().Options;

var context = new TaskManagerDatabaseContext(options);

////context.Database.EnsureDeleted();
////context.Database.EnsureCreated();

////var task = new RootTask("taask");
////var subtask = task.CreateSubtask("suubtaask");

////context.RootTasks.Add(task);
////context.Subtasks.Add(subtask);
////context.SaveChanges();

////Console.WriteLine(context.RootTasks.Count());
////Console.WriteLine(context.Subtasks.Count());
////Console.WriteLine(context.AllTasks.Count());

var task = context.RootTasks.Single();

Console.WriteLine(task.Id);
Console.WriteLine(task.Info);
Console.WriteLine(task.State);
Console.WriteLine(task.Deadline);
Console.WriteLine(task.Subtasks.Count);