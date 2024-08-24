namespace Watcher.Services
{
    public interface IMetricsScraper
    {
        void ScrapeMetrics();
    }
    public interface IMetricsExporter
    {
        void ExportMetrics();
    }
    public class MetricsScraper : IMetricsScraper
    {
        public void ScrapeMetrics()
        {
            // Logic to scrape metrics from endpoints using Prometheus
        }
    }

    public class MetricsExporter : IMetricsExporter
    {
        public void ExportMetrics()
        {
            // Logic to export scraped metrics to InfluxDB
        }
    }
}
