namespace TaskManager.WebApi.Models.Tasks;

public record CreateRootTaskRequest(string Info, DateTime? Deadline = null);