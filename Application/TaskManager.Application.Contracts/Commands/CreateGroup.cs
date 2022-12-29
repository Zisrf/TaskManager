using MediatR;
using TaskManager.Application.Dto.Entities;

namespace TaskManager.Application.Contracts.Commands;

public static class CreateGroup
{
    public record Command(string Name) : IRequest<Response>;

    public record Response(TaskGroupDto Group);
}