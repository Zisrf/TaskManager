using MediatR;

namespace TaskManager.Application.Contracts.Groups.Commands;

public static class RemoveTaskGroup
{
    public record Command(Guid TaskGroupId) : IRequest<Response>;

    public record Response;
}