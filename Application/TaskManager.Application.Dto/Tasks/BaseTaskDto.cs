namespace TaskManager.Application.Dto.Tasks;

public abstract record BaseTaskDto(Guid Id, string Info, string State);