namespace SecureRagAgent.Application.Abstractions.Ai
{
    public sealed record LlmChatResponse(
    string Content,
    int? InputTokens,
    int? OutputTokens,
    string Provider,
    string Model);
}
