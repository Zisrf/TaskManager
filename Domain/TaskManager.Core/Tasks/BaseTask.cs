using RichEntity.Annotations;
using TaskManager.Common.Exceptions.Core;
using TaskManager.Core.Models;

namespace TaskManager.Core.Tasks;

public abstract partial class BaseTask : IEntity<Guid>
{
    public BaseTask(string info)
        : this(Guid.NewGuid())
    {
        State = TaskState.Created;

        Info = info;
    }

    public string Info { get; set; }
    public TaskState State { get; protected set; }

    public virtual void Complete()
    {
        if (State is TaskState.Completed)
            throw InvalidTaskOperationException.OnRepeatedCompleing(Id);

        State = TaskState.Completed;
    }
}