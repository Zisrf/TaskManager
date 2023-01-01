using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts.Commands;
using TaskManager.Application.Contracts.Queries;
using TaskManager.Application.Dto.Groups;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create-group")]
    public async Task<ActionResult<TaskGroupDto>> CreateTaskGroup(string name)
    {
        var command = new CreateTaskGroup.Command(name);
        var response = await _mediator.Send(command);

        return Ok(response.TaskGroup);
    }

    [HttpGet("get-groups")]
    public async Task<ActionResult<RootTaskDto>> GetTaskGroups()
    {
        var command = new GetTaskGroups.Query();
        var response = await _mediator.Send(command);

        return Ok(response.TaskGroups);
    }
}