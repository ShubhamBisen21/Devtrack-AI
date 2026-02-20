using DevTrackAI.Api.DTOs;
using DevTrackAI.Api.Models;
using DevTrackAI.Api.Repositories;

namespace DevTrackAI.Api.Services;

public sealed class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IReadOnlyList<TaskResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAllAsync(cancellationToken);
        return tasks.Select(MapToResponse).ToList();
    }

    public async Task<TaskResponse> CreateAsync(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var taskItem = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            Status = "Open",
            CreatedAtUtc = DateTime.UtcNow
        };

        var created = await _taskRepository.AddAsync(taskItem, cancellationToken);
        return MapToResponse(created);
    }

    private static TaskResponse MapToResponse(TaskItem taskItem)
    {
        return new TaskResponse
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            Description = taskItem.Description,
            Status = taskItem.Status,
            CreatedAtUtc = taskItem.CreatedAtUtc
        };
    }
}
