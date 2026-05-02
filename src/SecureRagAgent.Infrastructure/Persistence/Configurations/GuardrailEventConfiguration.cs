using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureRagAgent.Guardrails;

namespace SecureRagAgent.Infrastructure.Persistence.Configurations;

public sealed class GuardrailEventConfiguration : IEntityTypeConfiguration<GuardrailEvent>
{
    public void Configure(EntityTypeBuilder<GuardrailEvent> builder)
    {
        builder.ToTable("guardrail_events");
        builder.ConfigureEntity();

        builder.Property(x => x.RagQueryId)
            .HasColumnName("rag_query_id")
            .IsRequired();

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Severity)
            .HasColumnName("severity")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Reason)
            .HasColumnName("reason")
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasIndex(x => x.RagQueryId);
        builder.HasIndex(x => x.Type);
        builder.HasIndex(x => x.Severity);
    }
}
