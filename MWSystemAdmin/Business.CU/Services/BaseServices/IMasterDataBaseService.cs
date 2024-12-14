using Business.Core.BLs.BaseBLs;
using Business.Core.Validators;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using Object.Core;
using System.Collections.Generic;
using System.Data;

namespace Business.Core.Services.BaseServices
{
    public interface IMasterDataBaseService<T> where T : MasterDataBase, new()
    {
        IDbManagement DbManagement { get; }
        IMasterDataBaseBL<T> MasterDataBaseBL { get; }
        string ProfileKeyField { get; }

        void BeforeCreate(IDbTransaction transaction, T data);
        void BeforeDelete(IDbTransaction transaction, T oldData, T deleteData);
        void BeforeUpdate(IDbTransaction transaction, T oldData, T newData);
        MasterDataBaseCheckDuplicateIdResponse CheckDuplicateId(IDbTransaction transaction, string id);
        MasterDataBaseCheckDuplicateIdResponse CheckDuplicateId(string id);
        long Create(IDbTransaction transaction, T data, ClientInfo clientInfo, out string resMessage, out string propertyName);
        long Create(T data, ClientInfo clientInfo, out string resMessage, out string propertyName);
        long Delete(IDbTransaction transaction, string id, ClientInfo clientInfo);
        long Delete(string id, ClientInfo clientInfo);
        T GetDetailById(IDbTransaction transaction, string id);
        T GetDetailById(string id);
        BaseValidator<T> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, T dataToValidate, T oldData);
        bool OnCreated(IDbTransaction transaction, T data, ClientInfo clientInfo, out long resCode, out string resMessage);
        long Update(IDbTransaction transaction, T data, ClientInfo clientInfo, out string resMessage, out string propertyName);
        long Update(T data, ClientInfo clientInfo, out string resMessage, out string propertyName);
        bool ValidateCreate(IDbTransaction transaction, T data, ClientInfo clientInfo, out long resCode, out string resMessage);
        bool ValidateDelete(IDbTransaction transaction, T oldData, ClientInfo clientInfo, out long resCode, out string resMessage);
        bool ValidateUpdate(IDbTransaction transaction, T oldData, T newData, ClientInfo clientInfo, out long resCode, out string resMessage);
    }
}
