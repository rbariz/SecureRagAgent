using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Monitoring
{
    public sealed record RagQueryLogRequest(
    Guid UserId,
    string Question,
    string Provider,
    string Model);
}
