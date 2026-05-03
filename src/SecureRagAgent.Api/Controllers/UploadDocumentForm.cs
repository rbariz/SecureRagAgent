namespace SecureRagAgent.Api.Controllers
{
    public sealed class UploadDocumentForm
    {
        public IFormFile File { get; set; } = default!;
    }
}
