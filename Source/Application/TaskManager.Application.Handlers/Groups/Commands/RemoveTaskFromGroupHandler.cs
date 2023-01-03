using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Core.Groups;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Groups.Commands.RemoveTaskFromGroup;

namespace TaskManager.Application.Handlers.Groups.Commands;

public class RemoveTaskFromGroupHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public RemoveTaskFromGroupHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        RootTask rootTask = await _context.RootTasks.GetEntityByIdAsync(request.RootTaskId, cancellationToken);
        TaskGroup taskGroup = await _context.TaskGroups.GetEntityByIdAsync(request.TaskGroupId, cancellationToken);

        taskGroup.RemoveTask(rootTask);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response();
    }
}