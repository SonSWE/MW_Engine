using CommonLib.Constants;
using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWSearch)]
    public sealed class MWSearch
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }
        public int Deleted { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string FunctionId { get; set; }
        public string NameSpace { get; set; }
        public string ClassName { get; set; }
    }

    public sealed class SearchProperty
    {
        public string Name { get; set; }
        public string DataType { get; set; }
    }

    public sealed class SearchInquiry
    {
        public List<SearchInquiryCond> Conds { get; set; }
        public List<SearchInquirySortCond> SortConds { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }
        public string FileType { get; set; }
        public string Code { get; set; }
        public int IsExport { get; set; }
        public string Language { get; set; }
        public List<SearchInquiryExportColumn> ExportColumns { get; set; }
    }

    public sealed class SearchInquiryCond
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
        public string DataType { get; set; }
        public string Control { get; set; }
    }

    public sealed class SearchInquirySortCond
    {
        public string Key { get; set; }
        public string Direction { get; set; }
        public string DataType { get; set; }
    }

    public class SearchInquiryExportColumn
    {
        public string Key { get; set; }
        public int Position { get; set; }
        public string Display { get; set; }
    }

    public sealed class SearchPageConfig
    {
        public int RecordCount { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }
        public int RealRecordCount { get; set; }
        public int MaxRecordShow { get; set; }
        public int MaxAutoId { get; set; }
    }

    public sealed class SearchGetByCodeResponse
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string FunctionId { get; set; }
    }

    public sealed class SearchFilterOption
    {
        public string CdVal { get; set; }
        public string Content { get; set; }
        public string ContentEn { get; set; }
        public string ShowOnQuickFilter { get; set; }
    }

    //
    public sealed class SearchInquiryResponse
    {
        public int RecordCount { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }
        public int RealRecordCount { get; set; }
        public int MaxRecordShow { get; set; }
        public long MaxAutoId { get; set; }
        public List<ExpandoObject> Datas { get; set; }
    }

    public sealed class SearchJobRequest
    {
        public string FreelancerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public List<string> LevelIds { get; set; }
        public string Specialties { get; set; }
    }
}
