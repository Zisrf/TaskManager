using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts.Commands;
using TaskManager.Application.Contracts.Queries;
using TaskManager.Application.Dto.Groups;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("create-group")]
    public async Task<ActionResult<TaskGroupDto>> CreateTaskGroup(string name)
    {
        var command = new CreateTaskGroup.Command(name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.TaskGroup);
    }

    [HttpPut("add-task")]
    public async Task<ActionResult> AddTaskToGroup(Guid rootTaskId, Guid taskGroupId)
    {
        var command = new AddTaskToGroup.Command(rootTaskId, taskGroupId);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpGet("get-groups")]
    public async Task<ActionResult<RootTaskDto>> GetTaskGroups()
    {
        var command = new GetTaskGroups.Query();
        var response = await _mediator.Send(command);

        return Ok(response.TaskGroups);
    }
}