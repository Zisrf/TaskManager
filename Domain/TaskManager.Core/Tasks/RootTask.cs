using TaskManager.Common.Exceptions.Entities;
using TaskManager.Core.Models;

namespace TaskManager.Core.Tasks;

public partial class RootTask : BaseTask
{
    private readonly HashSet<Subtask> _subtasks = new();

    public RootTask(string info, DateTime? deadline = null)
        : base(info)
    {
        Deadline = deadline;
    }

    public DateTime? Deadline { get; protected init; }
    public virtual IReadOnlyCollection<Subtask> Subtasks => _subtasks;

    public override void Complete()
    {
        if (State is TaskState.Completed)
            throw InvalidTaskOperationException.OnRepeatedCompleing(Id);

        if (_subtasks.Any(s => s.State is not TaskState.Completed))
            throw InvalidTaskOperationException.OnCompleteingWithIncompletedSubtasks(Id);

        State = TaskState.Completed;
    }

    public Subtask CreateSubtask(string info)
    {
        var newSubtask = new Subtask(this, info);

        _subtasks.Add(newSubtask);

        return newSubtask;
    }

    public void RemoveSubtask(Subtask subtask)
    {
        if (!_subtasks.Remove(subtask))
            throw InvalidTaskOperationException.OnRemoveNonExistentSubtask(Id, subtask.Id);
    }
}