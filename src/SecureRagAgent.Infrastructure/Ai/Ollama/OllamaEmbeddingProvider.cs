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
                input = request.Text
            };

            var response = await _http.PostAsJsonAsync(
                "/api/embed",
                payload,
                cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OllamaEmbedResponse>(
                cancellationToken);

            var vector = result?.Embeddings?.FirstOrDefault();

            if (vector is null || vector.Length == 0)
            {
                throw new InvalidOperationException("Ollama returned an empty embedding.");
            }

            return new EmbeddingResponse(
                vector,
                "Ollama",
                request.Model);
        }

        private sealed class OllamaEmbedResponse
        {
            public float[][] Embeddings { get; set; } = [];
        }
    }
}
