namespace SecureRagAgent.Application.Abstractions.Monitoring
{
    public interface ICostEstimator
    {
        decimal EstimateUsd(
            string provider,
            string model,
            int inputTokens,
            int outputTokens);
    }
}
