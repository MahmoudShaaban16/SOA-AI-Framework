using System.Net.Http;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
var httpClient = new HttpClient();


var influxDBClient = new InfluxDBClient("http://influxdb:8086", "your_token");
var writeApi = influxDBClient.GetWriteApi();

app.UseRouting();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/scrape", async context =>
//    {
//        var response = await httpClient.GetAsync("http://prometheus:9090/api/v1/query?query=your_query");
//        var content = await response.Content.ReadAsStringAsync();

//        // Parse the Prometheus response and write to InfluxDB
//        var point = PointData.Measurement("metrics")
//            .Tag("service", "your_service")
//            .Field("value", 42)
//            .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

//        writeApi.WritePoint(point, "your_bucket", "your_org");

//        await context.Response.WriteAsync("Metrics scraped and written to InfluxDB");
//    });
//});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
