using SecureRagAgent.Common;

namespace SecureRagAgent.Monitoring;

public sealed class RagQuery : Entity
{
    private RagQuery() { }

    public RagQuery(
        Guid userId,
        string question,
        string provider,
        string model)
    {
        UserId = userId;
        Question = question;
        Provider = provider;
        Model = model;
        Status = RagQueryStatus.Started;
    }

    public Guid UserId { get; private set; }
    public string Question { get; private set; } = default!;
    public string Provider { get; private set; } = default!;
    public string Model { get; private set; } = default!;
    public RagQueryStatus Status { get; private set; }

    public int? InputTokens { get; private set; }
    public int? OutputTokens { get; private set; }
    public decimal? EstimatedCostUsd { get; private set; }
    public int? LatencyMs { get; private set; }

    public void Complete(int inputTokens, int outputTokens, decimal estimatedCostUsd, int latencyMs)
    {
        Status = RagQueryStatus.Completed;
        InputTokens = inputTokens;
        OutputTokens = outputTokens;
        EstimatedCostUsd = estimatedCostUsd;
        LatencyMs = latencyMs;
        MarkUpdated();
    }

    public void Fail()
    {
        Status = RagQueryStatus.Failed;
        MarkUpdated();
    }
}
