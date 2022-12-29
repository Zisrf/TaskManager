using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Contracts;
using TaskManager.Application.Dto.Entities;

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

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(string info, DateTime? deadline = null)
    {
        var command = new CreateTask.Command(info, deadline);
        var response = await _mediator.Send(command);

        return Ok(response.Task);
    }
}