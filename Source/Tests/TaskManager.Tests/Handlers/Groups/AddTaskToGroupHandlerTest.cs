using TaskManager.Application.Contracts.Groups.Commands;
using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Extensions;
using TaskManager.Application.Handlers.Groups.Commands;
using TaskManager.Application.Handlers.Tasks.Commands;
using TaskManager.Core.Groups;
using TaskManager.Core.Tasks;
using Xunit;

namespace TaskManager.Tests.Handlers.Groups;

public class AddTaskToGroupHandlerTest : HandlerTestBase
{
    [Fact]
    public async void AddTaskToTwoTaskGroups_BothTaskGroupsHaveIt()
    {
        var createRootTaskHandler = new CreateRootTaskHandler(Context);
        var createTaskGroupHandler = new CreateTaskGroupHandler(Context);
        var addTaskToGroupHandler = new AddTaskToGroupHandler(Context);

        Guid rootTaskId = (await createRootTaskHandler.Handle(
            new CreateRootTask.Command(string.Empty),
            CancellationToken.None)).RootTask.Id;

        Guid taskGroup1Id = (await createTaskGroupHandler.Handle(
            new CreateTaskGroup.Command(string.Empty),
            CancellationToken.None)).TaskGroup.Id;

        Guid taskGroup2Id = (await createTaskGroupHandler.Handle(
            new CreateTaskGroup.Command(string.Empty),
            CancellationToken.None)).TaskGroup.Id;

        await addTaskToGroupHandler.Handle(
            new AddTaskToGroup.Command(taskGroup1Id, rootTaskId),
            CancellationToken.None);

        await addTaskToGroupHandler.Handle(
            new AddTaskToGroup.Command(taskGroup2Id, rootTaskId),
            CancellationToken.None);

        RootTask rootTask = await Context.RootTasks.GetEntityByIdAsync(rootTaskId);
        TaskGroup taskGroup1 = await Context.TaskGroups.GetEntityByIdAsync(taskGroup1Id);
        TaskGroup taskGroup2 = await Context.TaskGroups.GetEntityByIdAsync(taskGroup2Id);

        Assert.Contains(rootTask, taskGroup1.RootTasks);
        Assert.Contains(rootTask, taskGroup2.RootTasks);
    }
}