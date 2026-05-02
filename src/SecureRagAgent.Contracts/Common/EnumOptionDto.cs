namespace SecureRagAgent.Contracts.Common;

public sealed class EnumOptionDto
{
    public required string Value { get; init; }
    public required int Code { get; init; }
    public required string I18nKey { get; init; }
}
