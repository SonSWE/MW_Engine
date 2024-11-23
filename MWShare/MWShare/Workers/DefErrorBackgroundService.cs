using Business.Core.Services.DefErrorServices;
using CommonLib;
using CommonLib.Constants;
using DataAccess.Helpers;
using MemoryData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MWShare.Workers
{
    public sealed class DefErrorBackgroundService : BackgroundService
    {
        private readonly ILoggingManagement _loggingManagement;
        private readonly IDefErrorService _defErrorBL;

        public DefErrorBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            var serviceScoped = serviceScopeFactory.CreateScope();
            _loggingManagement = serviceScoped.ServiceProvider.GetRequiredService<ILoggingManagement>();
            _defErrorBL = serviceScoped.ServiceProvider.GetRequiredService<IDefErrorService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _loggingManagement.ReCreateRequestId();
                string guid = _loggingManagement.RequestId;
                DateTime startTime = DateTime.Now;

                Logger.log.Info($"[{guid}] [JOB - Reload DefErrorMem] Bat dau");

                try
                {
                    await Task.Run(() =>
                    {
                        DefErrorMem.InitData(_defErrorBL.GetAll());
                    }, stoppingToken);
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex, ex.Message);
                }

                Logger.log.Info($"[{guid}] [JOB - Reload DefErrorMem] Ket thuc. Tong thoi gian {ConstLog.GetProcessingMilliseconds(startTime)}(ms)");

                await Task.Delay(TimeSpan.FromSeconds(ConfigData.ReloadMemTimeInterval), stoppingToken);
            }
        }
    }
}
