using MediatR;
using TaskManager.Application.Dto.Groups;

namespace TaskManager.Application.Contracts.Groups.Queries;

public static class GetTaskGroupById
{
    public record Query(Guid TaskGroupId) : IRequest<Response>;

    public record Response(TaskGroupDto TaskGroup);
}