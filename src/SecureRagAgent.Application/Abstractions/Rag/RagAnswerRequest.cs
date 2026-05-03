namespace SecureRagAgent.Application.Abstractions.Rag
{
    public sealed record RagAnswerRequest(
    Guid UserId,
    string Question,
    int TopK = 5);
}
