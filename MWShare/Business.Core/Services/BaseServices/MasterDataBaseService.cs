using Business.Core.Validators;
using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core.Interfaces;
using FluentValidation.Results;
using MemoryData;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using DataAccess.Core.Helpers;
using System.Linq;
using System.Threading.Channels;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.Services.BaseServices
{
    public class MasterDataBaseService<T> : IMasterDataBaseService<T> where T : MasterDataBase, new()
    {
        public virtual string ProfileKeyField { get; } = "Id";
        public IMasterDataBaseBL<T> MasterDataBaseBL { get; private set; }
        public IDbManagement DbManagement { get; private set; }

        public MasterDataBaseService(IMasterDataBaseBL<T> masterDataBaseBL, IDbManagement dbManagement)
        {
            MasterDataBaseBL = masterDataBaseBL;
            DbManagement = dbManagement;
        }

        //
        public virtual BaseValidator<T> GetValidator(IDbTransaction transaction, ValidationAction validationAction, ClientInfo clientInfo, T dataToValidate, T oldData)
        {
            return new BaseValidator<T>();
        }

        // DELETE
        #region DELETE

        public virtual void BeforeDelete(IDbTransaction transaction, T oldData, T deleteData)
        {
            MasterDataBaseBL.BeforeDelete(transaction, oldData, deleteData);
        }
        /// <summary>
        /// Check bản ghi trước khi xóa - MINHDV SSI
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="oldData"></param>
        /// <param name="clientInfo"></param>
        /// <param name="resCode"></param>
        /// <param name="resMessage"></param>
        /// <returns></returns>
        public virtual bool ValidateDelete(IDbTransaction transaction, T oldData, ClientInfo clientInfo, out long resCode, out string resMessage)
        {
            var resValid = MasterDataBaseBL.ValidateDelete(transaction, oldData, clientInfo, out resCode, out resMessage);
            return resValid;
        }

        public virtual long Delete(string id, ClientInfo clientInfo)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var result = Delete(transaction, id, clientInfo);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public virtual long Delete(IDbTransaction transaction, string id, ClientInfo clientInfo)
        {
            if (string.IsNullOrEmpty(id))
            {
                return ErrorCodes.Err_InvalidData;
            }

            var oldData = MasterDataBaseBL.GetDetailById(transaction, id);
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }

            //
            var deleteData = oldData.Clone();

            BeforeDelete(transaction, oldData, deleteData);

            // Validate Delete
            if (!ValidateDelete(transaction, oldData, clientInfo, out var validateResCode, out var validateResMessage))
            {
                return validateResCode;
            }

            //
            var result = MasterDataBaseBL.Delete(transaction, deleteData, clientInfo);

            return result;
        }
        #endregion

        // GET
        #region GET
        public T GetDetailById(string id)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            return GetDetailById(transaction, id);
        }

        public T GetDetailById(IDbTransaction transaction, string id)
        {
            return MasterDataBaseBL.GetDetailById(transaction, id);
        }
        #endregion

        // CREATE
        #region CREATE

        public virtual void BeforeCreate(IDbTransaction transaction, T data)
        {
            MasterDataBaseBL.BeforeCreate(transaction, data);
        }

        public virtual bool ValidateCreate(IDbTransaction transaction, T data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {

            resCode = 0;
            resMessage = string.Empty;
            return true;
        }

        public virtual bool OnCreated(IDbTransaction transaction, T data, ClientInfo clientInfo, out long resCode, out string resMessage)
        {
            resCode = 0;
            resMessage = string.Empty;
            return true;
        }

        public virtual long Create(T data, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var result = Create(transaction, data, clientInfo, out resMessage, out propertyName);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public virtual long Create(IDbTransaction transaction, T data, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            resMessage = string.Empty;
            propertyName = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            data.TrimStringProperty();

            data.CreateBy = clientInfo?.UserName ?? string.Empty;
            data.CreateDate = clientInfo?.ActionTime ?? DateTime.Now;

            //
            BeforeCreate(transaction, data);

            // Validate Create
            if (!ValidateCreate(transaction, data, clientInfo, out var validateResCode, out var validateResMessage))
            {
                return validateResCode;
            }

            // 
            var validator = GetValidator(transaction, ValidationAction.Create, clientInfo, data, null);
            var validationResult = validator.Validate(data);

            if (validationResult.IsValid)
            {
                var result = MasterDataBaseBL.Insert(transaction, data, clientInfo);

                return result;
            }
            else
            {
                var firstError = validationResult.Errors.First();
                resMessage = firstError.ErrorMessage;
                _ = long.TryParse(firstError.ErrorCode, out long errorCode);
                propertyName = firstError.PropertyName?.ToCamelCase();
                return errorCode;
            }
        }

        #endregion

        // UPDATE
        #region UPDATE

        public virtual void BeforeUpdate(IDbTransaction transaction, T oldData, T newData)
        {
            MasterDataBaseBL.BeforeUpdate(transaction, oldData, newData);
        }

        public virtual bool ValidateUpdate(IDbTransaction transaction, T oldData, T newData, ClientInfo clientInfo, out long resCode, out string resMessage)
        {

            resMessage = string.Empty;
            return MasterDataBaseBL.ValidateUpdate(transaction, newData, oldData, out resCode);
        }

        public virtual long Update(T data, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            var result = Update(transaction, data, clientInfo, out resMessage, out propertyName);

            if (result > 0)
            {
                transaction.Commit();
            }
            else
            {
                transaction.Rollback();
            }

            return result;
        }

        public virtual long Update(IDbTransaction transaction, T data, ClientInfo clientInfo, out string resMessage, out string propertyName)
        {
            resMessage = string.Empty;
            propertyName = string.Empty;

            if (data == null)
            {
                return ErrorCodes.Err_DataNull;
            }

            // Lay thong tin cu ra check
            var oldData = MasterDataBaseBL.GetDetailById(transaction, data.GetPropertyValue(ProfileKeyField)?.ToString());
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                return ErrorCodes.Err_NotFound;
            }

            //
            data.TrimStringProperty();

            data.LastChangeBy = clientInfo?.UserName ?? string.Empty;
            data.LastChangeDate = clientInfo?.ActionTime ?? DateTime.Now;


            //
            BeforeUpdate(transaction, oldData, data);

            // Validate Update
            if (!ValidateUpdate(transaction, oldData, data, clientInfo, out var validateResCode, out var validateResMessage))
            {
                return validateResCode;
            }

            //
            var validator = GetValidator(transaction, ValidationAction.Update, clientInfo, data, oldData);
            var validationResult = validator.Validate(data);

            if (validationResult.IsValid)
            {
                long result = MasterDataBaseBL.Update(transaction, data, clientInfo);

                return result;
            }
            else
            {
                var firstError = validationResult.Errors.First();
                resMessage = firstError.ErrorMessage;
                _ = long.TryParse(firstError.ErrorCode, out long errorCode);
                propertyName = firstError.PropertyName?.ToCamelCase();
                return errorCode;
            }
        }

        #endregion

        /// <summary>
        /// Hàm check xem Id của bảng đã tồn tại chưa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MasterDataBaseCheckDuplicateIdResponse CheckDuplicateId(string id)
        {
            using var connection = DbManagement.GetConnection();
            using var transaction = connection.BeginTransaction();

            return CheckDuplicateId(transaction, id);
        }

        /// <summary>
        /// Hàm check xem Id của bảng đã tồn tại chưa
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public MasterDataBaseCheckDuplicateIdResponse CheckDuplicateId(IDbTransaction transaction, string id)
        {
            return MasterDataBaseBL.CheckDuplicateId(transaction, id);
        }
    }
}
