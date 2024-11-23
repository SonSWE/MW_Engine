using CommonLib.Constants;
using CommonLib.Extensions;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using CommonLib;
using Object.Core;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using DataAccess.Core.SystemCodeDAs;
using DataAccess.Core.UserDAs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.BLs.UserBLs
{
    public class UserBL : MasterDataBaseBL<MWUser>, IUserBL
    {
        private readonly IUserDA _userDA;
        private readonly IUserFunctionDA _userFunctionDA;
        public override string ProfileKeyField => Const.ProfileKeyField.SystemCode;
        public override string DbTable => Const.DbTable.MWUser;

        public UserBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, IUserDA userDA, IUserFunctionDA userFunctionDA) : base(dbManagement, loggingManagement)
        {
            _userDA = userDA;
            _userFunctionDA = userFunctionDA;

        }

        //public override MWUser GetById(IDbTransaction transaction, string id, string recordStatus)
        //{
        //    var requestTime = DateTime.Now;
        //    MWUser data = base.GetById(transaction, id, recordStatus); ;
        //    //if (data != null && !string.IsNullOrEmpty(data.UserName))
        //    //{
        //    //    //Lấy thông tin SystemCodeValue
        //    //    data.FunctionSettings = _systemCodeValueDA.GetView(new
        //    //    {
        //    //        data.SystemCodeId,
        //    //        data.RecordStatus
        //    //    }, transaction).ToList() ?? new();
        //    //}
        //    Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");

        //    return data;
        //}

        //public override MWUser GetDetailById(IDbTransaction transaction, string id, string recordStatus, bool includeRefInfo = false)
        //{
        //    var requestTime = DateTime.Now;
        //    Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. branchId=[{id}]");

        //    MWUser data = base.GetDetailById(transaction, id, recordStatus, includeRefInfo);
        //    //if (data != null && !string.IsNullOrEmpty(data.SystemCodeId))
        //    //{
        //    //    //Lấy thông tin SystemCodeValue
        //    //    data.SystemCodeValues = _systemCodeValueDA.GetView(new
        //    //    {
        //    //        data.SystemCodeId,
        //    //        data.RecordStatus
        //    //    }, transaction).ToList() ?? new();

        //    //}
        //    Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


        //    return data;
        //}

        //public override MWUser GetLastById(IDbTransaction transaction, string id)
        //{
        //    var requestTime = DateTime.Now;
        //    MWUser data = base.GetLastById(transaction, id);
        //    //if (data != null && !string.IsNullOrEmpty(data.SystemCodeId))
        //    //{
        //    //    //Lấy thông tin SystemCodeValue
        //    //    data.SystemCodeValues = _systemCodeValueDA.GetView(new
        //    //    {
        //    //        data.SystemCodeId,
        //    //        data.RecordStatus
        //    //    }, transaction).ToList() ?? new();

        //    //}
        //    Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");
        //    return data;
        //}

        //public override MWUser GetLastDetailById(IDbTransaction transaction, string id, bool includeRefInfo = false)
        //{
        //    MWUser lastData = base.GetLastDetailById(transaction, id, includeRefInfo);
        //    //if (lastData != null && !string.IsNullOrEmpty(lastData.SystemCodeId))
        //    //{
        //    //    //Do trường name trên màn hình không lưu db ở bảng phụ MarketGroupDetail
        //    //    //Nên không getview theo base được mà phải join sang mcunderlying hoặc mcmarket để lấy thông tin marketname

        //    //    lastData.SystemCodeValues = _systemCodeValueDA.GetView(new
        //    //    {
        //    //        lastData.SystemCodeId,
        //    //        lastData.RecordStatus
        //    //    }, transaction)?.ToList();

        //    //}

        //    return lastData;
        //}
        //public override long InsertChildData(IDbTransaction transaction, MWUser data, MWUser oldData, ClientInfo clientInfo)
        //{
        //    long resultValues = ErrorCodes.Success;

        //    //if (data != null && data.SystemCodeValues?.Count > 0)
        //    //{
        //    //    data.SystemCodeValues.ForEach(x =>
        //    //    {
        //    //        x.SystemCodeId = data.SystemCodeId;

        //    //        x.Value = x.Value.Trim();
        //    //        x.Description = x.Description.Trim();

        //    //    });

        //    //    var insertedCount = _systemCodeValueDA.Insert(data.SystemCodeValues, transaction);
        //    //    resultValues = insertedCount == data.SystemCodeValues.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
        //    //}


        //    return resultValues;
        //}


        //public override long UpdateChildData(IDbTransaction transaction, MWUser data, MWUser oldData, ClientInfo clientInfo)
        //{
        //    long result = ErrorCodes.Success;

        //    if (result > 0)
        //    {
        //        result = UpdateChildData(transaction, data, oldData, clientInfo);
        //    }

        //    return result;
        //}
    }
}
