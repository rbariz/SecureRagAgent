using SecureRagAgent.Application.Abstractions.Ai;
using System.Net.Http.Json;

namespace SecureRagAgent.Infrastructure.Ai.Ollama
{
    public sealed class OllamaEmbeddingProvider : IEmbeddingProvider
    {
        private readonly HttpClient _http;

        public OllamaEmbeddingProvider(HttpClient http)
        {
            _http = http;
        }

        public async Task<EmbeddingResponse> EmbedAsync(
            EmbeddingRequest request,
            CancellationToken cancellationToken)
        {
            var payload = new
            {
                model = request.Model,
                prompt = request.Text
            };

            var response = await _http.PostAsJsonAsync("/api/embeddings", payload, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OllamaEmbeddingResponse>(cancellationToken);

            return new EmbeddingResponse(
                result!.embedding,
                "Ollama",
                request.Model);
        }

        private sealed class OllamaEmbeddingResponse
        {
            public float[] embedding { get; set; } = default!;
        }
    }
}
