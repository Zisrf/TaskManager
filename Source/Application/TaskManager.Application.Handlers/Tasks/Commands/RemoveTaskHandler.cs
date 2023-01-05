using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Tasks.Commands.RemoveTask;

namespace TaskManager.Application.Handlers.Tasks.Commands;

public class RemoveTaskHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public RemoveTaskHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        BaseTask task = await _context.AllTasks.GetEntityByIdAsync(request.TaskId, cancellationToken);

        _context.AllTasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response();
    }
}