using OpenAI.Chat;
using SecureRagAgent.Application.Abstractions.Ai;

namespace SecureRagAgent.Infrastructure.Ai.OpenAI
{

    public sealed class OpenAiLlmProvider : ILlmProvider
    {
        private readonly string _apiKey;

        public OpenAiLlmProvider(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<LlmChatResponse> ChatAsync(
            LlmChatRequest request,
            CancellationToken cancellationToken)
        {
            var client = new ChatClient(request.Model, _apiKey);

            List<ChatMessage> messages = request.Messages
    .Select<LlmChatMessage, ChatMessage>(m => m.Role.ToLowerInvariant() switch
    {
        "user" => ChatMessage.CreateUserMessage(m.Content),
        "assistant" => ChatMessage.CreateAssistantMessage(m.Content),
        "system" => ChatMessage.CreateSystemMessage(m.Content),
        _ => ChatMessage.CreateUserMessage(m.Content)
    })
    .ToList();

            var response = await client.CompleteChatAsync(
                messages,
                cancellationToken: cancellationToken);

            return new LlmChatResponse(
                response.Value.Content[0].Text,
                response.Value.Usage?.InputTokenCount,
                response.Value.Usage?.OutputTokenCount,
                "OpenAI",
                request.Model);
        }
    }
}
