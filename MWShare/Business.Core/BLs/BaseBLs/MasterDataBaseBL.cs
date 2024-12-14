using CommonLib;
using CommonLib.Constants;
using CommonLib.Extensions;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Extensions;
using DataAccess.Core.Helpers;
using DataAccess.Core.Interfaces;
using DataAccess.Helpers;
using MemoryData;
using Object.Core;
using Object.Core.CustomAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Business.Core.BLs.BaseBLs
{


    public class MasterDataBaseBL<T> : IMasterDataBaseBL<T> where T : MasterDataBase, new()
    {
        public virtual string ProfileKeyField { get; } = string.Empty;
        public virtual string DbTable => string.Empty;

        public virtual IDbManagement DbManagement { get; private set; }
        public virtual ILoggingManagement LoggingManagement { get; private set; }
        public string RequestId => LoggingManagement.RequestId;

        public IBaseDA<T> _baseDA { get; set; }

        public MasterDataBaseBL(IDbManagement dbManagement, ILoggingManagement loggingManagement)
        {
            DbManagement = dbManagement;
            LoggingManagement = loggingManagement;
            _baseDA = dbManagement.GetService<IBaseDA<T>>();
        }


        // GET
        #region GET
        //lấy danh sách theo điều kiện
        public virtual List<T> Get(IDbTransaction transaction, object param)
        {
            return _baseDA.Get(param, transaction)?.ToList();
        }

        //lấy 1 object theo điều kiện
        public virtual T GetFirstOrDefault(IDbTransaction transaction, object param)
        {
            return _baseDA.GetFirstOrDefault(param, transaction);
        }

        //lấy danh sách view theo điều kiện
        public virtual List<T> GetView(IDbTransaction transaction, object param)
        {
            return _baseDA.GetView(param, transaction)?.ToList();
        }

        //Lây 1 object view theo điều kiện
        public virtual T GetViewFirstOrDefault(IDbTransaction transaction, object param)
        {
            return _baseDA.GetViewFirstOrDefault(param, transaction);
        }

        //lấy bản ghi theo id
        public virtual T GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] Start. id=[{id}]]");

            //
            var param = new Dictionary<string, object>
            {
                { ProfileKeyField, id},
            };

            var result = GetViewFirstOrDefault(transaction, param);

            //
            Logger.log.Info($"[{RequestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");
            return result;
        }
        #endregion

        // INSERT
        #region INSERT
        public virtual long Insert(IDbTransaction transaction, T data, ClientInfo clientInfo)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] Start. data=[{JsonHelper.Serialize(data)}]");

            long result = ErrorCodes.Err_Unknown;

            if (data == null)
            {
                result = ErrorCodes.Err_DataNull;
                goto endFunc;
            }
            BeforeCreate(transaction, data);
            //
            string id = data.GetPropertyValue(ProfileKeyField)?.ToString();

            if (!ValidateInsert(transaction, data, out var checkResCode))
            {
                result = checkResCode;
                goto endFunc;
            }

            //
            T oldData = GetDetailById(transaction, id) ?? new();

            data.TrimStringProperty();

            //
            result = InsertData(transaction, data, clientInfo);

            //
            if (result > 0)
            {
                result = InsertChildData(transaction, data, oldData, clientInfo);
            }
        //
        endFunc:
            Logger.log.Info($"[{RequestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");
            return result;
        }

        public virtual long InsertData(IDbTransaction transaction, T data, ClientInfo clientInfo)
        {
            int insertCount = _baseDA.Insert(data, transaction);
            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }

        /// <summary>
        /// Thực hiện insert data cho bảng child trong master data
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="transaction"></param>
        /// <param name="data"></param>
        /// <param name="oldData"></param>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public virtual long InsertChildData(IDbTransaction transaction, T data, T oldData, ClientInfo clientInfo)
        {
            // Lấy ra tất cả props có đánh Attribute IsDetailTable = true và IgnoreInsert = false
            var props = typeof(T).GetProperties()
                .Where(x => x.GetCustomAttribute<DbFieldAttribute>() != null
                && x.GetCustomAttribute<DbFieldAttribute>().IsDetailTable
                && !x.GetCustomAttribute<DbFieldAttribute>().IgnoreInsert);
            // Thực hiện insert đối với những dữ liệu details
            var resCodes = new List<long>();
            foreach (var prop in props)
            {
                var insertData = prop.GetValue(data);

                // Hiện tại đáp ứng cho List Details 
                if (insertData is IEnumerable)
                {
                    // Lấy ra type của từng phần tử con
                    var type = insertData.GetType().GetGenericArguments()[0];
                    foreach (var item in (IEnumerable)insertData)
                    {
                        resCodes.Add(transaction.Connection.Insert(item, type, transaction));
                    }
                }
            }
            if (resCodes.All(x => x > 0))
            {
                return ErrorCodes.Success;
            }
            else
            {
                return ErrorCodes.Err_ChildData;
            }

        }

        #endregion

        // DELETE
        #region DELETE

        public virtual long Delete(IDbTransaction transaction, T data, ClientInfo clientInfo)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] Start. data=[{JsonHelper.Serialize(data)}]");

            long result = ErrorCodes.Err_Unknown;

            if (data == null)
            {
                result = ErrorCodes.Err_DataNull;
                goto endFunc;
            }

            //
            string id = data.GetPropertyValue(ProfileKeyField)?.ToString();

            //
            T oldData = GetDetailById(transaction, id) ?? new();
            if (oldData == null)
            {
                result = ErrorCodes.Err_DataNull;
                goto endFunc;
            }

            //
            if (!ValidateDelete(transaction, oldData, clientInfo, out var checkResCode))
            {
                result = checkResCode;
                goto endFunc;
            }

            //
            result = DeleteChildData(transaction, id, oldData, clientInfo);

            //
            if (result > 0)
            {
                result = DeleteData(transaction, data, clientInfo);
            }
        //
        endFunc:
            Logger.log.Info($"[{RequestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");
            return result;
        }

        public virtual long DeleteData(IDbTransaction transaction, T data, ClientInfo clientInfo)
        {
            int insertCount = _baseDA.Delete(data, transaction);
            return insertCount > 0 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }

        public virtual long DeleteChildData(IDbTransaction transaction, string id, T cancelData, ClientInfo clientInfo)
        {
            // Lấy ra tất cả props có đánh Attribute IsDetailTable = true và IgnoreInsert = false
            var props = typeof(T).GetProperties()
                .Where(x => x.GetCustomAttribute<DbFieldAttribute>() != null
                && x.GetCustomAttribute<DbFieldAttribute>().IsDetailTable
                && !x.GetCustomAttribute<DbFieldAttribute>().IgnoreInsert);
            // Thực hiện xóa đối với những dữ liệu details
            var resCodes = new List<long>();
            foreach (var prop in props)
            {
                var insertData = prop.GetValue(cancelData);
                // Hiện tại đáp ứng cho List Details 
                if (insertData is IEnumerable)
                {
                    // Lấy ra type của từng phần tử con
                    var type = insertData.GetType().GetGenericArguments()[0];
                    foreach (var item in (IEnumerable)insertData)
                    {
                        resCodes.Add(transaction.Connection.Delete(item, type, transaction));
                    }
                }
            }
            if (resCodes.All(x => x >= 0))
            {
                return ErrorCodes.Success;
            }
            else
            {
                return ErrorCodes.Err_ChildData;
            }

        }

        #endregion

        // UPDATE
        #region UPDATE
        /// <summary>
        /// Xử lý lại data trước khi save
        /// </summary>
        /// <param name="data"></param>
        public virtual void BeforeUpdate(T data)
        {
        }

        public virtual long Update(IDbTransaction transaction, T data, ClientInfo clientInfo)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] Start. data=[{JsonHelper.Serialize(data)}]");

            long result = ErrorCodes.Err_Unknown;

            if (data == null)
            {
                result = ErrorCodes.Err_DataNull;
                goto endFunc;
            }


            //
            data.TrimStringProperty();

            //
            string id = data.GetPropertyValue(ProfileKeyField)?.ToString();

            T oldData = GetDetailById(transaction, id) ?? new();
            if (oldData == null || string.IsNullOrEmpty(oldData.GetPropertyValue(ProfileKeyField)?.ToString()))
            {
                result = ErrorCodes.Err_NotFound;
                goto endFunc;
            }

            //
            if (!ValidateUpdate(transaction, data, oldData, out var checkResCode))
            {
                result = checkResCode;
                goto endFunc;
            }

            //
            result = UpdateData(transaction, data, oldData, clientInfo);

            //
            if (result > 0)
            {
                result = UpdateChildData(transaction, data, oldData, clientInfo);
            }

        //
        endFunc:
            Logger.log.Info($"[{RequestId}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");
            return result;
        }

        public virtual long UpdateData(IDbTransaction transaction, T data, T oldData, ClientInfo clientInfo)
        {
            var param = new T();
            param.SetPropertyValue(ProfileKeyField, data.GetPropertyValue(ProfileKeyField));

            int updatedCount = _baseDA.Update(data, param, transaction);
            return updatedCount == 1 ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        }

        /// <summary>
        /// Hàm xử lý cập nhật thông tin bảng phụ.
        /// B1: Xóa thông tin cũ 
        /// B2: Insert thong tin mới
        /// </summary>
        /// <param name="RequestId"></param>
        /// <param name="transaction"></param>
        /// <param name="data"></param>
        /// <param name="oldData"></param>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public virtual long UpdateChildData(IDbTransaction transaction, T data, T oldData, ClientInfo clientInfo)
        {
            long result = ErrorCodes.Success;

            // B1: Xoa thong tin cu
            if (result > 0)
            {
                string id = oldData.GetPropertyValue(ProfileKeyField)?.ToString();

                result = DeleteChildData(transaction, id, oldData, clientInfo);
            }

            // B2: Them thong tin moi
            if (result > 0)
            {
                result = InsertChildData(transaction, data, oldData, clientInfo);
            }

            return result;


        }

        #endregion

        public virtual bool ValidateInsert(IDbTransaction transaction, T insertData, out long resCode)
        {
            string id = insertData.GetPropertyValue(ProfileKeyField)?.ToString();

            return ValidateInsert(transaction, id, out resCode);
        }

        public virtual bool ValidateInsert(IDbTransaction transaction, string id, out long resCode)
        {
            resCode = 0;

            //Key của bảng không phân biệt hoa, thường
            var existedDatas = transaction.Connection.Query<T>($@"SELECT * FROM {DbTable} WHERE UPPER({ProfileKeyField}) = :id", new { id = id.ToUpper() }, transaction).ToList() ?? new();

            if (existedDatas.Count > 0)
            {
                resCode = ErrorCodes.Err_Existed;
                return false;
            }

            return true;
        }

        public virtual bool ValidateUpdate(IDbTransaction transaction, T data, T oldData, out long resCode)
        {
            string id = data.GetPropertyValue(ProfileKeyField)?.ToString();

            return ValidateUpdate(transaction, id, out resCode);
        }

        public virtual bool ValidateUpdate(IDbTransaction transaction, string id, out long resCode)
        {
            resCode = 0;

            //Key của bảng không phân biệt hoa, thường
            var existedDatas = transaction.Connection.Query<T>($@"SELECT * FROM {DbTable} WHERE UPPER({ProfileKeyField}) = :id", new { id = id.ToUpper() }, transaction).ToList() ?? new();

            if (existedDatas.Count > 1)
            {
                resCode = ErrorCodes.Err_Existed;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Thực hiện validate bản ghi trước khi xóa, check reference 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="id"></param>
        /// <param name="cancelData"></param>
        /// <param name="clientInfo"></param>
        /// <param name="resCode"></param>
        /// <returns></returns>
        public virtual bool ValidateDelete(IDbTransaction transaction, T oldData, ClientInfo clientInfo, out long resCode, out string resMessage)
        {
            resCode = 0;
            resMessage = string.Empty;
            return true;
        }

        public virtual bool ValidateDelete(IDbTransaction transaction, T oldData, ClientInfo clientInfo, out long resCode)
        {
            resCode = 0;
            return true;
        }

        /// <summary>
        /// Xử lý dữ liệu trước khi save xuống DB
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="data"></param>
        public virtual void BeforeCreate(IDbTransaction transaction, T data)
        {

        }


        /// <summary>
        /// Xử lý dữ liệu trước khi delete
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="data"></param>
        public virtual void BeforeDelete(IDbTransaction transaction, T oldData, T deleteData)
        {

        }


        /// <summary>
        /// Xử lý dữ liệu trước khi Update
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        /// <param name="isCorrect"></param>
        public virtual void BeforeUpdate(IDbTransaction transaction, T oldData, T newData)
        {

        }

        /// <summary>
        /// Hàm check xem Id của bảng đã tồn tại chưa
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual MasterDataBaseCheckDuplicateIdResponse CheckDuplicateId(IDbTransaction transaction, string id)
        {
            var existedDatas = Get(transaction, new Dictionary<string, object>
            {
                { ProfileKeyField, id },
            });

            var response = new MasterDataBaseCheckDuplicateIdResponse
            {
                IsDuplicated = false,
            };

            if (existedDatas != null && existedDatas.Count > 0)
            {
                response.IsDuplicated = true;
            }

            return response;
        }
    }
}
