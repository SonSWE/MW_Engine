using Business.Core.Services.SystemServices;
using CommonLib;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MWShare.Workers
{
    public sealed class LoadMemBackgroundService : BackgroundService
    {
        private readonly ILoadMemService _loadMemService;

        public LoadMemBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            var serviceScoped = serviceScopeFactory.CreateScope();
            _loadMemService = serviceScoped.ServiceProvider.GetRequiredService<ILoadMemService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Đọc dữ liệu lần đầu 
            await _loadMemService.LoadAll(true);

            // Định kỳ đọc lại các dữ liệu không có trên màn hình khai báo
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(ConfigData.ReloadMemTimeInterval), stoppingToken);

                    // Định kỳ đọc lại dl chưa có E1 hoặc không có màn quản lý
                    await _loadMemService.LoadAll(false);
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex, ex.Message);
                }
            }
        }
    }
}
