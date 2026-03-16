using Backend.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:4000");
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseCors();
app.MapControllers();

app.Run();
