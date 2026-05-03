using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Options
{
    public sealed class AiOptions
    {
        public const string SectionName = "Ai";

        public string Provider { get; set; } = "OpenAI";
        public string ChatModel { get; set; } = "gpt-4.1-mini";
        public string EmbeddingModel { get; set; } = "text-embedding-3-small";
    }

}
