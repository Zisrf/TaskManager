using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Abstractions.DataAccess;
using TaskManager.Application.Dto.Tasks;
using TaskManager.Application.Mapping;
using static TaskManager.Application.Contracts.Queries.GetRootTasks;

namespace TaskManager.Application.Handlers.Queries;

public class GetRootTasksHandler : IRequestHandler<Query, Response>
{
    private readonly ITaskManagerDatabaseContext _context;

    public GetRootTasksHandler(ITaskManagerDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        List<RootTaskDto> rootTasks = await _context.RootTasks
            .Select(r => r.AsDto())
            .ToListAsync(cancellationToken);

        return new Response(rootTasks);
    }
}