using HealthCheck.Blazor.Application.Data;
using HealthCheck.Blazor.Application.HealthChecks;

namespace HealthCheck.Blazor.Application.Services.StartupServices;

public static class DependencyInjection
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        //configure health check
        builder.Services.AddHealthChecks()
            .AddCheck<ResponseTimeHealthCheck>("Network Speed Test", null, new[] { "service" })
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddSingleton<ResponseTimeHealthCheck>();

        return builder;
    }
}
