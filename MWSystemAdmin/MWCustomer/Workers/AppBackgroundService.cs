
namespace MWSystemAdmin.Workers
{
    public sealed class AppBackgroundService : BackgroundService
    {
        private static IServiceProvider _serviceProvider;

        public AppBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
