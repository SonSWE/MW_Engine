using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace OracleHelpers
{
    public interface IOracleHelper
    {
        IDbConnection GetConnection(string connectionString);
        IDbTransaction GetTransaction(string connectionString);

        int ExecuteBatchNonQuery(string connectionString, CommandType commandType, string commandText, int numItem, params OracleParameter[] commandParameters);
        int ExecuteBatchNonQuery(IDbConnection connection, CommandType commandType, string commandText, int numItem, params OracleParameter[] commandParameters);
        int ExecuteBatchNonQuery(IDbTransaction transaction, CommandType commandType, string commandText, int numItem, params OracleParameter[] commandParameters);

        Task<int> ExecuteBatchNonQueryAsync(string connectionString, CommandType commandType, string commandText, int numItem, CancellationToken token = default);
        Task<int> ExecuteBatchNonQueryAsync(IDbConnection connection, CommandType commandType, string commandText, int numItem, CancellationToken token = default);
        Task<int> ExecuteBatchNonQueryAsync(IDbTransaction transaction, CommandType commandType, string commandText, int numItem, CancellationToken token = default);
        Task<int> ExecuteBatchNonQueryAsync(string connectionString, CommandType commandType, string commandText, int numItem, OracleParameter[] commandParameters, CancellationToken token = default);
        Task<int> ExecuteBatchNonQueryAsync(IDbConnection connection, CommandType commandType, string commandText, int numItem, OracleParameter[] commandParameters, CancellationToken token = default);
        Task<int> ExecuteBatchNonQueryAsync(IDbTransaction transaction, CommandType commandType, string commandText, int numItem, OracleParameter[] commandParameters, CancellationToken token = default);


        int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText);
        int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string commandText);
        int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, string commandText);
        int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters);

        Task<int> ExecuteNonQueryAsync(string connectionString, CommandType commandType, string commandText, CancellationToken token = default);
        Task<int> ExecuteNonQueryAsync(string connectionString, CommandType commandType, string commandText, OracleParameter[] commandParameters, CancellationToken token = default);
        Task<int> ExecuteNonQueryAsync(IDbConnection connection, CommandType commandType, string commandText, CancellationToken token = default);
        Task<int> ExecuteNonQueryAsync(IDbConnection connection, CommandType commandType, string commandText, OracleParameter[] commandParameters, CancellationToken token = default);
        Task<int> ExecuteNonQueryAsync(IDbTransaction transaction, CommandType commandType, string commandText, CancellationToken token = default);
        Task<int> ExecuteNonQueryAsync(IDbTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters, CancellationToken token = default);

        DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText);
        DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        DataSet ExecuteDataset(IDbConnection connection, CommandType commandType, string commandText);
        DataSet ExecuteDataset(IDbConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        DataSet ExecuteDataset(IDbTransaction transaction, CommandType commandType, string commandText);
        DataSet ExecuteDataset(IDbTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters);

        Task<DataSet> ExecuteDatasetAsync(string connectionString, CommandType commandType, string commandText, CancellationToken token = default);
        Task<DataSet> ExecuteDatasetAsync(string connectionString, CommandType commandType, string commandText, OracleParameter[] commandParameters, CancellationToken token = default);
        Task<DataSet> ExecuteDatasetAsync(IDbConnection connection, CommandType commandType, string commandText, CancellationToken token = default);
        Task<DataSet> ExecuteDatasetAsync(IDbConnection connection, CommandType commandType, string commandText, OracleParameter[] commandParameters, CancellationToken token = default);
        Task<DataSet> ExecuteDatasetAsync(IDbTransaction transaction, CommandType commandType, string commandText, CancellationToken token = default);
        Task<DataSet> ExecuteDatasetAsync(IDbTransaction transaction, CommandType commandType, string commandText, OracleParameter[] commandParameters, CancellationToken token = default);

        OracleDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText);
        OracleDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        OracleDataReader ExecuteReader(IDbConnection connection, CommandType commandType, string commandText);
        OracleDataReader ExecuteReader(IDbConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        OracleDataReader ExecuteReader(IDbTransaction transaction, CommandType commandType, string commandText);
        OracleDataReader ExecuteReader(IDbTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters);

        object ExecuteScalar(string connectionString, CommandType commandType, string commandText);
        object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        object ExecuteScalar(IDbConnection connection, CommandType commandType, string commandText);
        object ExecuteScalar(IDbConnection connection, CommandType commandType, string commandText, params OracleParameter[] commandParameters);
        object ExecuteScalar(IDbTransaction transaction, CommandType commandType, string commandText);
        object ExecuteScalar(IDbTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters);

        void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames);
        void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params OracleParameter[] commandParameters);
        void FillDataset(IDbConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames);
        void FillDataset(IDbConnection connection, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params OracleParameter[] commandParameters);
        void FillDataset(IDbTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames);
        void FillDataset(IDbTransaction transaction, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames, params OracleParameter[] commandParameters);

        void UpdateDataset(OracleCommand insertCommand, OracleCommand deleteCommand, OracleCommand updateCommand, DataSet dataSet, string tableName);
    }
}
