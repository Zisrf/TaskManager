using TaskManager.Application.Dto.Entities;
using TaskManager.Core.Entities;
using Task = TaskManager.Core.Entities.Task;

namespace TaskManager.Application.Mapping;

public static class EntitiesMapping
{
    public static TaskDto AsDto(this Task task)
    {
        return new TaskDto(task.Id, task.Info, task.Deadline);
    }

    public static TaskGroupDto AsDto(this TaskGroup group)
    {
        return new TaskGroupDto(group.Id, group.Name);
    }
}