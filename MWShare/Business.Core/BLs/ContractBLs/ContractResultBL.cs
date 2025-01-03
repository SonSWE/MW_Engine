using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using Object.Core;
using System.Data;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.BLs.ContractBLs
{
    public class ContractResultBL : MasterDataBaseBL<MWContractResult>, IContractResultBL
    {
        public override string ProfileKeyField => Const.ProfileKeyField.ContractResult;
        public override string DbTable => Const.DbTable.MWContractResult;

        public ContractResultBL(IDbManagement dbManagement, ILoggingManagement loggingManagement) : base(dbManagement, loggingManagement)
        {

        }

        public override void BeforeCreate(IDbTransaction transaction, MWContractResult data)
        {
            //tự sinh id
            data.ContractResultId = "CR" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
