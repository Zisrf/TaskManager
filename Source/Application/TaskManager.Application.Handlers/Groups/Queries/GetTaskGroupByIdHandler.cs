using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Application.Mapping;
using TaskManager.Core.Groups;
using static TaskManager.Application.Contracts.Groups.Queries.GetTaskGroupById;

namespace TaskManager.Application.Handlers.Groups.Queries;

public class GetTaskGroupByIdHandler : IRequestHandler<Query, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public GetTaskGroupByIdHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        TaskGroup taskGroup = await _context.TaskGroups.GetEntityByIdAsync(request.TaskGroupId, cancellationToken);

        return new Response(taskGroup.AsDto());
    }
}