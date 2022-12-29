using RichEntity.Annotations;
using TaskManager.Common.Exceptions.Entities;

namespace TaskManager.Core.Entities;

public partial class TaskGroup : IEntity<Guid>
{
    private readonly HashSet<Task> _tasks;

    public TaskGroup(string name)
        : this(Guid.NewGuid())
    {
        Name = name;

        _tasks = new HashSet<Task>();
    }

    public string Name { get; set; }

    public virtual IReadOnlyCollection<Task> Tasks => _tasks;

    public void AddTask(Task task)
    {
        if (!_tasks.Add(task))
            throw InvalidTaskGroupOperationException.OnAddExistingTask(Id, task.Id);
    }

    public void RemoveTask(Task task)
    {
        if (!_tasks.Remove(task))
            throw InvalidTaskGroupOperationException.OnRemoveNonExistentTask(Id, task.Id);
    }
}