using TaskManager.Application.Dto.Groups;
using TaskManager.Core.Groups;

namespace TaskManager.Application.Mapping;

public static class GroupsMapping
{
    public static TaskGroupDto AsDto(this TaskGroup taskGroup)
    {
        return new TaskGroupDto(
            taskGroup.Id,
            taskGroup.Name,
            taskGroup.Tasks.Select(t => t.AsDto()).ToList());
    }
}