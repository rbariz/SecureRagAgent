using OpenAI.Embeddings;
using SecureRagAgent.Application.Abstractions.Ai;

namespace SecureRagAgent.Infrastructure.Ai.OpenAI
{
    public sealed class OpenAiEmbeddingProvider : IEmbeddingProvider
    {
        private readonly string _apiKey;

        public OpenAiEmbeddingProvider(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<EmbeddingResponse> EmbedAsync(
            EmbeddingRequest request,
            CancellationToken cancellationToken)
        {
            var client = new EmbeddingClient(request.Model, _apiKey);

            var response = await client.GenerateEmbeddingAsync(
                request.Text,
                cancellationToken: cancellationToken);

            var vector = response.Value.ToFloats().ToArray();

            return new EmbeddingResponse(
                vector,
                "OpenAI",
                request.Model);
        }
    }
}
