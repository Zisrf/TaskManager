using TaskManager.Application.Contracts.Commands;
using TaskManager.Application.Handlers.Commands;
using Xunit;

namespace TaskManager.Tests.Application;

public class CompleteTaskHandlerTest : ApplicationTestBase
{
    [Fact]
    public void CreateSubtaskInCompletedTask_ThrowException()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createSubtaskHandler = new CreateSubtaskHandler(Context);
        var comleteTaskHandler = new CompleteTaskHandler(Context);

        Guid rootTaskId = createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None).Result.RootTask.Id;

        _ = createSubtaskHandler.Handle(
                new CreateSubtask.Command(rootTaskId, string.Empty),
                CancellationToken.None).Result;

        Assert.ThrowsAny<Exception>(() =>
            comleteTaskHandler.Handle(
                new CompleteTask.Command(rootTaskId),
                CancellationToken.None).Result);
    }
}