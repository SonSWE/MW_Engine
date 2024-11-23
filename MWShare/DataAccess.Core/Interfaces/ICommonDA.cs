using System;
using System.Data;

namespace DataAccess.Core.Interfaces
{
    public interface ICommonDA
    {
        string GetBusDate();
        bool IsWorkingDate(DateTime date);
        string GetTxNum(long branchId);
        string[] GetTxNums(long branchId, int numberToGet);
        //
        DataSet ExecteSqlCmdToDataSet(string sqlCmd);
    }
}
