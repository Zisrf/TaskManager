using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Mapping;
using TaskManager.Core.Groups;
using static TaskManager.Application.Contracts.Commands.CreateTaskGroup;

namespace TaskManager.Application.Handlers.Commands;

public class CreateTaskGroupHandler : IRequestHandler<Command, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public CreateTaskGroupHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var newTaskGroup = new TaskGroup(request.Name);

        _context.TaskGroups.Add(newTaskGroup);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(newTaskGroup.AsDto());
    }
}