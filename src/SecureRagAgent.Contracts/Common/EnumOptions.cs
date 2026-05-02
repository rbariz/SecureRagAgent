namespace SecureRagAgent.Contracts.Common;

public static class EnumOptions
{
    public static IReadOnlyList<EnumOptionDto> FromEnum<TEnum>()
        where TEnum : struct, Enum
    {
        return Enum.GetValues<TEnum>()
            .Select(value => new EnumOptionDto
            {
                Value = value.ToString(),
                Code = Convert.ToInt32(value),
                I18nKey = value.ToI18nKey()
            })
            .ToList();
    }
}
