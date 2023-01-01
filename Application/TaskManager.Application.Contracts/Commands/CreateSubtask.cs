using MediatR;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.Application.Contracts.Commands;

public static class CreateSubtask
{
    public record Command(Guid RootTaskId, string Info) : IRequest<Response>;

    public record Response(SubtaskDto Subtask);
}