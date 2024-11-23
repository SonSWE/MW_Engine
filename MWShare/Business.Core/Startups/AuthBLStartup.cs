using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.LoginBLs;
using Business.Core.Services.BaseServices;
using Business.Core.Services.DefErrorServices;
using Business.Core.Services.LoginServices;
using Business.Core.Services.ShareServices;
using Business.Core.Services.SystemServices;
using DataAccess.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Object.Core;

namespace Business.Core.Startups
{
    public static class AuthBLStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {

            // MasterDataBase
            services.AddScoped(typeof(IMasterDataBaseBL<>), typeof(MasterDataBaseBL<>));
            services.AddScoped(typeof(IMasterDataBaseService<>), typeof(MasterDataBaseService<>));

            //
            services.AddScoped<IShareService, ShareService>();
            //services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IDefErrorService, DefErrorService>();
            services.AddScoped<ISysParamService, SysParamService>();

            services.AddScoped<ILoginBL, LoginBL>();
            services.AddScoped<ILoginService, LoginService>();
        }
    }
}
