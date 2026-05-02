using SecureRagAgent.Common;

namespace SecureRagAgent.Guardrails;

public sealed class GuardrailEvent : Entity
{
    private GuardrailEvent() { }

    public GuardrailEvent(
        Guid ragQueryId,
        GuardrailType type,
        GuardrailSeverity severity,
        string reason)
    {
        RagQueryId = ragQueryId;
        Type = type;
        Severity = severity;
        Reason = reason;
    }

    public Guid RagQueryId { get; private set; }
    public GuardrailType Type { get; private set; }
    public GuardrailSeverity Severity { get; private set; }
    public string Reason { get; private set; } = default!;
}

