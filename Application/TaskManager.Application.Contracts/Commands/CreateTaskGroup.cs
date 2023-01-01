﻿using MediatR;
using TaskManager.Application.Dto.Groups;

namespace TaskManager.Application.Contracts.Commands;

public static class CreateTaskGroup
{
    public record Command(string Name) : IRequest<Response>;

    public record Response(TaskGroupDto TaskGroup);
}