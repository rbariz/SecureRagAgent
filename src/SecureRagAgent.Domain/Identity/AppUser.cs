using SecureRagAgent.Common;

namespace SecureRagAgent.Identity;

public sealed class AppUser : Entity
{
    private AppUser() { }

    public AppUser(string email, string displayName)
    {
        Email = email;
        DisplayName = displayName;
        IsActive = true;
    }

    public string Email { get; private set; } = default!;
    public string DisplayName { get; private set; } = default!;
    public bool IsActive { get; private set; }
}
