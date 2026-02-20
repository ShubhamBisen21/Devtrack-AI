using DevTrackAI.Api.DTOs;

namespace DevTrackAI.Api.Services;

public interface ITaskService
{
    Task<IReadOnlyList<TaskResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<TaskResponse> CreateAsync(CreateTaskRequest request, CancellationToken cancellationToken);
}
