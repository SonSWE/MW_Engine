using Object.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Business.Core.Services.SystemServices
{
    public interface ICommonService
    {
        string GetBusDate();
        bool IsWorkingDate(DateTime date);
        string GetTxNum(long branchId);
        string[] GetTxNums(long branchId, int numberToGet);

        DataSet ExecteSqlCmdToDataSet(string sqlCmd);

        /// <summary>
        /// Lấy danh sách SystemCode
        /// </summary>
        /// <returns></returns>
        Task<List<MWSystemCode>> GetSystemCodes();
    }
}
