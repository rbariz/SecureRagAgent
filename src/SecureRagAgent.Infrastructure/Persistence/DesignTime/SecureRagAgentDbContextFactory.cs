using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureRagAgent.Infrastructure.Persistence.DesignTime
{
    public sealed class SecureRagAgentDbContextFactory
    : IDesignTimeDbContextFactory<SecureRagAgentDbContext>
    {
        public SecureRagAgentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SecureRagAgentDbContext>();

            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5437;Database=secure_rag_agent;Username=postgres;Password=postgres",
                npgsqlOptions => npgsqlOptions.UseVector());

            return new SecureRagAgentDbContext(optionsBuilder.Options);
        }
    }
}
