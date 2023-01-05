using MediatR;

namespace TaskManager.Application.Contracts.Tasks.Commands;

public static class RemoveTask
{
    public record Command(Guid TaskId) : IRequest<Response>;

    public record Response;
}