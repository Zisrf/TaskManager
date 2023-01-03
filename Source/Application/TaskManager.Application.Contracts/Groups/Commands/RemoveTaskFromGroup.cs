using MediatR;

namespace TaskManager.Application.Contracts.Groups.Commands;

public static class RemoveTaskFromGroup
{
    public record Command(Guid TaskGroupId, Guid RootTaskId) : IRequest<Response>;

    public record Response;
}