namespace SecureRagAgent.Application.Abstractions.Retrieval
{
    public interface IRetrievalService
    {
        Task<IReadOnlyList<RetrievedChunk>> SearchAuthorizedChunksAsync(
            RetrievalSearchRequest request,
            CancellationToken cancellationToken);
    }
}
