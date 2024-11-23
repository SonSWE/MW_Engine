using CommonLib;
using MWShare.Helpers;
using MWShare.Startups;
using MWSystemAdmin.Workers;
using System;

var guid = Utils.GenGuidStringN();

var builder = WebApplication.CreateBuilder(args);

WebStartupBase.ConfigureBuilder(builder);
// Cấu hình background worker dùng chung
WebStartupBase.ConfigureServices(builder.Services);

builder.Services.AddHostedService<AppBackgroundService>();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

int.TryParse(builder.Configuration["ApiPort"], out int apiPort);

// Configure Api
if (apiPort > 0)
{
    app.MapWhen(context => context.Connection.LocalPort == apiPort, iab => iab.UseRouting().UseEndpoints(endpoints =>
    {
        endpoints.MapGet("/healthcheck", () =>
        {
            return DateTime.Now;
        });

        endpoints.MapControllers();
    }));
}

Logger.log.Info($"[{guid}] [LIFE CYCLE] Init configs, services successfully. CurrentTime [{DateTime.Now:O}]");
app.Run();

Logger.log.Info($"[{guid}] [LIFE CYCLE] Shutting down. CurrentTime [{DateTime.Now:O}");
