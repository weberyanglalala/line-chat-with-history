using LineChatWithHistory.Models.Settings;
using Microsoft.Extensions.Options;

namespace LineChatWithHistory.Configurations;

public static class ConfigureLineMessagingApi
{
    public static IServiceCollection AddLineMessagingApi(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .Configure<LineMessagingApiSettings>(configuration.GetSection(nameof(LineMessagingApiSettings)))
            .AddSingleton(settings => settings.GetRequiredService<IOptions<LineMessagingApiSettings>>().Value);
        return services;
    }
}