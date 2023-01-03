using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Handlers.Tasks.Commands;
using Xunit;

namespace TaskManager.Tests.Application;

public class CreateSubtaskHandlerTest : ApplicationTestBase
{
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