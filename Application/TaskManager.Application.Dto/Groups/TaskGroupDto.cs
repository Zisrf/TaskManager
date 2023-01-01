using TaskManager.Application.Dto.Tasks;

namespace TaskManager.Application.Dto.Groups;

public record TaskGroupDto(Guid Id, string Name, IReadOnlyCollection<RootTaskDto> Tasks);