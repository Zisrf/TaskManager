using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Application.Mapping;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Tasks.Commands.CreateSubtask;

namespace TaskManager.Application.Handlers.Tasks.Commands;

public class CreateSubtaskHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public CreateSubtaskHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        RootTask rootTask = await _context.RootTasks.GetEntityByIdAsync(request.RootTaskId, cancellationToken);

        Subtask newSubtask = rootTask.CreateSubtask(request.Info);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(newSubtask.AsDto());
    }
}
