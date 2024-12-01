using Business.Core.BLs;
using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.SysParamBLs;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.BLs.UserBLs;
using Business.Core.Services.BaseServices;
using Business.Core.Services.DefErrorServices;
using Business.Core.Services.Share;
using Business.Core.Services.ShareServices;
using Business.Core.Services.SystemCodeServices;
using Business.Core.Services.SystemServices;
using DataAccess.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Object.Core;

namespace Business.Core.Startups
{
    public static class CoreBLStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //
            services.AddScoped<ISAShareService, SAShareService>();

            // MasterDataBase
            services.AddScoped(typeof(IMasterDataBaseBL<>), typeof(MasterDataBaseBL<>));
            services.AddScoped(typeof(IMasterDataBaseService<>), typeof(MasterDataBaseService<>));

            

            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IDefErrorService, DefErrorService>();
            services.AddScoped<ISearchBL, SearchBL>();
            services.AddScoped<IShareService, ShareService>();

            // SysParam
            #region SysParam
            services.AddScoped<ISysParamBL, SysParamBL>();
            services.AddScoped<IMasterDataBaseBL<MWSysParam>, SysParamBL>();
            services.AddScoped<ISysParamService, SysParamService>();
            services.AddScoped<IMasterDataBaseService<MWSysParam>, SysParamService>();
            #endregion

            // SystemCode
            #region SystemCode
            services.AddScoped<ISystemCodeBL, SystemCodeBL>();
            services.AddScoped<IMasterDataBaseBL<MWSystemCode>, SystemCodeBL>();
            services.AddScoped<ISystemCodeService, SystemCodeService>();
            services.AddScoped<IMasterDataBaseService<MWSystemCode>, SystemCodeService>();
            #endregion

            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserFunctionBL, UserFunctionBL>();

            //
            services.AddScoped<ILoadMemService, LoadMemService>();
        }
    }
}
