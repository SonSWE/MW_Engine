using Dapper;
using DapperLib.SqlGenerator.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Core.Abtractions
{
    public interface IBaseDA<T> where T : class, new()
    {
        int Count(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<int> CountAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);

        int Count(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        IEnumerable<T> Get(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T GetFirstOrDefault(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<T> GetFirstOrDefaultAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>s
        IEnumerable<T> GetView(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Get list data
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetViewAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T GetViewFirstOrDefault(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Get first data or default
        /// </summary>
        /// <param name="param">filter params in key/value format (Object, Dictionary)</param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<T> GetViewFirstOrDefaultAsync(object param = null, IDbTransaction transaction = null, int? commandTimeout = null);

        // INSERT
        #region INSERT

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        int Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        Task<int> InsertAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        int Insert(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows inserted</returns>
        Task<int> InsertAsync(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null);

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
        int Update(T entity, T param, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        Task<int> UpdateAsync(T entity, T param, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        int Update(T entity, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        Task<int> UpdateAsync(T entity, object param, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        int Update(object entity, object param, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows updated</returns>
        Task<int> UpdateAsync(object entity, object param, IDbTransaction transaction = null, int? commandTimeout = null);

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
        int Delete(T entity, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        Task<int> DeleteAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        int Delete(object param, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        Task<int> DeleteAsync(object param, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        int Delete(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        Task<int> DeleteAsync(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null);

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        int Delete(IEnumerable<object> param, IDbTransaction transaction = null, int? commandTimeout = null);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>number of rows deleted</returns>
        Task<int> DeleteAsync(IEnumerable<object> param, IDbTransaction transaction = null, int? commandTimeout = null);

        #endregion
    }
}
