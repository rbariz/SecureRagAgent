namespace SecureRagAgent.Contracts.Common;

public static class EnumKeyExtensions
{
    public static string ToI18nKey(this Enum value)
    {
        return $"{value.GetType().Name}.{value}";
    }
}
