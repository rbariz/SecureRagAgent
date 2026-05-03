using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Application.Abstractions.Ai
{
    public sealed record LlmChatMessage(
    string Role,
    string Content);
}
