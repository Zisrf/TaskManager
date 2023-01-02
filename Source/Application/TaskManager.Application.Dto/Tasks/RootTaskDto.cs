namespace TaskManager.Application.Dto.Tasks;

public record RootTaskDto(Guid Id, string Info, string State, DateTime? Deadline, IReadOnlyCollection<SubtaskDto> Subtasks)
    : BaseTaskDto(Id, Info, State);