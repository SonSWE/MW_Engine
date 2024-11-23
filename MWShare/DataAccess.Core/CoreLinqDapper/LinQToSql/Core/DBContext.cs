using Dapper;
using DapperLib.LinQToSql.TypeSql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DapperLib.LinQToSql.Core
{
    public class DBContextDapper : IDBContext
    {
        public DataSourceType SourceType { get; private set; } = DataSourceType.ORACLE;
        public IDbTransaction? Transaction { get; private set; }
        public IDbConnection Connection { get; }
        public bool? Buffered { get; set; }
        public int? Timeout { get; set; }
        public SessionState State { get; private set; }
        public DBContextDapper(IDbConnection connection)
        {
            Connection = connection;
            State = SessionState.Closed;
        }
        public void Open(bool beginTransaction, IsolationLevel? level = null)
        {
            if (!beginTransaction)
            {
                Connection.Open();
            }
            else
            {
                Connection.Open();
                Transaction = level == null ? Connection.BeginTransaction() : Connection.BeginTransaction(level.Value);
            }
            State = SessionState.Open;
        }
        public async Task OpenAsync(bool beginTransaction, IsolationLevel? level = null)
        {
            State = SessionState.Open;
            if (Connection == null)
            {
                throw new InvalidOperationException("Connection Not Start");
            }
            if (!(Connection is DbConnection))
            {
                throw new InvalidOperationException("Async operations require use of a DbConnection or an already-open IDbConnection");
            }
            if (!beginTransaction)
            {
                await ((DbConnection) Connection).OpenAsync();
            }
            else
            {
                await ((DbConnection) Connection).OpenAsync();
                Transaction = level == null ? Connection.BeginTransaction() : Connection.BeginTransaction(level.Value);
            }
        }
        public void Close()
        {
            Connection.Close();
            State = SessionState.Closed;
        }
        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                State = SessionState.Commit;
            }
        }
        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
                State = SessionState.Rollback;
            }
        }
        public void Dispose()
        {
            Close();
        }
        public GridReader QueryMultiple(string sql, object? param = null, int? commandTimeout = null, CommandType text = CommandType.Text)
        {
            return Connection.QueryMultiple(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, text);
        }
        public Task<GridReader> QueryMultipleAsync(string sql, object? param = null, int? commandTimeout = null, CommandType text = CommandType.Text)
        {
            return Connection.QueryMultipleAsync(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, text);
        }
        public int Execute(string sql, object? param = null, int? commandTimeout = null, CommandType text = CommandType.Text)
        {
            return Connection.Execute(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, text);
        }
        public Task<int> ExecuteAsync(string sql, object? param = null, int? commandTimeout = null, CommandType text = CommandType.Text)
        {
            return Connection.ExecuteAsync(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, text);
        }
        public T? ExecuteScalar<T>(string sql, object? param = null, int? commandTimeout = null, CommandType text = CommandType.Text)
        {
            return Connection.ExecuteScalar<T?>(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, text);
        }
        public Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType text = CommandType.Text)
        {
            return Connection.ExecuteScalarAsync<T>(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, text);
        }
        public IQuerydapper<T> From<T>() where T : class
        {
            
            if (SourceType == DataSourceType.ORACLE)
            {
                return new OracleSqlQuery<T>(this);
            }
            throw new NotImplementedException();
        }
        public IQueryable<T1, T2> From<T1, T2>() where T1 : class where T2 : class
        {
           
            if (SourceType == DataSourceType.ORACLE)
            {
                return new OracleSqlQuery<T1, T2>(this);
            }
            throw new NotImplementedException();
        }
        public IQueryable<T1, T2, T3> From<T1, T2, T3>() where T1 : class where T2 : class where T3 : class
        {
            
            if (SourceType == DataSourceType.ORACLE)
            {
                return new OracleSqlQuery<T1, T2, T3>(this);
            }
            throw new NotImplementedException();
        }
        public IEnumerable<T> Query<T>(string sql, object? param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Query<T>(sql, param, Transaction, Buffered != null ? Buffered.Value : buffered, Timeout != null ? Timeout.Value : commandTimeout, commandType);
        }
        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QueryAsync<T>(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, commandType);
        }
        public IEnumerable<dynamic> Query(string sql, object? param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.Query(sql, param, Transaction, Buffered != null ? Buffered.Value : buffered, Timeout != null ? Timeout.Value : commandTimeout, commandType);
        }
        public Task<IEnumerable<dynamic>> QueryAsync(string sql, object? param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return Connection.QueryAsync(sql, param, Transaction, Timeout != null ? Timeout.Value : commandTimeout, commandType);
        }

    }
}
