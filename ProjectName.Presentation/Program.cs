using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ProjectName.Presentation.Extensions;
using ProjectName.Application.DependencyInjection;
using ProjectName.Infrastructure.DependencyInjection;
using ProjectName.Presentation.DependencyInjection;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddApplication().AddPresentation().AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
}

app.UsePresentation();
app.MapHealthChecks("health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

namespace ProjectName.Presentation
{
    public partial class Program;
}
