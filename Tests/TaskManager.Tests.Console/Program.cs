using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Tasks;
using TaskManager.DataAccess;

var optionBuilder = new DbContextOptionsBuilder<TaskManagerDatabaseContext>();

DbContextOptions<TaskManagerDatabaseContext> options =
    optionBuilder.UseSqlite($"Data Source=consoletest.db").Options;

var context = new TaskManagerDatabaseContext(options);
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var task = new RootTask("roottask");
var subtask = task.CreateSubtask("sustask");

context.RootTasks.Add(task);

context.SaveChanges();

Console.WriteLine(context.RootTasks.Count());
Console.WriteLine(context.AllTasks.Count());

