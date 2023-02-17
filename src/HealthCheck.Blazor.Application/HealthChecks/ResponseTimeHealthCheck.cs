using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheck.Blazor.Application.HealthChecks;

public class ResponseTimeHealthCheck : IHealthCheck
{
    private Random random = new(); // only for demo, to be replaced with 
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        int responseTimeInMs = random.Next(1, 300);

        if (responseTimeInMs < 100)
        {
            return Task.FromResult(HealthCheckResult.Healthy($"The response time is good ({responseTimeInMs})"));
        }
        else if(responseTimeInMs <200 )
        {
            return Task.FromResult(HealthCheckResult.Degraded($"The response time is slow ({responseTimeInMs})"));
        }
        else
        {
            return Task.FromResult(HealthCheckResult.Unhealthy($"The response time is unacceptable ({responseTimeInMs})"));
        }

    }
}
