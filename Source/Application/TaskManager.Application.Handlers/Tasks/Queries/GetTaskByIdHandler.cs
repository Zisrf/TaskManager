using MediatR;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Extensions;
using TaskManager.Application.Mapping;
using TaskManager.Core.Tasks;
using static TaskManager.Application.Contracts.Tasks.Queries.GetTaskById;

namespace TaskManager.Application.Handlers.Tasks.Queries;

public class GetTaskByIdHandler : IRequestHandler<Query, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public GetTaskByIdHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        BaseTask baseTask = await _context.AllTasks.GetEntityByIdAsync(request.TaskId, cancellationToken);

        return new Response(baseTask.AsDto());
    }
}