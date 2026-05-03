using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Rag
{
    public sealed record RagAnswerSource(
    Guid DocumentId,
    Guid ChunkId,
    string DocumentTitle,
    string? SectionTitle,
    double Score);
}
