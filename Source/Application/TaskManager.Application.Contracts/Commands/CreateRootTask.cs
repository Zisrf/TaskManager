using MediatR;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.Application.Contracts.Commands;

public static class CreateRootTask
{
    public record Command(string Info, DateTime? Deadline = null) : IRequest<Response>;

    public record Response(RootTaskDto RootTask);
}