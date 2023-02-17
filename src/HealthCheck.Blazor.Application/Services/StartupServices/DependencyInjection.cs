using HealthCheck.Blazor.Application.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck.Blazor.Application.Services.StartupServices;

public static class DependencyInjection
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        //configure health check
        builder.Services.AddHealthChecks()
            .AddCheck("Database", () =>
                HealthCheckResult.Healthy("The check for database service worked"), new[] {"database"});
        builder.Services.AddSingleton<WeatherForecastService>();

        return builder;
    }
}
