using SecureRagAgent.Common;

namespace SecureRagAgent.Identity;

public sealed class AppRole : Entity
{
    private AppRole() { }

    public AppRole(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
}
