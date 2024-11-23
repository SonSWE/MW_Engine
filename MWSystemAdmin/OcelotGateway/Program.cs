using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.WebHost.ConfigureAppConfiguration(
               (hostingContext, config) =>
               {
                   var path = Path.Combine("./Config", "appsettings.json");
                   var pathOcelot = Path.Combine("./Config", "ocelot.json");
                   config.AddJsonFile(path, optional: false, reloadOnChange: true);
                   config.AddJsonFile(pathOcelot, optional: false, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               });

builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Giữ nguyên tên thuộc tính
});

var app = builder.Build();


app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseOcelot().Wait();

//await app.UseOcelot();

app.Run();