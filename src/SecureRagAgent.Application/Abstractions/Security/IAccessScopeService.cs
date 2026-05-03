namespace SecureRagAgent.Application.Abstractions.Security
{
    public interface IAccessScopeService
    {
        Task<UserAccessContext> GetUserAccessContextAsync(
            Guid userId,
            CancellationToken cancellationToken);
    }
}
