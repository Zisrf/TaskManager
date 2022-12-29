namespace TaskManager.Common.Exceptions;

public abstract class TaskManagerDomainException : Exception
{
    protected TaskManagerDomainException(string message)
        : base(message) { }
}