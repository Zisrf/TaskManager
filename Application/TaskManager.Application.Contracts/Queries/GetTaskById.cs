using MediatR;
using TaskManager.Application.Dto.Entities;

namespace TaskManager.Application.Contracts.Queries;

public static class GetTaskById
{
    public record Query(Guid TaskId) : IRequest<Response>;

    public record Response(TaskDto Task);
}