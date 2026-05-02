using SecureRagAgent.Common;

namespace SecureRagAgent.Evaluations;

public sealed class EvalCase : Entity
{
    private EvalCase() { }

    public EvalCase(
        string name,
        string question,
        string expectedAnswer,
        string requiredRoleCode)
    {
        Name = name;
        Question = question;
        ExpectedAnswer = expectedAnswer;
        RequiredRoleCode = requiredRoleCode;
        IsActive = true;
    }

    public string Name { get; private set; } = default!;
    public string Question { get; private set; } = default!;
    public string ExpectedAnswer { get; private set; } = default!;
    public string RequiredRoleCode { get; private set; } = default!;
    public bool IsActive { get; private set; }
}
