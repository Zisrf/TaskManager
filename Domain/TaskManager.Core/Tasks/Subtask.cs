using TaskManager.Common.Exceptions.Entities;

namespace TaskManager.Core.Tasks;

public partial class Subtask : BaseTask
{
    public Subtask(RootTask rootTask, string info)
        : base(info)
    {
        RootTask = rootTask;
    }

    public virtual RootTask RootTask { get; protected init; }
}