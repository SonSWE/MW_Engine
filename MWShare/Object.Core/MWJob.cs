using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object
{
    [DbTable(Name = Const.DbTable.MWJob, ViewName = $"VW_{Const.DbTable.MWJob}")]
    public sealed class MWJob : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string JobId { get; set; }
        public string TermType { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string Scope { get; set; }
        public string Level { get; set; }
        public string BudgetType { get; set; }
        public string HourlyRateFrom { get; set; }
        public string HourlyRateTo { get; set; }
        public string CostEstimate { get; set; }
        public string FileAttach { get; set; }

    }
}
