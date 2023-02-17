using HealthCheck.Blazor.Application.Services.StartupServices;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapHealthChecks("/health", new HealthCheckOptions() 
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
