using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts.Groups.Commands;
using TaskManager.Application.Contracts.Groups.Queries;
using TaskManager.Application.Dto.Groups;
using TaskManager.Application.Dto.Tasks;
using TaskManager.Core.Tasks;
using TaskManager.WebApi.Models.Groups;

namespace TaskManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<TaskGroupDto>>> Get()
    {
        var command = new GetTaskGroups.Query();
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.TaskGroups);
    }

    [HttpPost]
    public async Task<ActionResult<TaskGroupDto>> Create([FromBody] CreateTaskGroupRequest request)
    {
        var command = new CreateTaskGroup.Command(request.Name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.TaskGroup);
    }

    [HttpPut("{id:guid}/add-root-task")]
    public async Task<ActionResult> AddRootTask(Guid id, Guid rootTaskId)
    {
        var command = new AddTaskToGroup.Command(rootTaskId, id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpPut("{id:guid}/remove-root-task")]
    public async Task<ActionResult> RemoveRootTask(Guid id, Guid rootTaskId)
    {
        var command = new RemoveTaskFromGroup.Command(rootTaskId, id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new RemoveTaskGroup.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }
}