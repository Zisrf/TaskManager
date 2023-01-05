using TaskManager.Application.Contracts.Groups.Commands;
using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Extensions;
using TaskManager.Application.Handlers.Groups.Commands;
using TaskManager.Application.Handlers.Tasks.Commands;
using TaskManager.Core.Groups;
using TaskManager.Core.Tasks;
using Xunit;

namespace TaskManager.Tests.Handlers.Tasks;

public class RemoveTaskHandlerTest : HandlerTestBase
{
    [Fact]
    public async void RemoveSubtask_RootTaskLostIt()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createSubtaskHandler = new CreateSubtaskHandler(Context);
        var removeTaskHandler = new RemoveTaskHandler(Context);

        Guid rootTaskId = (await createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None)).RootTask.Id;

        Guid subtaskId = (await createSubtaskHandler.Handle(
            new CreateSubtask.Command(rootTaskId, string.Empty),
            CancellationToken.None)).Subtask.Id;

        RootTask rootTask = await Context.RootTasks.GetEntityByIdAsync(rootTaskId, CancellationToken.None);

        await removeTaskHandler.Handle(
            new RemoveTask.Command(subtaskId),
            CancellationToken.None);

        Assert.Empty(rootTask.Subtasks);
    }

    [Fact]
    public async void RemoveRootTask_TaskGroupLostIt()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createTaskGroupHandler = new CreateTaskGroupHandler(Context);
        var addTaskToGroupHandler = new AddTaskToGroupHandler(Context);
        var removeTaskHandler = new RemoveTaskHandler(Context);

        Guid rootTaskId = (await createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None)).RootTask.Id;

        Guid taskGroupId = (await createTaskGroupHandler.Handle(
            new CreateTaskGroup.Command(string.Empty),
            CancellationToken.None)).TaskGroup.Id;

        TaskGroup taskGroup = await Context.TaskGroups.GetEntityByIdAsync(taskGroupId, CancellationToken.None);

        await addTaskToGroupHandler.Handle(
            new AddTaskToGroup.Command(taskGroupId, rootTaskId),
            CancellationToken.None);

        await removeTaskHandler.Handle(
            new RemoveTask.Command(rootTaskId),
            CancellationToken.None);

        Assert.Empty(taskGroup.RootTasks);
    }
}