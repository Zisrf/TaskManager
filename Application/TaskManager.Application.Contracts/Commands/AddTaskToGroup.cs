using MediatR;

namespace TaskManager.Application.Contracts.Commands;

public static class AddTaskToGroup
{
    public record Command(Guid RootTaskId, Guid TaskGroupId) : IRequest<Response>;

    public record Response;
}