using MediatR;

namespace TaskManager.Application.Contracts.Tasks.Commands;

public static class RemoveSubtask
{
    public record Command(Guid SubtaskId) : IRequest<Response>;

    public record Response;
}