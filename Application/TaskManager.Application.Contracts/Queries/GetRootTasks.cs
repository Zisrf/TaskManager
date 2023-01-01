﻿using MediatR;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.Application.Contracts.Queries;

public static class GetRootTasks
{
    public record Query : IRequest<Response>;

    public record Response(IReadOnlyCollection<RootTaskDto> RootTasks);
}