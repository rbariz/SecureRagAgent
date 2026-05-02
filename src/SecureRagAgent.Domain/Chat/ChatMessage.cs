using SecureRagAgent.Common;

namespace SecureRagAgent.Domain.chat;

public sealed class ChatMessage : Entity
{
    private ChatMessage() { }

    public ChatMessage(Guid sessionId, ChatMessageRole role, string content)
    {
        SessionId = sessionId;
        Role = role;
        Content = content;
    }

    public Guid SessionId { get; private set; }
    public ChatMessageRole Role { get; private set; }
    public string Content { get; private set; } = default!;
}
