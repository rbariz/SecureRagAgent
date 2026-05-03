namespace SecureRagAgent.Application.Abstractions.Ai
{
    public sealed record EmbeddingRequest(
    string Text,
    string Model);
}
