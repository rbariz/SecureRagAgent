using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureRagAgent.Monitoring;

namespace SecureRagAgent.Infrastructure.Persistence.Configurations;

public sealed class RagQueryConfiguration : IEntityTypeConfiguration<RagQuery>
{
    public void Configure(EntityTypeBuilder<RagQuery> builder)
    {
        builder.ToTable("rag_queries");
        builder.ConfigureEntity();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(x => x.Question)
            .HasColumnName("question")
            .IsRequired();

        builder.Property(x => x.Provider)
            .HasColumnName("provider")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.Model)
            .HasColumnName("model")
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.InputTokens)
            .HasColumnName("input_tokens");

        builder.Property(x => x.OutputTokens)
            .HasColumnName("output_tokens");

        builder.Property(x => x.EstimatedCostUsd)
            .HasColumnName("estimated_cost_usd")
            .HasPrecision(18, 6);

        builder.Property(x => x.LatencyMs)
            .HasColumnName("latency_ms");

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.CreatedAtUtc);
    }
}
