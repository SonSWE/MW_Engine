using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.ClientDAs;
using DataAccess.Core.DefErrorDAs;
using DataAccess.Core.FreelancerDAs;
using DataAccess.Core.FunctionDAs;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using DataAccess.Core.JobDAs;
using DataAccess.Core.LoginDAs;
using DataAccess.Core.SkillDAs;
using DataAccess.Core.SpencialDAs;
using DataAccess.Core.SystemCodeDAs;
using DataAccess.Core.SystemDAs;
using DataAccess.Core.UserDAs;
using DataAccess.Helpers;
using Microsoft.Extensions.DependencyInjection;
using OracleHelpers;
using System;
using System.Data;


namespace DataAccess.Core.Startups
{
    public static class CoreDAStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Dapper.SqlMapper.Settings.SupportLegacyParameterTokens = false;
            Dapper.SqlMapper.AddTypeHandler(new DapperDateTimeHandler());

            services.AddScoped<ILoggingManagement, LoggingManagement>();
            services.AddSingleton<IOracleHelper>(OracleHelperProvider.OracleHelper);
            services.AddScoped<IDbManagement, DbManagement>();
            services.AddScoped(typeof(IBaseDA<>), typeof(BaseDA<>));

            services.AddScoped<ILoginDA, LoginDA>();

            //system
            services.AddScoped<ICommonDA, CommonDA>();
            services.AddScoped<ISearchDA, SearchDA>();
            services.AddScoped<ISysParamDA, SysParamDA>();

            //def error
            services.AddScoped<IDefErrorDA, DefErrorDA>();

            //user
            services.AddScoped<IFunctionDA, FunctionDA>();
            services.AddScoped<IUserDA, UserDA>();
            services.AddScoped<IUserFunctionDA, UserFunctionDA>();

            //client
            services.AddScoped<IClientDA, ClientDA>();

            //freelancer
            services.AddScoped<IFreelancerDA, FreelancerDA>();
            services.AddScoped<IFreelancerWorkingHistoryDA, FreelancerWorkingHistoryDA>();
            services.AddScoped<IFreelancerSpecialtyDA, FreelancerSpecialtyDA>();
            services.AddScoped<IFreelancerSkillDA, FreelancerSkillDA>();
            services.AddScoped<IFreelancerEducationDA, FreelancerEducationDA>();
            services.AddScoped<IFreelancerCertificateDA, FreelancerCertificateDA>();

            //system code
            services.AddScoped<ISystemCodeDA, SystemCodeDA>();
            services.AddScoped<ISystemCodeValueDA, SystemCodeValueDA>();

            //job
            services.AddScoped<IJobDA, JobDA>();
            services.AddScoped<IProposalDA, ProposalDA>();
            services.AddScoped<IJobSkillDA, JobSkillDA>();
            services.AddScoped<IJobFileAttachDA, JobFileAttachDA>();
            services.AddScoped<IJobSavedDA, JobSavedDA>();

            //skill
            services.AddScoped<ISkillDA, SkillDA>();

            //specialty
            services.AddScoped<ISpecialtyDA, SpecialtyDA>();
            services.AddScoped<IProposalFileAttachDA, ProposalFileAttachDA>();


            //login
            services.AddScoped<ILoginDA, LoginDA>();

        }
    }

    public class DapperDateTimeHandler : SqlMapper.TypeHandler<DateTime>
    {
        public override void SetValue(IDbDataParameter parameter, DateTime value)
        {
            parameter.Value = value;
        }

        public override DateTime Parse(object value)
        {
            var dateTime = (DateTime)value;

            if (dateTime.Date != DateTime.MinValue.Date && dateTime.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            }

            return dateTime;
        }
    }
}