using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Documents
{
    public sealed record DocumentUploadRequest(
    string Title,
    string SourceName,
    string ContentType,
    Stream Content,
    IReadOnlyCollection<string> AllowedRoleCodes);
}
