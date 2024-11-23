using CommonLib;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using DapperLib.LinQToSql.Core;

namespace DataAccess.Core.Helpers
{
    internal sealed class DbManagement : IDbManagement//, IDisposable
    {
        private IDbConnection? _dbConnection;
        private IDbTransaction _dbTransaction;
        private DBContextDapper? dBContextDapper;
        private object _lock = new();

        private readonly IServiceProvider _serviceProvider;

        public DbManagement(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDbConnection GetConnectSingle()
        {
            if (_dbConnection == null) 
                _dbConnection  = new OracleConnection(ConfigData.ConnectionString);
            return _dbConnection;
        }
        public DBContextDapper GetDbContext()
        {
            if (dBContextDapper == null) dBContextDapper = new DBContextDapper(GetConnectSingle());

            return dBContextDapper;
        }
        public IDbConnection GetConnection()
        {
            //lock (_lock)
            //{
            //    if (_dbConnection == null)
            //    {
            //        _dbConnection = new OracleConnection(ConfigData.ConnectionString);
            //    }

            //    if (_dbConnection.State == ConnectionState.Closed || _dbConnection.State == ConnectionState.Broken)
            //    {
            //        _dbConnection.Open();
            //    }
            //}

            //return _dbConnection;

            var dbConnection = new OracleConnection(ConfigData.ConnectionString);
            dbConnection.Open();
            return dbConnection;
        }
        
        //public IDbTransaction GetTransaction()
        //{
        //    lock (_lock)
        //    {
        //        if (_dbTransaction == null)
        //        {
        //            _dbTransaction = GetConnection().BeginTransaction();
        //        }
        //    }

        //    return _dbTransaction;
        //}

        //#region Dispose

        //private bool _disposed;

        //~DbManagement()
        //{
        //    Dispose(false);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //private void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            try
        //            {
        //                _dbTransaction?.Dispose();
        //                _dbConnection?.Dispose();
        //            }
        //            finally
        //            {

        //            }
        //        }
        //    }
        //    _disposed = true;
        //}

        //#endregion

        public T? GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public object? GetService(Type type)
        {
            return _serviceProvider.GetService(type);
        }

        public T GetRequiredService<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public object GetRequiredService(Type type)
        {
            return _serviceProvider.GetRequiredService(type);
        }
    }
}
