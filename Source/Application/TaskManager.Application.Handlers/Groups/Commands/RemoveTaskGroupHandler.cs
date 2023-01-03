using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Core.Groups;
using static TaskManager.Application.Contracts.Groups.Commands.RemoveTaskGroup;

namespace TaskManager.Application.Handlers.Groups.Commands;

public class RemoveTaskGroupHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public RemoveTaskGroupHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        TaskGroup taskGroup = await _context.TaskGroups.GetEntityByIdAsync(request.TaskGroupId, cancellationToken);

        _context.TaskGroups.Remove(taskGroup);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response();
    }
}