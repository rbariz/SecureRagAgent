namespace SecureRagAgent.Application.Abstractions.Guardrails
{
    public interface IGuardrailService
    {
        Task<GuardrailCheckResult> CheckInputAsync(
            GuardrailCheckRequest request,
            CancellationToken cancellationToken);

        Task<GuardrailCheckResult> CheckOutputAsync(
            GuardrailCheckRequest request,
            CancellationToken cancellationToken);
    }
}
