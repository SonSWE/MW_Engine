using Business.Core.BLs;
using Business.Core.BLs.BaseBLs;
using Business.Core.BLs.ClientBLs;
using Business.Core.BLs.FreelancerBLs;
using Business.Core.BLs.JobBLs;
using Business.Core.BLs.ProposalBLs;
using Business.Core.BLs.SkillBLs;
using Business.Core.BLs.SpecialtyBLs;
using Business.Core.BLs.SysParamBLs;
using Business.Core.BLs.SystemCodeBLs;
using Business.Core.BLs.UserBLs;
using Business.Core.Services.BaseServices;
using Business.Core.Services.ClientServices;
using Business.Core.Services.DefErrorServices;
using Business.Core.Services.FreelancerServices;
using Business.Core.Services.JobServices;
using Business.Core.Services.Share;
using Business.Core.Services.ShareServices;
using Business.Core.Services.SkillServices;
using Business.Core.Services.SpecialtyServices;
using Business.Core.Services.SystemCodeServices;
using Business.Core.Services.SystemServices;
using Business.Core.Services.UserServices;
using DataAccess.Core.Interfaces;
using DataAccess.Core.JobDAs;
using Microsoft.Extensions.DependencyInjection;
using Object;
using Object.Core;

namespace Business.Core.Startups
{
    public static class BLStartup
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

            // User
            #region User
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IMasterDataBaseBL<MWUser>, UserBL>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMasterDataBaseService<MWUser>, UserService>();
            #endregion

            // Freelancer
            #region Freelancer
            services.AddScoped<IFreelancerBL, FreelancerBL>();
            services.AddScoped<IMasterDataBaseBL<MWFreelancer>, FreelancerBL>();
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IMasterDataBaseService<MWFreelancer>, FreelancerService>();
            #endregion

            // client
            #region client
            services.AddScoped<IClientBL, ClientBL>();
            services.AddScoped<IMasterDataBaseBL<MWClient>, ClientBL>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IMasterDataBaseService<MWClient>, ClientService>();
            #endregion

            // SystemCode
            #region SystemCode
            services.AddScoped<ISystemCodeBL, SystemCodeBL>();
            services.AddScoped<IMasterDataBaseBL<MWSystemCode>, SystemCodeBL>();
            services.AddScoped<ISystemCodeService, SystemCodeService>();
            services.AddScoped<IMasterDataBaseService<MWSystemCode>, SystemCodeService>();
            #endregion

            // Job
            #region Job
            services.AddScoped<IJobBL, JobBL>();
            services.AddScoped<IMasterDataBaseBL<MWJob>, JobBL>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IMasterDataBaseService<MWJob>, JobService>();
            #endregion

            // Proposal
            #region Proposal
            services.AddScoped<IProposalBL, ProposalBL>();
            services.AddScoped<IMasterDataBaseBL<MWProposal>, ProposalBL>();
            #endregion

            // Skill
            #region Skill
            services.AddScoped<ISkillBL, SkillBL>();
            services.AddScoped<IMasterDataBaseBL<MWSkill>, SkillBL>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IMasterDataBaseService<MWSkill>, SkillService>();
            #endregion


            // Specialty
            #region Specialty
            services.AddScoped<ISpecialtyBL, SpecialtyBL>();
            services.AddScoped<IMasterDataBaseBL<MWSpecialty>, SpecialtyBL>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<IMasterDataBaseService<MWSpecialty>, SpecialtyService>();
            #endregion

            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<IUserFunctionBL, UserFunctionBL>();

            //
            services.AddScoped<ILoadMemService, LoadMemService>();
        }
    }
}
