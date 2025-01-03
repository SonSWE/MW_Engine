using Business.Core.Services.SystemServices;
using CommonLib;
using CommonLib.Constants;
using DataAccess.Helpers;
using MemoryData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MWShare.Workers
{
    public class SysParamBackgroundService : BackgroundService
    {
        private readonly ILoggingManagement _loggingManagement;
        private readonly ICommonService _commonService;
        private readonly ISysParamService _sysParamBL;

        public SysParamBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            var serviceScoped = serviceScopeFactory.CreateScope();
            _loggingManagement = serviceScoped.ServiceProvider.GetRequiredService<ILoggingManagement>();
            _commonService = serviceScoped.ServiceProvider.GetRequiredService<ICommonService>();
            _sysParamBL = serviceScoped.ServiceProvider.GetRequiredService<ISysParamService>();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _loggingManagement.ReCreateRequestId();
                string guid = _loggingManagement.RequestId;
                DateTime startTime = DateTime.Now;

                Logger.log.Info($"[{guid}] [JOB - Reload SysParamMem] Bat dau");

                try
                {
                    await Task.Run(() =>
                    {
                        try
                        {
                            //var busDate = _commonService.GetBusDate();

                            Logger.log.Info($"[{guid}] [JOB - Reload SysParamMem]");

                            var sysParams = _sysParamBL.GetAll();
                            SysParamMem.InitData(sysParams);
                        }
                        catch (Exception e)
                        {
                            Logger.log.Error(e, $"[{guid}] {e.Message}");
                        }
                    }, stoppingToken);

                    try
                    {
                        var systemCodes = await _commonService.GetSystemCodes();
                        SystemCodeMem.InitData(systemCodes);
                    }
                    catch (Exception e)
                    {
                        Logger.log.Error(e, $"[{guid}] {e.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex, ex.Message);
                }

                Logger.log.Info($"[{guid}] [JOB - Reload SysParamMem] Ket thuc. Tong thoi gian {ConstLog.GetProcessingMilliseconds(startTime)}(ms)");

                await Task.Delay(TimeSpan.FromSeconds(ConfigData.ReloadMemTimeInterval), stoppingToken);
                //await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
            }
        }
    }
}
