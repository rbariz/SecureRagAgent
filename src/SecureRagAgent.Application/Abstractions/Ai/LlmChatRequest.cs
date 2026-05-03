namespace SecureRagAgent.Application.Abstractions.Ai
{
    public sealed record LlmChatRequest(
    IReadOnlyList<LlmChatMessage> Messages,
    string Model,
    double Temperature = 0.2,
    int? MaxOutputTokens = null);
}
