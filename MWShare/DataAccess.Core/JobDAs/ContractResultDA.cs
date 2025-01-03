using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;


namespace DataAccess.Core.JobDAs
{
    public sealed class ContractResultDA : BaseDA<MWContractResult>, IContractResultDA
    {
        public ContractResultDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
