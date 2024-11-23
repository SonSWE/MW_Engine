﻿using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.DefErrorDAs;
using DataAccess.Core.FunctionDAs;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using DataAccess.Core.LoginDAs;
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

            //system code
            services.AddScoped<ISystemCodeDA, SystemCodeDA>();
            services.AddScoped<ISystemCodeValueDA, SystemCodeValueDA>();


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