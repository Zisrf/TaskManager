using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Mapping;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Commands.CreateRootTask;

namespace TaskManager.Application.Handlers.Commands;

public class CreateRootTaskHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public CreateRootTaskHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var newRootTask = new RootTask(request.Info, request.Deadline);

        _context.RootTasks.Add(newRootTask);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(newRootTask.AsDto());
    }
}