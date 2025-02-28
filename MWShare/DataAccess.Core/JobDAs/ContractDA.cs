using CommonLib.Constants;
using Dapper;
using DataAccess.Core.Abtractions;
using DataAccess.Core.FreelancerDAs;
using DataAccess.Core.Helpers;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Core.JobDAs
{
    public sealed class ContractDA : BaseDA<MWContract>, IContractDA
    {
        private readonly IDbManagement _dbManagement;
        public ContractDA(IDbManagement dbManagement) : base(dbManagement)
        {
            _dbManagement = dbManagement;
        }

        public async Task<List<string>> GetContractIdsEndDate()
        {
            using var connection = _dbManagement.GetConnection();

            string query = @$"SELECT contractId FROM {Const.DbTable.MWContract} 
                            WHERE {nameof(MWContract.EndDate)} = :{nameof(MWContract.EndDate)} 
                            AND {nameof(MWContract.Status)} in ('{Const.Contract_Status.Active}', '{Const.Contract_Status.PendingApprovalSubmit}') ";

            return (await connection.QueryAsync<string>(query, new Dictionary<string, object> { { nameof(MWContract.EndDate), DateTime.Now.Date } }))?.ToList();
        }
    }
}
