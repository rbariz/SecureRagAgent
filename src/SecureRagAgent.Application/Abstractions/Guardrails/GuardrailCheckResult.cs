namespace SecureRagAgent.Application.Abstractions.Guardrails
{
    public sealed record GuardrailCheckResult(
    bool IsAllowed,
    string? Reason,
    IReadOnlyList<string> Flags);
}
