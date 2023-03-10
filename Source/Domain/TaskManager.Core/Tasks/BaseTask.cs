using RichEntity.Annotations;
using TaskManager.Core.Models;

namespace TaskManager.Core.Tasks;

public abstract partial class BaseTask : IEntity<Guid>
{
    protected BaseTask(string info)
        : this(Guid.NewGuid())
    {
        State = TaskState.InProgress;

        Info = info;
    }

    public string Info { get; set; }
    public TaskState State { get; protected set; }

    public abstract void Complete();
}