using App.Metrics.Formatters.Prometheus;
using App.Metrics;

var builder = WebApplication.CreateBuilder(args);

builder.AddBasicServiceDefaults();
builder.AddApplicationServices();
var metrics = new MetricsBuilder()
           .OutputMetrics.AsPrometheusPlainText()
           .Build();

builder.Services.AddMetrics(metrics);
builder.Services.AddMetricsTrackingMiddleware();
builder.Services.AddMetricsEndpoints(options =>
{
    options.MetricsTextEndpointOutputFormatter = metrics.OutputMetricsFormatters.OfType<MetricsPrometheusTextOutputFormatter>().First();
});

builder.Services.AddMetricsReportingHostedService();
// This will send metrics periodically to InfluxDB
builder.Services.AddMetricsTrackingMiddleware();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseMetricsEndpoint(); // Expose metrics at /metrics

app.MapGrpcService<BasketService>();

app.Run();
