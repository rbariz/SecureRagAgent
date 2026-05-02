using SecureRagAgent.Common;

namespace SecureRagAgent.Documents;

public sealed class DocumentPermission : Entity
{
    private DocumentPermission() { }

    public DocumentPermission(Guid documentId, Guid roleId)
    {
        DocumentId = documentId;
        RoleId = roleId;
    }

    public Guid DocumentId { get; private set; }
    public Guid RoleId { get; private set; }
}