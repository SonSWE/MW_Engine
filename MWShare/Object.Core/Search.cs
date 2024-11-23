using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Object.Core
{
    public sealed class Search
    {
        public string Code { get; set; }
        public string TlTxCd { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string KeyWord { get; set; }
        public string StoreName { get; set; }
        public string ExportType { get; set; }
        public string Description { get; set; }
        public int Deleted { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string PassCondAsArray { get; set; }
        public string FunctionId { get; set; }
        public string UseSqlText { get; set; }
        public string NotificationId { get; set; }
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
        public string TitleEn { get; set; }
        public string KeyWord { get; set; }
        public string ExportType { get; set; }
        public List<SearchFilter> FilterList { get; set; } = new();
        public List<SearchColumn> ColumnList { get; set; } = new();
        public List<string> RecordKeys { get; set; } = new();
        public string FunctionId { get; set; }
    }

    public sealed class SearchFilter
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string DataType { get; set; }
        public string Control { get; set; }
        public List<string> DefValues { get; set; } = new();
        public List<string> Operators { get; set; } = new();
        public List<SearchFilterOption> Options { get; set; } = new();
    }

    public sealed class SearchFilterOption
    {
        public string CdVal { get; set; }
        public string Content { get; set; }
        public string ContentEn { get; set; }
        public string ShowOnQuickFilter { get; set; }
    }

    public sealed class SearchColumn
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string DataType { get; set; }
        public string Align { get; set; }
        public string Fixed { get; set; }
        public int Position { get; set; }
        public int Width { get; set; }
        public string Sortable { get; set; }
        public string HasHyperlink { get; set; }
        public string Hyperlink { get; set; }
        public List<SearchHyperlinkParam> HyperlinkParams { get; set; } = new();
    }

    public sealed class SearchHyperlinkParam
    {
        public string Key { get; set; }
        public string Value { get; set; }
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

    public sealed class SearchInquiryReport
    {
        public SearchInquiry SearchInquiryConds { get; set; }
        public TempContentDefinition TempContentDefinition { get; set; }
       
    }

    public class TempContentDefinition
    {
        public string TempContent { get; set; }
        public string[] Parameters { get; set; }
    }
}
