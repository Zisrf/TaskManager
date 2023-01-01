namespace TaskManager.Common.Exceptions.Core;

public class InvalidTaskGroupOperationException : TaskManagerDomainException
{
    private InvalidTaskGroupOperationException(string message)
        : base(message) { }

    public static InvalidTaskGroupOperationException OnAddExistingTask(Guid groupId, Guid taskId)
    {
        return new InvalidTaskGroupOperationException($"Group {groupId} already contains task {taskId}");
    }

    public static InvalidTaskGroupOperationException OnRemoveNonExistentTask(Guid groupId, Guid taskId)
    {
        return new InvalidTaskGroupOperationException($"Group {groupId} doesn't contain task {taskId}");
    }
}