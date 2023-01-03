using MediatR;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.Application.Contracts.Tasks.Queries;

public static class GetTaskById
{
    public record Query(Guid TaskId) : IRequest<Response>;

    public record Response(BaseTaskDto Task);
}