using Microsoft.Extensions.Configuration;
using SecureRagAgent.Application.Abstractions.Ai;
using SecureRagAgent.Infrastructure.Ai.Ollama;
using SecureRagAgent.Infrastructure.Ai.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Infrastructure.Ai.Factory
{
    public sealed class AiProviderFactory
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public AiProviderFactory(
            IConfiguration config,
            IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public ILlmProvider CreateLlm()
        {
            var provider = _config["Ai:Provider"];

            if (provider == "Ollama")
            {
                var http = _httpClientFactory.CreateClient("ollama");
                return new OllamaLlmProvider(http);
            }

            var apiKey = _config["Ai:OpenAI:ApiKey"]!;
            return new OpenAiLlmProvider(apiKey);
        }

        public IEmbeddingProvider CreateEmbedding()
        {
            var provider = _config["Ai:Provider"];

            if (provider == "Ollama")
            {
                var http = _httpClientFactory.CreateClient("ollama");
                return new OllamaEmbeddingProvider(http);
            }

            var apiKey = _config["Ai:OpenAI:ApiKey"]!;
            return new OpenAiEmbeddingProvider(apiKey);
        }
    }
}
