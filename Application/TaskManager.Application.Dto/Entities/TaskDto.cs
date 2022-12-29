namespace TaskManager.Application.Dto.Entities;

public record TaskDto(Guid Id, string Info, DateTime? Deadline);