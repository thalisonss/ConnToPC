using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:7777");


builder.Services.AddHostedService<Worker>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();