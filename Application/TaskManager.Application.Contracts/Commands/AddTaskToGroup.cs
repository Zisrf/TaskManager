using MediatR;

namespace TaskManager.Application.Contracts.Commands;

public static class AddTaskToGroup
{
    public record Command(Guid TaskId, Guid GroupId) : IRequest<Response>;

    public record Response;
}