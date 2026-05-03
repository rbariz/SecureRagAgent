using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Retrieval
{
    public sealed record RetrievalSearchRequest(
    string Query,
    IReadOnlyCollection<string> RoleCodes,
    int TopK = 5);
}
