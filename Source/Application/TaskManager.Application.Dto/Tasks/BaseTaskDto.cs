namespace TaskManager.Application.Dto.Tasks;

public record BaseTaskDto(Guid Id, string Info, string State);