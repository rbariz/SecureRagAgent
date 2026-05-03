using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pgvector;
using SecureRagAgent.Documents;

namespace SecureRagAgent.Infrastructure.Persistence.Configurations;

public sealed class DocumentChunkConfiguration : IEntityTypeConfiguration<DocumentChunk>
{
    public void Configure(EntityTypeBuilder<DocumentChunk> builder)
    {
        builder.ToTable("document_chunks");
        builder.ConfigureEntity();

        builder.Property(x => x.DocumentId)
            .HasColumnName("document_id")
            .IsRequired();

        builder.Property(x => x.ChunkIndex)
            .HasColumnName("chunk_index")
            .IsRequired();

        builder.Property(x => x.Content)
            .HasColumnName("content")
            .IsRequired();

        builder.Property(x => x.SectionTitle)
            .HasColumnName("section_title")
            .HasMaxLength(300);

        // Shadow property: keeps Domain independent from Pgvector.
        builder.Property<Vector>("Embedding")
            .HasColumnName("embedding")
            .HasColumnType("vector(768)");

        builder.HasIndex(x => new { x.DocumentId, x.ChunkIndex })
            .IsUnique();

        builder.HasIndex(x => x.DocumentId);
    }
}
