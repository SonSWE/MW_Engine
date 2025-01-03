using CommonLib.Constants;
using DataAccess.Core.Helpers;
using DataAccess.Helpers;
using Object.Core;
using System.Data;
using Business.Core.BLs.BaseBLs;

namespace Business.Core.BLs.ContractBLs
{
    public class ContractBL : MasterDataBaseBL<MWContract>, IContractBL
    {
        public override string ProfileKeyField => Const.ProfileKeyField.Contract;
        public override string DbTable => Const.DbTable.MWContract;

        public ContractBL(IDbManagement dbManagement, ILoggingManagement loggingManagement) : base(dbManagement, loggingManagement)
        {

        }

        public override void BeforeCreate(IDbTransaction transaction, MWContract data)
        {
            //tự sinh id
            data.ContractId = "CT" + _baseDA.GetNextSequenceValue(transaction).ToString();
        }
    }
}
