using CommonLib;
using MemoryData;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Core.Services.SystemServices
{
    public sealed class LoadMemService : ILoadMemService
    {
        private readonly ICommonService _commonService;

        public LoadMemService(IServiceScopeFactory serviceScopeFactory)
        {
            var serviceScoped = serviceScopeFactory.CreateScope();
            _commonService = serviceScoped.ServiceProvider.GetRequiredService<ICommonService>();
        }

        // (
        public async Task LoadAll(bool isInit)
        {
            Logger.log.Info($"LoadAllMem-Start");

            var tasks = new List<Task>
            {
                LoadFunction(), // Chưa có E1
                LoadSkill(),
                LoadSpecial(),
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

        public async Task LoadSkill()
        {
            string logPrefix = "LoadSkill";

            try
            {
                Logger.log.Info($"{logPrefix} - Start");

                var skills = await _commonService.GetSkills();
                SkillMem.InitData(skills);

                Logger.log.Info($"{logPrefix} - End - RowCount=[{skills?.Count ?? 0}]");
            }
            catch (System.Exception ex)
            {
                Logger.log.Info($"{logPrefix} - Error -  {ex.Message}");
                Logger.log.Error(ex, $"{logPrefix} - {ex.Message}");
            }
        }


        public async Task LoadSpecial()
        {
            string logPrefix = "LoadSpecial";

            try
            {
                Logger.log.Info($"{logPrefix} - Start");

                var specialties = await _commonService.GetSpecialties();
                SpecialtyMem.InitData(specialties);

                Logger.log.Info($"{logPrefix} - End - RowCount=[{specialties?.Count ?? 0}]");
            }
            catch (System.Exception ex)
            {
                Logger.log.Info($"{logPrefix} - Error -  {ex.Message}");
                Logger.log.Error(ex, $"{logPrefix} - {ex.Message}");
            }
        }
    }
}
