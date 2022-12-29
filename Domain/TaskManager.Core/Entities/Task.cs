using RichEntity.Annotations;
using TaskManager.Common.Exceptions.Entities;
using TaskManager.Core.Models;

namespace TaskManager.Core.Entities;

public partial class Task : IEntity<Guid>
{
    private readonly HashSet<Task> _subtasks;

    public Task(string info, DateTime? deadline = null)
        : this(Guid.NewGuid())
    {
        State = TaskState.Created;

        Info = info;
        Deadline = deadline;

        _subtasks = new HashSet<Task>();
    }

    public string Info { get; set; }
    public DateTime? Deadline { get; set; }
    public TaskState State { get; private set; }

    public virtual IReadOnlyCollection<Task> Subtasks => _subtasks;

    public void Complete()
    {
        if (State is TaskState.Completed)
            throw InvalidTaskOperationException.OnRepeatedCompleing(Id);

        if (_subtasks.Any(s => s.State is not TaskState.Completed))
            throw InvalidTaskOperationException.OnCompleteingWithIncompletedSubtasks(Id);

        State = TaskState.Completed;
    }

    public Task CreateSubtask(string info, DateTime? deadline = null)
    {
        var newSubtask = new Task(info, deadline);

        _subtasks.Add(newSubtask);

        return newSubtask;
    }

    public void RemoveSubtask(Task subtask)
    {
        if (!_subtasks.Remove(subtask))
            throw InvalidTaskOperationException.OnRemoveNonExistentSubtask(Id, subtask.Id);
    }
}