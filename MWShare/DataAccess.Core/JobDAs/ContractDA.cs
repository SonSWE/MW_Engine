using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.Helpers;
using Object.Core;
using System.Data;


namespace DataAccess.Core.JobDAs
{
    public sealed class ContractDA : BaseDA<MWContract>, IContractDA
    {
        public ContractDA(IDbManagement dbManagement) : base(dbManagement)
        {
        }
    }
}
