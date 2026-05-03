namespace SecureRagAgent.Application.Abstractions.Ai
{
    public sealed record EmbeddingResponse(
    IReadOnlyList<float> Vector,
    string Provider,
    string Model);
}
