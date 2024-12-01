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
using Business.Core.BLs.BaseBLs;

namespace Business.Core.BLs.SystemCodeBLs
{
    public class SystemCodeBL : MasterDataBaseBL<MWSystemCode>, ISystemCodeBL
    {
        private readonly ISystemCodeValueDA _systemCodeValueDA;
        public override string ProfileKeyField => Const.ProfileKeyField.SystemCode;
        public override string DbTable => Const.DbTable.MWSystemCode;

        public SystemCodeBL(IDbManagement dbManagement, ILoggingManagement loggingManagement, ISystemCodeValueDA systemCodeValueDA) : base(dbManagement, loggingManagement)
        {
            _systemCodeValueDA = systemCodeValueDA;

        }

        public override MWSystemCode GetDetailById(IDbTransaction transaction, string id)
        {
            var requestTime = DateTime.Now;
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] Start. id=[{id}]");

            MWSystemCode data = base.GetDetailById(transaction, id);
            if (data != null && !string.IsNullOrEmpty(data.SystemCodeId))
            {
                //Lấy thông tin SystemCodeValue
                data.SystemCodeValues = _systemCodeValueDA.GetView(new
                {
                    data.SystemCodeId,
                }, transaction).ToList() ?? new();

            }
            Logger.log.Info($"[{RequestId}] [{ConstLog.GetMethodFullName(MethodBase.GetCurrentMethod())}] End. Tong thoi gian {ConstLog.GetProcessingMilliseconds(requestTime)} (ms)");


            return data;
        }

        public override long InsertChildData(IDbTransaction transaction, MWSystemCode data, MWSystemCode oldData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (data != null && data.SystemCodeValues?.Count > 0)
            {
                data.SystemCodeValues.ForEach(x =>
                {
                    x.SystemCodeId = data.SystemCodeId;
                });

                var insertedCount = _systemCodeValueDA.Insert(data.SystemCodeValues, transaction);
                resultValues = insertedCount == data.SystemCodeValues.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }


            return resultValues;
        }

        public override long DeleteChildData(IDbTransaction transaction, string id, MWSystemCode deleteData, ClientInfo clientInfo)
        {
            long resultValues = ErrorCodes.Success;

            if (deleteData != null && deleteData.SystemCodeValues?.Count > 0)
            {
                deleteData.SystemCodeValues.ForEach(x =>
                {
                    x.SystemCodeId = deleteData.SystemCodeId;
                });

                var insertedCount = _systemCodeValueDA.Delete(deleteData.SystemCodeValues, transaction);
                resultValues = insertedCount == deleteData.SystemCodeValues.Count ? ErrorCodes.Success : ErrorCodes.Err_InvalidData;
            }

            return resultValues;
        }
    }
}
