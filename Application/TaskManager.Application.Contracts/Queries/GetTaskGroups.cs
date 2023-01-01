﻿using MediatR;
using TaskManager.Application.Dto.Groups;

namespace TaskManager.Application.Contracts.Queries;

public static class GetTaskGroups
{
    public record Query : IRequest<Response>;

    public record Response(IReadOnlyCollection<TaskGroupDto> TaskGroups);
}