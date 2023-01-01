using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts.Commands;
using TaskManager.Application.Contracts.Queries;
using TaskManager.Application.Dto.Tasks;

namespace TaskManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create-root-task")]
    public async Task<ActionResult<RootTaskDto>> CreateRootTask(string info, DateTime? deadline = null)
    {
        var command = new CreateRootTask.Command(info, deadline);
        var response = await _mediator.Send(command);

        return Ok(response.RootTask);
    }

    [HttpPost("create-subtask")]
    public async Task<ActionResult<RootTaskDto>> CreateRootTask(Guid rootTaskId, string info)
    {
        var command = new CreateSubtask.Command(rootTaskId, info);
        var response = await _mediator.Send(command);

        return Ok(response.Subtask);
    }

    [HttpPut("complete-task")]
    public async Task<ActionResult> CompleteTask(Guid taskId)
    {
        var command = new CompleteTask.Command(taskId);
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("get-tasks")]
    public async Task<ActionResult<IReadOnlyCollection<RootTaskDto>>> GetRootTasks()
    {
        var query = new GetRootTasks.Query();
        var response = await _mediator.Send(query);

        return Ok(response.RootTasks);
    }
}