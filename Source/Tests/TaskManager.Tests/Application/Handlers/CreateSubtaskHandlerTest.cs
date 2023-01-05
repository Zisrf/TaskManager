using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Extensions;
using TaskManager.Application.Handlers.Tasks.Commands;
using TaskManager.Core.Tasks;
using Xunit;

namespace TaskManager.Tests.Application.Handlers;

public class CreateSubtaskHandlerTest : ApplicationTestBase
{
    [Fact]
    public void CreateSubtask_RootTaskHasIt()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createSubtaskHandler = new CreateSubtaskHandler(Context);

        Guid rootTaskId = createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None).Result.RootTask.Id;

        Guid subtaskId = createSubtaskHandler.Handle(
            new CreateSubtask.Command(rootTaskId, string.Empty),
            CancellationToken.None).Result.Subtask.Id;

        RootTask rootTask = Context.RootTasks.GetEntityByIdAsync(rootTaskId, CancellationToken.None).Result;
        Subtask subtask = Context.Subtasks.GetEntityByIdAsync(subtaskId, CancellationToken.None).Result;

        Assert.Contains(subtask, rootTask.Subtasks);
    }

    [Fact]
    public void CreateSubtaskInCompletedTask_ThrowException()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var comleteTaskHandler = new CompleteTaskHandler(Context);
        var createSubtaskHandler = new CreateSubtaskHandler(Context);

        Guid rootTaskId = createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None).Result.RootTask.Id;

        _ = comleteTaskHandler.Handle(
            new CompleteTask.Command(rootTaskId),
            CancellationToken.None).Result;

        Assert.ThrowsAny<Exception>(()
            => createSubtaskHandler.Handle(
                new CreateSubtask.Command(rootTaskId, string.Empty),
                CancellationToken.None).Result);
    }
}