using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Dto.Tasks;
using TaskManager.Application.Mapping;
using TaskManager.Core.Models;
using static TaskManager.Application.Contracts.Tasks.Queries.GetIncompletedTasks;

namespace TaskManager.Application.Handlers.Tasks.Queries;

public class GetIncompletedTasksHandler : IRequestHandler<Query, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public GetIncompletedTasksHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        List<RootTaskDto> rootTasks = await _context.RootTasks
            .Where(r => r.State == TaskState.InProgress)
            .Select(r => new RootTaskDto(
                r.Id,
                r.Info,
                r.State.ToString(),
                r.Deadline,
                r.Subtasks
                    .Where(s => s.State == TaskState.InProgress)
                    .Select(s => s.AsDto())
                    .ToList()))
            .ToListAsync(cancellationToken);

        return new Response(rootTasks);
    }
}