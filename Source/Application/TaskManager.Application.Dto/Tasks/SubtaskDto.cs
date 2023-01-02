namespace TaskManager.Application.Dto.Tasks;

public record SubtaskDto(Guid Id, string Info, string State)
    : BaseTaskDto(Id, Info, State);