namespace SecureRagAgent.Application.Abstractions.Rag
{
    public interface IRagOrchestrator
    {
        Task<RagAnswerResponse> AnswerAsync(
            RagAnswerRequest request,
            CancellationToken cancellationToken);
    }
}
