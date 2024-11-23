using CommonLib;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Core.Services.SystemServices
{
    public sealed class LoadMemService : ILoadMemService
    {


        public LoadMemService()
        {

        }

        // (
        public async Task LoadAll(bool isInit)
        {
            Logger.log.Info($"LoadAllMem-Start");

            var tasks = new List<Task>
            {
                LoadFunction(), // Chưa có E1
            };


            await Task.WhenAll(tasks);

            Logger.log.Info($"LoadAllMem-End");
        }

        //
        public async Task LoadFunction()
        {
            //string logPrefix = "LoadFunction";

            //try
            //{
            //    Logger.log.Info($"{logPrefix} - Start");

            //    var functions = (await _functionDA.GetViewAsync(new Dictionary<string, object>
            //    {
            //        { nameof(MCFunction.Deleted), 0 }
            //    }))?.ToList();

            //    FunctionMem.InitData(functions);

            //    Logger.log.Info($"{logPrefix} - End - RowCount=[{functions?.Count ?? 0}]");
            //}
            //catch (System.Exception ex)
            //{
            //    Logger.log.Info($"{logPrefix} - Error -  {ex.Message}");
            //    Logger.log.Error(ex, $"{logPrefix} - {ex.Message}");
            //}
        }
    }
}
