using SecureRagAgent.Common;

namespace SecureRagAgent.Documents;

public sealed class DocumentChunk : Entity
{
    private DocumentChunk() { }

    public DocumentChunk(
        Guid documentId,
        int chunkIndex,
        string content,
        string? sectionTitle)
    {
        DocumentId = documentId;
        ChunkIndex = chunkIndex;
        Content = content;
        SectionTitle = sectionTitle;
    }

    public Guid DocumentId { get; private set; }
    public int ChunkIndex { get; private set; }
    public string Content { get; private set; } = default!;
    public string? SectionTitle { get; private set; }
}