using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureRagAgent.Evaluations;

namespace SecureRagAgent.Infrastructure.Persistence.Configurations;

public sealed class EvalCaseConfiguration : IEntityTypeConfiguration<EvalCase>
{
    public void Configure(EntityTypeBuilder<EvalCase> builder)
    {
        builder.ToTable("eval_cases");
        builder.ConfigureEntity();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Question)
            .HasColumnName("question")
            .IsRequired();

        builder.Property(x => x.ExpectedAnswer)
            .HasColumnName("expected_answer")
            .IsRequired();

        builder.Property(x => x.RequiredRoleCode)
            .HasColumnName("required_role_code")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.HasIndex(x => x.RequiredRoleCode);
        builder.HasIndex(x => x.IsActive);
    }
}