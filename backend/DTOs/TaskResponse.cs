namespace DevTrackAI.Api.DTOs;

public sealed class TaskResponse
{
    public decimal Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public DateTime CreatedAtUtc { get; init; }
}
