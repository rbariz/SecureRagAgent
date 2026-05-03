using SecureRagAgent.Application.Abstractions.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Infrastructure.Ai.Ollama
{
    public sealed class OllamaLlmProvider : ILlmProvider
    {
        private readonly HttpClient _http;

        public OllamaLlmProvider(HttpClient http)
        {
            _http = http;
        }

        public async Task<LlmChatResponse> ChatAsync(
            LlmChatRequest request,
            CancellationToken cancellationToken)
        {
            var payload = new
            {
                model = request.Model,
                messages = request.Messages
            };

            var response = await _http.PostAsJsonAsync("/api/chat", payload, cancellationToken);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OllamaChatResponse>(cancellationToken);

            return new LlmChatResponse(
                result!.message.content,
                null,
                null,
                "Ollama",
                request.Model);
        }

        private sealed class OllamaChatResponse
        {
            public Message message { get; set; } = default!;
        }

        private sealed class Message
        {
            public string content { get; set; } = default!;
        }
    }
}
