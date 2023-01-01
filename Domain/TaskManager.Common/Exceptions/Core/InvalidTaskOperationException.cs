namespace TaskManager.Common.Exceptions.Core;

public class InvalidTaskOperationException : TaskManagerDomainException
{
    private InvalidTaskOperationException(string message)
        : base(message) { }

    public static InvalidTaskOperationException OnRepeatedCompleing(Guid taskId)
    {
        return new InvalidTaskOperationException($"Task {taskId} is already completed");
    }

    public static InvalidTaskOperationException OnCompleteWithIncompletedSubtasks(Guid taskId)
    {
        return new InvalidTaskOperationException($"Task {taskId} has incompleted subtasks");
    }

    public static InvalidTaskOperationException OnAddSubtaskToCompletedTask(Guid taskId)
    {
        return new InvalidTaskOperationException($"Unable to create subtask, task {taskId} is completed");
    }

    public static InvalidTaskOperationException OnRemoveNonExistentSubtask(Guid taskId, Guid subtaskId)
    {
        return new InvalidTaskOperationException($"Task {taskId} doesn't contains subtask {subtaskId}");
    }
}