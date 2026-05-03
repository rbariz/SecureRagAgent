using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureRagAgent.Application.Abstractions.Ai;
using SecureRagAgent.Infrastructure.Ai.Factory;
using SecureRagAgent.Infrastructure.Persistence;

namespace SecureRagAgent.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
        }

        services.AddDbContext<SecureRagAgentDbContext>(options =>
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.UseVector();
            });
        });

        services.AddHttpClient("ollama", client =>
        {
            client.BaseAddress = new Uri("http://localhost:11434");
        });

        services.AddSingleton<AiProviderFactory>();

        services.AddScoped<ILlmProvider>(sp =>
            sp.GetRequiredService<AiProviderFactory>().CreateLlm());

        services.AddScoped<IEmbeddingProvider>(sp =>
            sp.GetRequiredService<AiProviderFactory>().CreateEmbedding());

        return services;
    }
}
