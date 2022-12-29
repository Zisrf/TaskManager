using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;
using TaskManager.DataAccess;
using Task = TaskManager.Core.Entities.Task;

var optionBuilder = new DbContextOptionsBuilder<TaskManagerDatabaseContext>();

DbContextOptions<TaskManagerDatabaseContext> options =
    optionBuilder.UseSqlite($"Data Source=test.db").Options;

var context = new TaskManagerDatabaseContext(options);

var task = new Task("ashjdasd");
var group = new TaskGroup("asdasfas");

task.CreateSubtask("sdasdasd", DateTime.Now);
group.AddTask(task);

context.Tasks.Add(task);
context.Groups.Add(group);

await context.SaveChangesAsync();