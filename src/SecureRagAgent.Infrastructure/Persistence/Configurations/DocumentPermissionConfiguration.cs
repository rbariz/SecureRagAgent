using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureRagAgent.Documents;

namespace SecureRagAgent.Infrastructure.Persistence.Configurations;

public sealed class DocumentPermissionConfiguration : IEntityTypeConfiguration<DocumentPermission>
{
    public void Configure(EntityTypeBuilder<DocumentPermission> builder)
    {
        builder.ToTable("document_permissions");
        builder.ConfigureEntity();

        builder.Property(x => x.DocumentId)
            .HasColumnName("document_id")
            .IsRequired();

        builder.Property(x => x.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        builder.HasIndex(x => new { x.DocumentId, x.RoleId })
            .IsUnique();

        builder.HasIndex(x => x.RoleId);
    }
}
