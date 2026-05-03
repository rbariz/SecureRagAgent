using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Security
{
    public sealed record UserAccessContext(
    Guid UserId,
    string Email,
    IReadOnlyCollection<string> RoleCodes);
}
