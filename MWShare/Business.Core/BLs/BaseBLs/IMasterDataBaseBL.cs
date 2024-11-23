using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace Business.Core.BLs.BaseBLs
{
    public interface IMasterDataBaseBL<T> where T : MasterDataBase, new()
    {
        IBaseDA<T> _baseDA { get; set; }
        IDbManagement DbManagement { get; }
        string DbTable { get; }
        ILoggingManagement LoggingManagement { get; }
        string ProfileKeyField { get; }
        string RequestId { get; }

        void BeforeCreate(IDbTransaction transaction, T data);
        void BeforeDelete(IDbTransaction transaction, T oldData, T deleteData);
        void BeforeUpdate(IDbTransaction transaction, T oldData, T newData);
        void BeforeUpdate(T data);
        long Delete(IDbTransaction transaction, T data, ClientInfo clientInfo);
        long DeleteChildData(IDbTransaction transaction, string id, T cancelData, ClientInfo clientInfo);
        long DeleteData(IDbTransaction transaction, T data, ClientInfo clientInfo);
        List<T> Get(IDbTransaction transaction, object param);
        T GetDetailById(IDbTransaction transaction, string id);
        T GetFirstOrDefault(IDbTransaction transaction, object param);
        List<T> GetView(IDbTransaction transaction, object param);
        T GetViewFirstOrDefault(IDbTransaction transaction, object param);
        long Insert(IDbTransaction transaction, T data, ClientInfo clientInfo);
        long InsertChildData(IDbTransaction transaction, T data, T oldData, ClientInfo clientInfo);
        long InsertData(IDbTransaction transaction, T data, ClientInfo clientInfo);
        long Update(IDbTransaction transaction, T data, ClientInfo clientInfo);
        long UpdateChildData(IDbTransaction transaction, T data, T oldData, ClientInfo clientInfo);
        long UpdateData(IDbTransaction transaction, T data, T oldData, ClientInfo clientInfo);
        bool ValidateDelete(IDbTransaction transaction, T oldData, ClientInfo clientInfo, out long resCode, out string resMessage);
        bool ValidateDelete(IDbTransaction transaction, T oldData, ClientInfo clientInfo, out long resCode);
        bool ValidateInsert(IDbTransaction transaction, string id, out long resCode);
        bool ValidateInsert(IDbTransaction transaction, T insertData, out long resCode);
        bool ValidateUpdate(IDbTransaction transaction, string id, out long resCode);
        bool ValidateUpdate(IDbTransaction transaction, T data, T oldData, out long resCode);
        MasterDataBaseCheckDuplicateIdResponse CheckDuplicateId(IDbTransaction transaction, string id);
    }
}