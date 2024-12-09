using CommonLib.Constants;
using Dapper;
using DapperLib.SqlGenerator;
using DapperLib.SqlGenerator.Filters;
using DataAccess.Core.Extensions;
using DataAccess.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Core.Abtractions
{
    public class BaseDA<T> : IBaseDA<T> where T : class, new()
    {
        private readonly IDbManagement _dbManagement;
        private IDbConnection _dbConnection => _dbManagement.GetConnection();
        public ISqlGenerator<T> SqlGenerator { get; }

        public BaseDA(IDbManagement dbManagement)
        {
            _dbManagement = dbManagement;
            SqlGenerator = new SqlGenerator<T>(SqlProvider.Oracle);
        }

        public long GetNextSequenceValue(IDbTransaction transaction = null)
        {
            return GetNextSequenceValueAsync(transaction).GetAwaiter().GetResult();
        }

        public async Task<long> GetNextSequenceValueAsync(IDbTransaction transaction)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.GetNextSequenceValue<T>();
            }
            else
            {
                return await transaction.Connection.GetNextSequenceValue<T>( transaction);
            }
        }

        public int Count(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return CountAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }

        public async Task<int> CountAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.CountAsync<T>(param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.CountAsync<T>(param, transaction, commandTimeout);
            }
        }

        public int Count(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return CountAsync(predicate, transaction, commandTimeout).GetAwaiter().GetResult();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var queryResult = SqlGenerator.GetCount(predicate);

            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.QueryFirstOrDefaultAsync<int>(new CommandDefinition(queryResult.GetSql(), queryResult.Param));
            }
            else
            {
                return await transaction.Connection.QueryFirstOrDefaultAsync<int>(new CommandDefinition(queryResult.GetSql(), queryResult.Param, transaction));
            }
        }

        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public IEnumerable<T> Get(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return GetAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.GetAsync<T>(param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.GetAsync<T>(param, transaction, commandTimeout);
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return GetAsync(predicate, transaction, commandTimeout).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var queryResult = SqlGenerator.GetSelectAll(predicate, null);
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.QueryAsync<T>(queryResult.GetSql(), queryResult.Param);
            }
            else
            {
                return await transaction.Connection.QueryAsync<T>(queryResult.GetSql(), queryResult.Param, transaction);
            }
        }

        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public T GetFirstOrDefault(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return GetFirstOrDefaultAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<T> GetFirstOrDefaultAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.GetFirstOrDefaultAsync<T>(param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.GetFirstOrDefaultAsync<T>(param, transaction, commandTimeout);
            }
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return GetFirstOrDefaultAsync(predicate, transaction, commandTimeout).GetAwaiter().GetResult();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var queryResult = SqlGenerator.GetSelectFirst(predicate, null);
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.QueryFirstOrDefaultAsync<T>(queryResult.GetSql(), queryResult.Param);
            }
            else
            {
                return await transaction.Connection.QueryFirstOrDefaultAsync<T>(queryResult.GetSql(), queryResult.Param, transaction);
            }
        }

        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>s
        public IEnumerable<T> GetView(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return GetViewAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetViewAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.GetViewAsync<T>(param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.GetViewAsync<T>(param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public T GetViewFirstOrDefault(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return GetViewFirstOrDefaultAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public async Task<T> GetViewFirstOrDefaultAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.GetViewFirstOrDefaultAsync<T>(param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.GetViewFirstOrDefaultAsync<T>(param, transaction, commandTimeout);
            }
        }

        // INSERT
        #region INSERT

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        public int Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return InsertAsync(entity, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        public async Task<int> InsertAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.InsertAsync(entity, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.InsertAsync(entity, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        public int Insert(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return InsertAsync(entities, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        public async Task<int> InsertAsync(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.InsertAsync(entities, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.InsertAsync(entities, transaction, commandTimeout);
            }
        }

        #endregion

        // UPDATE
        #region UPDATE

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        public int Update(T entity, T param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return UpdateAsync(entity, param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        public async Task<int> UpdateAsync(T entity, T param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.UpdateAsync(entity, param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.UpdateAsync(entity, param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        public int Update(T entity, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return UpdateAsync(entity, param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        public async Task<int> UpdateAsync(T entity, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.UpdateAsync(entity, param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.UpdateAsync(entity, param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        public int Update(object entity, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return UpdateAsync(entity, param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        public async Task<int> UpdateAsync(object entity, object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.UpdateAsync(entity, param, typeof(T), transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.UpdateAsync(entity, param, typeof(T), transaction, commandTimeout);
            }
        }

        #endregion

        // DELETE
        #region DELETE

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public int Delete(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return DeleteAsync(entity, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public async Task<int> DeleteAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.DeleteAsync<T>(entity, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.DeleteAsync<T>(entity, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public int Delete(object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return DeleteAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public async Task<int> DeleteAsync(object param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            if (transaction is null)
            {
                using var connection = _dbConnection;
                return await connection.DeleteAsync<T>(param, transaction, commandTimeout);
            }
            else
            {
                return await transaction.Connection.DeleteAsync<T>(param, transaction, commandTimeout);
            }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public int Delete(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return DeleteAsync(entities, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public async Task<int> DeleteAsync(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            int deletedCount = 0;

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    deletedCount += await DeleteAsync(item, transaction, commandTimeout);
                }
            }

            return deletedCount;
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public int Delete(IEnumerable<object> param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return DeleteAsync(param, transaction, commandTimeout).GetAwaiter().GetResult();
        }
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        public async Task<int> DeleteAsync(IEnumerable<object> param, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            int deletedCount = 0;

            if (param != null)
            {
                foreach (var item in param)
                {
                    deletedCount += await DeleteAsync(item, transaction, commandTimeout);
                }
            }

            return deletedCount;
        }

        #endregion


    }
}
