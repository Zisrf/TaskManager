using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Mapping;
using static TaskManager.Application.Contracts.Groups.Queries.GetTaskGroups;

namespace TaskManager.Application.Handlers.Groups.Queries;

public class GetTaskGroupsHandler : IRequestHandler<Query, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public GetTaskGroupsHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var taskGroups = await _context.TaskGroups
            .Select(t => t.AsDto())
            .ToListAsync(cancellationToken);

        return new Response(taskGroups);
    }
}