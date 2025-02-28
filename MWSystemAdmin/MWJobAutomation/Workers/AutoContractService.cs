
using Business.Core.Services.ContractServices;
using Business.Core.Services.SystemServices;
using CommonLib;
using CommonLib.Constants;
using DataAccess.Core.JobDAs;
using Microsoft.Extensions.DependencyInjection;
using Object.Core;

namespace MWSystemAdmin.Workers
{
    public sealed class AutoContractService : BackgroundService
    {
        private readonly IContractService _contractService;
        //private readonly IContractDA _contractDA;

        public AutoContractService(IServiceScopeFactory serviceScopeFactory)
        {
            var serviceScoped = serviceScopeFactory.CreateScope();
            _contractService = serviceScoped.ServiceProvider.GetRequiredService<IContractService>();
            //_contractDA = serviceScoped.ServiceProvider.GetRequiredService<IContractDA>();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Tính toán thời gian còn lại đến 00:00 ngày kế tiếp
                    var now = DateTime.Now;
                    var nextRun = now.Date.AddDays(1); // 00:00 ngày hôm sau
                    var delay = nextRun - now;

                    // Đợi cho đến 00:00
                    await Task.Delay(delay, stoppingToken);

                    // Thực hiện công việc cập nhật
                    await UpdateContractsAsync();
                }
                catch (TaskCanceledException)
                {
                    Logger.log.Error("Task was cancelled.");
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex, "Error during contract status update.");
                }
            }
        }

        private async Task UpdateContractsAsync()
        {
            //lấy danh sách hợp đồng đến ngày hết hạn
            var lstContractId = await _contractService.GetContractIdsEndDate();

            if (lstContractId.Count() > 0)
            {
                foreach (var id in lstContractId)
                {
                    await UpdateContractsAsync(id);
                }
            }
        }


        private async Task UpdateContractsAsync(string id)
        {
            var contract = await _contractService.GetDetailByIdAync(id);

            if (contract == null) return;

            //case

            if (contract.ContractResults.Count() > 0)
            {
                //case a: có kết quả
                if(contract.EndDate.Date >= DateTime.Now.Date)
                {
                    //case a-1: chưa quá 10 ngày -> trạng thái chờ khiếu nại
                    var result =  _contractService.UpdateStatus(contract.ContractId, Const.Contract_Status.PendingComplaint, string.Empty, new ClientInfo(), out var m, out var p);
                    return;
                }


                if (contract.EndDate >= DateTime.Now.Date.AddDays(10))
                {
                    //case a-2: quá 10 ngày -> thanh toán tiền cho freelancer
                    _contractService.UpdateStatus(contract.ContractId, Const.Contract_Status.Done, string.Empty, new ClientInfo(), out var m, out var p);
                    return;
                }
            }
            else
            {
                //case b: không có kết quả -> kết thúc hợp đồng, hoàn tiền cho khách hàng
                _contractService.UpdateStatus(contract.ContractId, Const.Contract_Status.Fail, string.Empty, new ClientInfo(), out var m, out var p);
            }
        }
    }
}
