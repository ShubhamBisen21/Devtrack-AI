using DevTrackAI.Api.Models;

namespace DevTrackAI.Api.Repositories;

public interface ITaskRepository
{
    Task<IReadOnlyList<TaskItem>> GetAllAsync(CancellationToken cancellationToken);
    Task<TaskItem> AddAsync(TaskItem taskItem, CancellationToken cancellationToken);
}
