using MediatR;

namespace TaskManager.Application.Contracts.Tasks.Commands;

public static class RemoveRootTask
{
    public record Command(Guid RootTaskId) : IRequest<Response>;

    public record Response;
}