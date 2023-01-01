using RichEntity.Annotations;
using TaskManager.Common.Exceptions.Entities;
using TaskManager.Core.Tasks;

namespace TaskManager.Core.Groups;

public partial class TaskGroup : IEntity<Guid>
{
    private readonly HashSet<RootTask> _tasks = new();

    public TaskGroup(string name)
        : this(Guid.NewGuid())
    {
        Name = name;
    }

    public string Name { get; set; }
    public virtual IReadOnlyCollection<RootTask> Tasks => _tasks;

    public void AddTask(RootTask task)
    {
        if (!_tasks.Add(task))
            throw InvalidTaskGroupOperationException.OnAddExistingTask(Id, task.Id);
    }

    public void RemoveTask(RootTask task)
    {
        if (!_tasks.Remove(task))
            throw InvalidTaskGroupOperationException.OnRemoveNonExistentTask(Id, task.Id);
    }
}