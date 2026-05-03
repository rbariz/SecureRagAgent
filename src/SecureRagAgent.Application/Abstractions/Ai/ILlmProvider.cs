namespace SecureRagAgent.Application.Abstractions.Ai
{
    public interface ILlmProvider
    {
        Task<LlmChatResponse> ChatAsync(
            LlmChatRequest request,
            CancellationToken cancellationToken);
    }
}
