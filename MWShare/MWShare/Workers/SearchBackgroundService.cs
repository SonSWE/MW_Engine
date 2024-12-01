using Business.Core.BLs;
using CommonLib;
using CommonLib.Constants;
using DataAccess.Helpers;
using MemoryData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MWShare.Workers
{
    public sealed class SearchBackgroundService : BackgroundService
    {
        private readonly ILoggingManagement _loggingManagement;
        private readonly ISearchBL _searchBL;

        public SearchBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            var serviceScoped = serviceScopeFactory.CreateScope();
            _loggingManagement = serviceScoped.ServiceProvider.GetRequiredService<ILoggingManagement>();
            _searchBL = serviceScoped.ServiceProvider.GetRequiredService<ISearchBL>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _loggingManagement.ReCreateRequestId();
                string guid = _loggingManagement.RequestId;
                DateTime startTime = DateTime.Now;

                Logger.log.Info($"[{guid}] [JOB - Reload SearchMem] Bat dau");

                try
                {
                    await Task.Run(() =>
                    {
                        var searches = _searchBL.GetAll();
                        //var searchFlds = _searchBL.SearchFldGetAll();

                        SearchMem.InitData(searches);
                    }, stoppingToken);
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex, ex.Message);
                }

                Logger.log.Info($"[{guid}] [JOB - Reload SearchMem] Ket thuc. Tong thoi gian {ConstLog.GetProcessingMilliseconds(startTime)}(ms)");

                await Task.Delay(TimeSpan.FromSeconds(ConfigData.ReloadMemTimeInterval), stoppingToken);
            }
        }
    }
}
