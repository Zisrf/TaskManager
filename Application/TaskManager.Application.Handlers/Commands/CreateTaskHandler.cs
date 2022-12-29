using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Mapping;
using static TaskManager.Application.Contracts.CreateTask;
using Task = TaskManager.Core.Entities.Task;

namespace TaskManager.Application.Handlers.Commands;

public class CreateTaskHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public CreateTaskHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var newTask = new Task(request.Info, request.Deadline);

        _context.Tasks.Add(newTask);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(newTask.AsDto());
    }
}