using MediatR;
using TaskManager.Application.Dto.Entities;

namespace TaskManager.Application.Contracts;

public static class CreateSubtask
{
    public record Command(Guid TaskId, string Info, DateTime? Deadline = null) : IRequest<Response>;

    public record Response(TaskDto Task);
}