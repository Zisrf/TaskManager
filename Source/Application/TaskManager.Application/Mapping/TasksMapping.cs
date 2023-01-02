using TaskManager.Application.Dto.Tasks;
using TaskManager.Core.Tasks;

namespace TaskManager.Application.Mapping;

public static class TasksMapping
{
    public static SubtaskDto AsDto(this Subtask subtask)
    {
        return new SubtaskDto(
            subtask.Id,
            subtask.Info,
            subtask.State.ToString());
    }

    public static RootTaskDto AsDto(this RootTask rootTask)
    {
        return new RootTaskDto(
            rootTask.Id,
            rootTask.Info,
            rootTask.State.ToString(),
            rootTask.Deadline,
            rootTask.Subtasks.Select(s => s.AsDto()).ToList());
    }
}