namespace SecureRagAgent.Documents;

public enum DocumentStatus
{
    PendingIngestion = 0,
    Processing = 1,
    Indexed = 2,
    Failed = 3
}
