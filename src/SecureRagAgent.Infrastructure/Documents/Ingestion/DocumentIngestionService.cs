using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pgvector;
using SecureRagAgent.Application.Abstractions.Ai;
using SecureRagAgent.Application.Abstractions.Documents;
using SecureRagAgent.Application.Options;
using SecureRagAgent.Documents;
using SecureRagAgent.Infrastructure.Documents.Chunking;
using SecureRagAgent.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Infrastructure.Documents.Ingestion
{
    public sealed class DocumentIngestionService : IDocumentIngestionService
    {
        private readonly SecureRagAgentDbContext _db;
        private readonly IEmbeddingProvider _embeddingProvider;
        private readonly AiOptions _aiOptions;

        public DocumentIngestionService(
            SecureRagAgentDbContext db,
            IEmbeddingProvider embeddingProvider,
             IOptions<AiOptions> aiOptions)
        {
            _db = db;
            _embeddingProvider = embeddingProvider;
            _aiOptions = aiOptions.Value;
        }

        public async Task<Guid> IngestAsync(
            DocumentUploadRequest request,
            CancellationToken ct)
        {
            // 1. Lire contenu texte (MVP)
            using var reader = new StreamReader(request.Content);
            var text = await reader.ReadToEndAsync(ct);

            // 2. Créer document
            var document = new Document(
                request.Title,
                request.SourceName,
                request.ContentType,
                DocumentVisibility.Internal);

            _db.Documents.Add(document);

            // 3. Permissions
            var roles = await _db.Roles
                .Where(r => request.AllowedRoleCodes.Contains(r.Code))
                .ToListAsync(ct);

            foreach (var role in roles)
            {
                _db.DocumentPermissions.Add(
                    new DocumentPermission(document.Id, role.Id));
            }

            // 4. Chunking
            var chunks = TextChunker.Split(text);

            int index = 0;

            foreach (var chunkText in chunks)
            {
                // 5. Embedding
                //var embedding = await _embeddingProvider.EmbedAsync(
                //    new EmbeddingRequest(chunkText, "text-embedding-3-small"),
                //    ct);

                var embedding = await _embeddingProvider.EmbedAsync(
                        new EmbeddingRequest(chunkText, _aiOptions.EmbeddingModel),
                        ct);

                var chunk = new DocumentChunk(
                    document.Id,
                    index++,
                    chunkText,
                    null);

                _db.DocumentChunks.Add(chunk);

                // 6. Shadow property (embedding)
                _db.Entry(chunk)
                    .Property("Embedding")
                    .CurrentValue = new Vector(embedding.Vector.ToArray());
            }

            document.MarkIndexed();

            await _db.SaveChangesAsync(ct);

            return document.Id;
        }
    }
}
