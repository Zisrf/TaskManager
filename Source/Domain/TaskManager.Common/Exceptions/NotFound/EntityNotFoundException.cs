namespace TaskManager.Common.Exceptions.NotFound;

public class EntityNotFoundException<T> : TaskManagerDomainException
{
    public EntityNotFoundException(Guid id)
        : base($"{typeof(T).Name} with id {id} wasn't found") { }
}