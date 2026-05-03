namespace SecureRagAgent.Application.Abstractions.Ai
{
    public interface IEmbeddingProvider
    {
        Task<EmbeddingResponse> EmbedAsync(
            EmbeddingRequest request,
            CancellationToken cancellationToken);
    }
}
