using SecureRagAgent.Common;

namespace SecureRagAgent.Domain.chat;

public sealed class ChatSession : Entity
{
    private ChatSession() { }

    public ChatSession(Guid userId, string title)
    {
        UserId = userId;
        Title = title;
    }

    public Guid UserId { get; private set; }
    public string Title { get; private set; } = default!;
}
