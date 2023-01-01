using RichEntity.Annotations;
using TaskManager.Common.Exceptions.Core;
using TaskManager.Core.Tasks;

namespace TaskManager.Core.Groups;

public partial class TaskGroup : IEntity<Guid>
{
    private readonly HashSet<RootTask> _rootTasks = new();

    public TaskGroup(string name)
        : this(Guid.NewGuid())
    {
        Name = name;
    }

    public string Name { get; set; }
    public virtual IReadOnlyCollection<RootTask> RootTasks => _rootTasks;

    public void AddTask(RootTask rootTask)
    {
        if (!_rootTasks.Add(rootTask))
            throw InvalidTaskGroupOperationException.OnAddExistingTask(Id, rootTask.Id);
    }

    public void RemoveTask(RootTask rootTask)
    {
        if (!_rootTasks.Remove(rootTask))
            throw InvalidTaskGroupOperationException.OnRemoveNonExistentTask(Id, rootTask.Id);
    }
}