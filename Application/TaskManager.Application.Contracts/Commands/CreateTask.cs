using MediatR;
using TaskManager.Application.Dto.Entities;

namespace TaskManager.Application.Contracts;

public static class CreateTask
{
    public record Command(string Info, DateTime? Deadline = null) : IRequest<Response>;

    public record Response(TaskDto Task);
}