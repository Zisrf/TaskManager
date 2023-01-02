using MediatR;

namespace TaskManager.Application.Contracts.Commands;

public static class CompleteTask
{
    public record Command(Guid TaskId) : IRequest<Response>;

    public record Response;
}