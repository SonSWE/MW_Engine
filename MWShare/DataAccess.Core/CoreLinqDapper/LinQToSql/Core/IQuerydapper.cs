using DapperLib.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperLib.LinQToSql.Core
{
    public interface IQuerydapper<T>
    {
        IQuerydapper<T> Set<H>(H param, bool condition = true) where H : class;
        void SetParam(Dictionary<string,object> dic);
        IQuerydapper<T> Set(string express, Action<Dictionary<string, object>>? param = null, bool condition = true);
        IQuerydapper<T> Set<TResult>(Expression<Func<T, TResult>> column, TResult value, bool condition = true);
        IQuerydapper<T> Set<TResult>(Expression<Func<T, TResult>> column, Expression<Func<T, TResult>> expression, bool condition = true);
        IQuerydapper<T> GroupBy(string expression, bool condition = true);
        IQuerydapper<T> GroupBy<TResult>(Expression<Func<T, TResult>> expression, bool condition = true);
        IQuerydapper<T> Where(string expression, Action<Dictionary<string, object>>? action = null, bool condition = true);
        IQuerydapper<T> Where(Expression<Func<T, bool>> expression, bool condition = true);
        IQuerydapper<T> OrderBy(string orderBy, bool condition = true);
        IQuerydapper<T> OrderBy<TResult>(Expression<Func<T, TResult>> expression, bool condition = true);
        IQuerydapper<T> OrderByDescending<TResult>(Expression<Func<T, TResult>> expression, bool condition = true);
        IQuerydapper<T> Skip(int index, int count, bool condition = true);
        IQuerydapper<T> Take(int count);
        IQuerydapper<T> Page(int index, int count, out long total, bool condition = true);
        IQuerydapper<T> Having(string expression, bool condition = true);
        IQuerydapper<T> Having(Expression<Func<T, bool>> expression, bool condition = true);
        IQuerydapper<T> Filter<TResult>(Expression<Func<T, TResult>> columns, bool condition = true);
        IQuerydapper<T> With(string lockType, bool condition = true);
        IQuerydapper<T> With(LockType lockType, bool condition = true);
        IQuerydapper<T> Distinct(bool condition = true);
        T? Single(string columns = "", bool buffered = true, int? timeout = null);
        Task<T?> SingleAsync(string columns = "", int? timeout = null);
        TResult? Single<TResult>(string columns = "", bool buffered = true, int? timeout = null);
        Task<TResult?> SingleAsync<TResult>(string columns = "", int? timeout = null);
        TResult? Single<TResult>(Expression<Func<T, TResult>> columns, bool buffered = true, int? timeout = null);
        Task<TResult?> SingleAsync<TResult>(Expression<Func<T, TResult>> columns, int? timeout = null);
        IEnumerable<T> Select(string colums = "", bool buffered = true, int? timeout = null);
        
        Task<IEnumerable<T>> SelectAsync(string colums = "", int? timeout = null);
        IEnumerable<TResult> Select<TResult>(string colums = "", bool buffered = true, int? timeout = null);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(string colums = "", int? timeout = null);
        IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> columns, bool buffered = true, int? timeout = null);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> columns, int? timeout = null);


        ResultSelect? GetBuildSelect(string columns = "", bool buffered = true, int? timeout = null);
        int Insert(T entity, bool condition = true, int? timeout = null);
        Task<int> InsertAsync(T entity, bool condition = true, int? timeout = null);
        long InsertReturnId(T entity, bool condition = true, int? timeout = null);
        Task<long> InsertReturnIdAsync(T entity, bool condition = true, int? timeout = null);
        int Insert(IEnumerable<T> entitys, bool condition = true, int? timeout = null);
        Task<int> InsertAsync(IEnumerable<T> entitys, bool condition = true, int? timeout = null);
        int Update(bool condition = true, int? timeout = null);
        Task<int> UpdateAsync(bool condition = true, int? timeout = null);
        int Update(T entity, bool condition = true, int? timeout = null);
        Task<int> UpdateAsync(T entity, bool condition = true, int? timeout = null);
        int Update(IEnumerable<T> entitys, bool condition = true, int? timeout = null);
        Task<int> UpdateAsync(IEnumerable<T> entitys, bool condition = true, int? timeout = null);
        int Delete(bool condition = true, int? timeout = null);
        Task<int> DeleteAsync(bool condition = true, int? timeout = null);
        bool Exists(bool condition = true, int? timeout = null);
        Task<bool> ExistsAsync(bool condition = true, int? timeout = null);
        long Count(string columns = "", bool condition = true, int? timeout = null);
        Task<long> CountAsync(string columns = "", bool condition = true, int? timeout = null);
        long Count<TResult>(Expression<Func<T, TResult>> expression, bool condition = true, int? timeout = null);
        Task<long> CountAsync<TResult>(Expression<Func<T, TResult>> expression, bool condition = true, int? timeout = null);
        TResult? Sum<TResult>(Expression<Func<T, TResult>> expression, bool condition = true, int? timeout = null);
        Task<TResult?> SumAsync<TResult>(Expression<Func<T, TResult>> expression, bool condition = true, int? timeout = null);
    }
    public interface IQueryable<T1, T2>
    {
        IQueryable<T1, T2> Join(string expression);
        IQueryable<T1, T2> Join(Expression<Func<T1, T2, bool>> expression, JoinType join = JoinType.Inner);
        IQueryable<T1, T2> GroupBy(string expression, bool condition = true);
        IQueryable<T1, T2> GroupBy<TResult>(Expression<Func<T1, T2, TResult>> expression, bool condition = true);
        IQueryable<T1, T2> Where(string expression, Action<Dictionary<string, object>>? action = null, bool condition = true);
        IQueryable<T1, T2> Where(Expression<Func<T1, T2, bool>> expression, bool condition = true);
        IQueryable<T1, T2> OrderBy(string orderBy, bool condition = true);
        IQueryable<T1, T2> OrderBy<TResult>(Expression<Func<T1, T2, TResult>> expression, bool condition = true);
        IQueryable<T1, T2> OrderByDescending<TResult>(Expression<Func<T1, T2, TResult>> expression, bool condition = true);
        IQueryable<T1, T2> Skip(int index, int count, bool condition = true);
        IQueryable<T1, T2> Take(int count);
        IQueryable<T1, T2> Page(int index, int count, out long total, bool condition = true);
        IQueryable<T1, T2> Having(string expression, bool condition = true);
        IQueryable<T1, T2> Having(Expression<Func<T1, T2, bool>> expression, bool condition = true);
        IQueryable<T1, T2> Distinct(bool condition = true);
        IEnumerable<TResult> Select<TResult>(string colums = "", bool buffered = true, int? timeout = null);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(string colums = "", int? timeout = null);
        IEnumerable<TResult> Select<TResult>(Expression<Func<T1, T2, TResult>> columns, bool buffered = true, int? timeout = null);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T1, T2, TResult>> columns, int? timeout = null);
        long Count(string columns = "", bool condition = true, int? timeout = null);
        Task<long> CountAsync(string columns = "", bool condition = true, int? timeout = null);
    }
    public interface IQueryable<T1, T2, T3>
    {
        IQueryable<T1, T2, T3> Join(string expression);
        IQueryable<T1, T2, T3> Join<E1, E2>(Expression<Func<E1, E2, bool>> expression, JoinType join = JoinType.Inner) where E1 : class where E2 : class;
        IQueryable<T1, T2, T3> GroupBy(string expression, bool condition = true);
        IQueryable<T1, T2, T3> GroupBy<TResult>(Expression<Func<T1, T2, T3, TResult>> expression, bool condition = true);
        IQueryable<T1, T2, T3> Where(string expression, Action<Dictionary<string, object>>? action = null, bool condition = true);
        IQueryable<T1, T2, T3> Where(Expression<Func<T1, T2, T3, bool>> expression, bool condition = true);
        IQueryable<T1, T2, T3> OrderBy(string orderBy, bool condition = true);
        IQueryable<T1, T2, T3> OrderBy<TResult>(Expression<Func<T1, T2, T3, TResult>> expression, bool condition = true);
        IQueryable<T1, T2, T3> OrderByDescending<TResult>(Expression<Func<T1, T2, T3, TResult>> expression, bool condition = true);
        IQueryable<T1, T2, T3> Skip(int index, int count, bool condition = true);
        IQueryable<T1, T2, T3> Take(int count);
        IQueryable<T1, T2, T3> Page(int index, int count, out long total, bool condition = true);
        IQueryable<T1, T2, T3> Having(string expression, bool condition = true);
        IQueryable<T1, T2, T3> Having(Expression<Func<T1, T2, T3, bool>> expression, bool condition = true);
        IQueryable<T1, T2, T3> Distinct(bool condition = true);
        IEnumerable<TResult> Select<TResult>(string colums = "", bool buffered = true, int? timeout = null);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(string colums = "", int? timeout = null);
        IEnumerable<TResult> Select<TResult>(Expression<Func<T1, T2, T3, TResult>> columns, bool buffered = true, int? timeout = null);
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T1, T2, T3, TResult>> columns, int? timeout = null);
        long Count(string columns = "", bool condition = true, int? timeout = null);
        Task<long> CountAsync(string columns = "", bool condition = true, int? timeout = null);
    }

    public enum LockType
    {
        FOR_UPADTE,
        LOCK_IN_SHARE_MODE,
        UPDLOCK,
        NOLOCK
    }
    public enum JoinType
    {
        Inner,
        Left,
        Right
    }
}
