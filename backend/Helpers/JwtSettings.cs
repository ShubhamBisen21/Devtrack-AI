namespace DevTrackAI.Api.Helpers;

public sealed class JwtSettings
{
    public const string SectionName = "Jwt";

    public string Secret { get; init; } = "ReplaceThisWithASecure32CharOrLongerSecret!";
    public string Issuer { get; init; } = "DevTrackAI";
    public string Audience { get; init; } = "DevTrackAI.Client";
    public int ExpirationMinutes { get; init; } = 60;
}
