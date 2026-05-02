using SecureRagAgent.Common;

namespace SecureRagAgent.Documents;

public sealed class Document : Entity
{
    private Document() { }

    public Document(
        string title,
        string sourceName,
        string contentType,
        DocumentVisibility visibility)
    {
        Title = title;
        SourceName = sourceName;
        ContentType = contentType;
        Visibility = visibility;
        Status = DocumentStatus.PendingIngestion;
    }

    public string Title { get; private set; } = default!;
    public string SourceName { get; private set; } = default!;
    public string ContentType { get; private set; } = default!;
    public DocumentVisibility Visibility { get; private set; }
    public DocumentStatus Status { get; private set; }

    public void MarkIndexed()
    {
        Status = DocumentStatus.Indexed;
        MarkUpdated();
    }

    public void MarkFailed()
    {
        Status = DocumentStatus.Failed;
        MarkUpdated();
    }
}
