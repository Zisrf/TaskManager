using RichEntity.Annotations;
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

    public abstract void Complete();
}