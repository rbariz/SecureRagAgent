namespace SecureRagAgent.Guardrails;

public enum GuardrailType
{
    OutOfScope = 0,
    PiiDetected = 1,
    PromptInjection = 2,
    NoRelevantSources = 3,
    SensitiveOutput = 4
}

