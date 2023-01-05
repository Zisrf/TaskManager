using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Handlers.Tasks.Commands;
using Xunit;

namespace TaskManager.Tests.Handlers.Tasks;

public class CompleteTaskHandlerTest : HandlerTestBase
{
    [Fact]
    public async void CreateSubtaskInCompletedTask_ThrowException()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createSubtaskHandler = new CreateSubtaskHandler(Context);
        var comleteTaskHandler = new CompleteTaskHandler(Context);

        Guid rootTaskId = (await createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None)).RootTask.Id;

        await createSubtaskHandler.Handle(
                new CreateSubtask.Command(rootTaskId, string.Empty),
                CancellationToken.None);

        await Assert.ThrowsAnyAsync<Exception>(async ()
            => await comleteTaskHandler.Handle(
                new CompleteTask.Command(rootTaskId),
                CancellationToken.None));
    }
}