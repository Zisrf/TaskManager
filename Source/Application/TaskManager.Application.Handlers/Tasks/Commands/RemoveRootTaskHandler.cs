using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Tasks.Commands.RemoveRootTask;

namespace TaskManager.Application.Handlers.Tasks.Commands;

public class RemoveRootTaskHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public RemoveRootTaskHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        RootTask rootTask = await _context.RootTasks.GetEntityByIdAsync(request.RootTaskId, cancellationToken);

        _context.RootTasks.Remove(rootTask);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response();
    }
}