using MediatR;
using TaskManager.Application.Dto.Entities;

namespace TaskManager.Application.Contracts.Queries;

public static class GetGroupById
{
    public record Query(Guid GroupId) : IRequest<Response>;

    public record Response(TaskGroupDto Group);
}