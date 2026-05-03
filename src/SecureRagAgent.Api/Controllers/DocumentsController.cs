using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureRagAgent.Application.Abstractions.Documents;

namespace SecureRagAgent.Api.Controllers
{

    [ApiController]
    [Route("api/documents")]
    public sealed class DocumentsController : ControllerBase
    {
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(
            [FromServices] IDocumentIngestionService ingestion,
            [FromForm] UploadDocumentForm form,
            CancellationToken ct)
        {
            if (form.File is null || form.File.Length == 0)
            {
                return BadRequest("File is empty.");
            }

            await using var stream = form.File.OpenReadStream();

            var id = await ingestion.IngestAsync(
                new DocumentUploadRequest(
                    Title: form.File.FileName,
                    SourceName: form.File.FileName,
                    ContentType: form.File.ContentType,
                    Content: stream,
                    AllowedRoleCodes: new[] { "ADMIN" }),
                ct);

            return Ok(new { documentId = id });
        }
    }
}
