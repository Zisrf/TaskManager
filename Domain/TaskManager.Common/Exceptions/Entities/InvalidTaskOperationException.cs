namespace TaskManager.Common.Exceptions.Entities;

public class InvalidTaskOperationException : TaskManagerDomainException
{
    private InvalidTaskOperationException(string message)
        : base(message) { }

    public static InvalidTaskOperationException OnRepeatedCompleing(Guid taskId)
    {
        return new InvalidTaskOperationException($"Task {taskId} is already completed");
    }

    public static InvalidTaskOperationException OnCompleteingWithIncompletedSubtasks(Guid taskId)
    {
        return new InvalidTaskOperationException($"Task {taskId} has incompleted subtasks");
    }

    public static InvalidTaskOperationException OnRemoveNonExistentSubtask(Guid taskId, Guid subtaskId)
    {
        return new InvalidTaskOperationException($"Task {taskId} doesn't contains subtask {subtaskId}");
    }
}