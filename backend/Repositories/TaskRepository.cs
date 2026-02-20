using DevTrackAI.Api.Data;
using DevTrackAI.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTrackAI.Api.Repositories;

public sealed class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<TaskItem>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.TaskItems
            .OrderByDescending(t => t.CreatedAtUtc)
            .ToListAsync(cancellationToken);
    }

    public async Task<TaskItem> AddAsync(TaskItem taskItem, CancellationToken cancellationToken)
    {
        await _dbContext.TaskItems.AddAsync(taskItem, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return taskItem;
    }
}
