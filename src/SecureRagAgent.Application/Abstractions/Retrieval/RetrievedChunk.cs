namespace SecureRagAgent.Application.Abstractions.Retrieval
{
    public sealed record RetrievedChunk(
    Guid ChunkId,
    Guid DocumentId,
    string DocumentTitle,
    string Content,
    string? SectionTitle,
    double Score);
}
