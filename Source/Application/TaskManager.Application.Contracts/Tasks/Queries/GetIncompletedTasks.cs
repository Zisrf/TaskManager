using MediatR;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.Application.Contracts.Tasks.Queries;

public static class GetIncompletedTasks
{
    public record Query : IRequest<Response>;

    public record Response(IReadOnlyCollection<RootTaskDto> RootTasks);
}