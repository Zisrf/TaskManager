using TaskManager.Application.Contracts.Groups.Commands;
using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Extensions;
using TaskManager.Application.Handlers.Groups.Commands;
using TaskManager.Application.Handlers.Tasks.Commands;
using TaskManager.Core.Groups;
using TaskManager.Core.Tasks;
using Xunit;

namespace TaskManager.Tests.Application.Handlers;

public class RemoveTaskHandlerTest : ApplicationTestBase
{
    [Fact]
    public void RemoveSubtask_RootTaskLostIt()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createSubtaskHandler = new CreateSubtaskHandler(Context);
        var removeTaskHandler = new RemoveTaskHandler(Context);

        Guid rootTaskId = createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None).Result.RootTask.Id;

        Guid subtaskId = createSubtaskHandler.Handle(
            new CreateSubtask.Command(rootTaskId, string.Empty),
            CancellationToken.None).Result.Subtask.Id;

        RootTask rootTask = Context.RootTasks.GetEntityByIdAsync(rootTaskId, CancellationToken.None).Result;

        _ = removeTaskHandler.Handle(
            new RemoveTask.Command(subtaskId),
            CancellationToken.None).Result;

        Assert.Empty(rootTask.Subtasks);
    }

    [Fact]
    public void RemoveRootTask_TaskGroupLostIt()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createTaskGroupHandler = new CreateTaskGroupHandler(Context);
        var addTaskToGroupHandler = new AddTaskToGroupHandler(Context);
        var removeTaskHandler = new RemoveTaskHandler(Context);

        Guid rootTaskId = createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None).Result.RootTask.Id;

        Guid taskGroupId = createTaskGroupHandler.Handle(
            new CreateTaskGroup.Command(string.Empty),
            CancellationToken.None).Result.TaskGroup.Id;

        TaskGroup taskGroup = Context.TaskGroups.GetEntityByIdAsync(taskGroupId, CancellationToken.None).Result;

        _ = addTaskToGroupHandler.Handle(
            new AddTaskToGroup.Command(taskGroupId, rootTaskId),
            CancellationToken.None).Result;

        _ = removeTaskHandler.Handle(
            new RemoveTask.Command(rootTaskId),
            CancellationToken.None).Result;

        Assert.Empty(taskGroup.RootTasks);
    }
}