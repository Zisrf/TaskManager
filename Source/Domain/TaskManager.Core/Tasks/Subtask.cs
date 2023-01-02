using TaskManager.Common.Exceptions.Core;
using TaskManager.Core.Models;

namespace TaskManager.Core.Tasks;

public partial class Subtask : BaseTask
{
    public Subtask(RootTask rootTask, string info)
        : base(info)
    {
        RootTask = rootTask;
    }

    public virtual RootTask RootTask { get; protected init; }

    public override void Complete()
    {
        if (State is TaskState.Completed)
            throw InvalidTaskOperationException.OnRepeatedCompleing(Id);

        State = TaskState.Completed;
    }
}