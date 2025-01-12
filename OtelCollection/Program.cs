using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

var otel = builder.Services.AddOpenTelemetry();

otel.ConfigureResource(resource => resource.AddService(builder.Environment.ApplicationName));

otel.WithMetrics(metrics => metrics.AddAspNetCoreInstrumentation());

otel.WithTracing(tracing => tracing.AddAspNetCoreInstrumentation());

otel.UseOtlpExporter();

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
