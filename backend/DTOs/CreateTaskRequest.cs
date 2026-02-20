namespace DevTrackAI.Api.DTOs;

public sealed class CreateTaskRequest
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}
