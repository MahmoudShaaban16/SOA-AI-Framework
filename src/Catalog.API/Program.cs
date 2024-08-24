using App.Metrics;
using App.Metrics.Formatters.Prometheus;
using Asp.Versioning.Builder;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();

var metrics = new MetricsBuilder()
           .OutputMetrics.AsPrometheusPlainText()
           .Build();

builder.Services.AddMetrics(metrics);
builder.Services.AddMetricsTrackingMiddleware();
builder.Services.AddMetricsEndpoints(options =>
{
    options.MetricsTextEndpointOutputFormatter = metrics.OutputMetricsFormatters.OfType<MetricsPrometheusTextOutputFormatter>().First();
});

builder.Services.AddMetricsReportingHostedService(); // This will send metrics periodically to InfluxDB
builder.Services.AddMetricsTrackingMiddleware();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();
// Expose metrics endpoint
app.UseMetricsAllMiddleware();
app.UseMetricsEndpoint(); // Expose metrics at /metrics
app.MapDefaultEndpoints();

app.NewVersionedApi("Catalog")
   .MapCatalogApiV1();

app.UseDefaultOpenApi();
app.Run();
