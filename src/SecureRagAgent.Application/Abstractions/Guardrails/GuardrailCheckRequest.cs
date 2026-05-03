using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Guardrails
{
    public sealed record GuardrailCheckRequest(
    Guid? RagQueryId,
    string Text,
    string Stage);
}
