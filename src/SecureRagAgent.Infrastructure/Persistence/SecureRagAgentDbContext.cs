using Microsoft.EntityFrameworkCore;
using SecureRagAgent.Documents;
using SecureRagAgent.Domain.chat;
using SecureRagAgent.Evaluations;
using SecureRagAgent.Guardrails;
using SecureRagAgent.Identity;
using SecureRagAgent.Monitoring;

namespace SecureRagAgent.Infrastructure.Persistence;

public sealed class SecureRagAgentDbContext : DbContext
{
    public SecureRagAgentDbContext(DbContextOptions<SecureRagAgentDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<AppRole> Roles => Set<AppRole>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<Document> Documents => Set<Document>();
    public DbSet<DocumentChunk> DocumentChunks => Set<DocumentChunk>();
    public DbSet<DocumentPermission> DocumentPermissions => Set<DocumentPermission>();

    public DbSet<ChatSession> ChatSessions => Set<ChatSession>();
    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

    public DbSet<RagQuery> RagQueries => Set<RagQuery>();
    public DbSet<GuardrailEvent> GuardrailEvents => Set<GuardrailEvent>();

    public DbSet<EvalCase> EvalCases => Set<EvalCase>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("vector");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SecureRagAgentDbContext).Assembly);
    }
}