namespace TaskManager.WebApi.Models.Tasks;

public record CreateSubtaskRequest(Guid RootTaskId, string Info);