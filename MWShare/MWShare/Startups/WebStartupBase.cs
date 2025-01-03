using MWShare.Helpers;
using MWShare.Workers;
using Business.Core.Startups;
using CommonLib;
using DataAccess.Core.Startups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using MWShare.ExportEngine;
using MWShare.ExportHelpers;
using Object.Core.Configs;
using MWShare.Helpers.FileStorage;
using MWShare.Authen;

namespace MWShare.Startups
{
    public static class WebStartupBase
    {
        public static void ConfigureBuilder(WebApplicationBuilder builder)
        {
            // Setting appsettings.json file
            builder.WebHost.ConfigureAppConfiguration(
                (hostingContext, config) =>
                {
                    var path = Path.Combine("./ConfigApp", "appsettings.json");
                    config.AddJsonFile(path, optional: false, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                });

            // Init NLog
            NLog.LogManager.LoadConfiguration(Path.Combine("./ConfigLog", "nlog.config"));
            builder.Host.UseNLog();

            // Init config
            ConfigData.InitConfig(builder.Configuration);

            LogStation.LogStationFacade.InitConfig(30, Logger.log);
            LogStation.LogStationFacade.StartWritetoFileThread(); // khới động thread log dịnh kỳ thông tin
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowLocal", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("Content-Disposition");
                });
            });

            services.Configure<BOConnectApiConfig>(services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetSection(BOConnectApiConfig.AppsettingsKey));

            
            services.AddSingleton<IExportService, ExportService>();
            services.AddSingleton<IFileStorageClient, MinIOClient>();



            //services.AddSingleton<INotifyClient>(new NotifyClient(ConfigData.NotifyHost));
            services.AddSingleton<IMWAuthClient>(new MWAuthClient(ConfigData.MWAuthHost));

            //
            CoreDAStartup.ConfigureServices(services);
            CoreBLStartup.ConfigureServices(services);

            //
            services.AddScoped<ISearchHelper, SearchHelper>();
            //


            services.AddHostedService<SysParamBackgroundService>();
            //services.AddHostedService<DefErrorBackgroundService>();
            services.AddHostedService<SearchBackgroundService>();
            services.AddHostedService<LoadMemBackgroundService>();

            services.AddControllers();
        }
    }
}
