namespace SecureRagAgent.Application.Abstractions.Rag
{
    public sealed record RagAnswerResponse(
    string Answer,
    IReadOnlyList<RagAnswerSource> Sources,
    bool IsBlocked,
    string? BlockReason);
}
