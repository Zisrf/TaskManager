using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts.Tasks.Commands;
using TaskManager.Application.Contracts.Tasks.Queries;
using TaskManager.Application.Dto.Tasks;
using TaskManager.WebApi.Models.Tasks;

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

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("root-task")]
    public async Task<ActionResult<RootTaskDto>> CreateRootTask([FromBody] CreateRootTaskRequest request)
    {
        var command = new CreateRootTask.Command(request.Info, request.Deadline);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.RootTask);
    }

    [HttpPost("subtask")]
    public async Task<ActionResult<SubtaskDto>> CreateSubtask([FromBody] CreateSubtaskRequest request)
    {
        var command = new CreateSubtask.Command(request.RootTaskId, request.Info);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Subtask);
    }

    [HttpPut("{id:guid}/complete")]
    public async Task<ActionResult> CompleteTask(Guid id)
    {
        var command = new CompleteTask.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpGet("root-tasks")]
    public async Task<ActionResult<IReadOnlyCollection<RootTaskDto>>> GetRootTasks()
    {
        var query = new GetRootTasks.Query();
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.RootTasks);
    }

    [HttpGet("incompleted-tasks")]
    public async Task<ActionResult<IReadOnlyCollection<RootTaskDto>>> GetIncompletedTasks()
    {
        var query = new GetIncompletedTasks.Query();
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response.RootTasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseTaskDto>> GetById(Guid id)
    {
        var query = new GetTaskById.Query(id);
        var response = await _mediator.Send(query, CancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}/root-task")]
    public async Task<ActionResult> DeleteRootTask(Guid id)
    {
        var command = new RemoveRootTask.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }

    [HttpDelete("{id:guid}/subtask")]
    public async Task<ActionResult> DeleteSubtask(Guid id)
    {
        var command = new RemoveSubtask.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response);
    }
}