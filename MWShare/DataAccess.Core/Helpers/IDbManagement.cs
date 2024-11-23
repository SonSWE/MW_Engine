using DapperLib.LinQToSql.Core;
using System;
using System.Data;

namespace DataAccess.Core.Helpers
{
    public interface IDbManagement
    {
        IDbConnection GetConnectSingle();
        DBContextDapper GetDbContext();
        IDbConnection GetConnection();
        //IDbTransaction GetTransaction();
        T? GetService<T>();
        object? GetService(Type type);
        T GetRequiredService<T>();
        object GetRequiredService(Type type);
    }
}
