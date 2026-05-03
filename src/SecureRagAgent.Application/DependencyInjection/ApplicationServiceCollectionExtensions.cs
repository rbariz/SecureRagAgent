using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureRagAgent.Application.Options;

namespace SecureRagAgent.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AiOptions>(
            configuration.GetSection(AiOptions.SectionName));

        return services;
    }
}
