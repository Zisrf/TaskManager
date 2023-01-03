using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Tasks.Commands.RemoveSubtask;

namespace TaskManager.Application.Handlers.Tasks.Commands;

public class RemoveSubtaskHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public RemoveSubtaskHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        Subtask subtask = await _context.Subtasks.GetEntityByIdAsync(request.SubtaskId, cancellationToken);

        subtask.RootTask.RemoveSubtask(subtask);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response();
    }
}