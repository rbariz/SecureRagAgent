namespace SecureRagAgent.Monitoring;

public enum RagQueryStatus
{
    Started = 0,
    Completed = 1,
    BlockedByGuardrail = 2,
    Failed = 3
}
