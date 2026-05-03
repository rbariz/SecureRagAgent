namespace SecureRagAgent.Application.Abstractions.Monitoring
{
    public interface IRagQueryLogger
    {
        Task<Guid> StartAsync(
            RagQueryLogRequest request,
            CancellationToken cancellationToken);

        Task CompleteAsync(
            Guid ragQueryId,
            int inputTokens,
            int outputTokens,
            decimal estimatedCostUsd,
            int latencyMs,
            CancellationToken cancellationToken);

        Task FailAsync(
            Guid ragQueryId,
            CancellationToken cancellationToken);
    }
}
