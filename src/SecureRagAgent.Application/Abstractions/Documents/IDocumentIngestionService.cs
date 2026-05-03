namespace SecureRagAgent.Application.Abstractions.Documents
{
    public interface IDocumentIngestionService
    {
        Task<Guid> IngestAsync(
            DocumentUploadRequest request,
            CancellationToken cancellationToken);
    }
}
