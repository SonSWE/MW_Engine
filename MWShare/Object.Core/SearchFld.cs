using System;

namespace Object.Core
{
    public sealed class SearchFld
    {
        public string SearchCode { get; set; }
        public string FldCode { get; set; }
        public string FldName { get; set; }
        public string FldNameEn { get; set; }
        /// <summary>
        /// Vị trí hiển thị (Thứ tự sắp xếp)
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Allcode: cdType = SYS, cdCode = SEARCH_DISPLAY
        /// </summary>
        public string Display { get; set; }
        /// <summary>
        /// Allcode: cdType = SYS, cdCode = YN
        /// </summary>
        public string IsRecordKey { get; set; }
        public int Width { get; set; }
        public int ExpWidth { get; set; }
        /// <summary>
        /// Có cho phép sort ở Grid không. Y/N
        /// </summary>
        public string AllowSort { get; set; }
        /// <summary>
        /// Căn dữ liệu trên Grid. C/L/R
        /// </summary>
        public string Align { get; set; }
        /// <summary>
        /// Fix cố định cột trên Grid. L/R
        /// </summary>
        public string Fixed { get; set; }
        /// <summary>
        /// Kiểu dữ liệu
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// Có cho phép search theo field này không. Y/N
        /// </summary>
        public string Srch { get; set; }
        /// <summary>
        /// Các phép so sánh khi được search. LIKE,=,>,>=,<,<=,<>
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// Nguồn lấy dữ liệu trên mem cho combobox, textbox autocomplete
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Nguồn lấy dữ liệu trên DB cho combobox, textbox autocomplete
        /// </summary>
        public string SqlCmd { get; set; }
        /// <summary>
        /// Giá trị mặc định
        /// </summary>
        public string DefValue { get; set; }
        /// <summary>
        /// Loại control để nhập dữ liệu tìm kiếm
        /// </summary>
        public string Control { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime LastChangeDate { get; set; }
        /// <summary>
        /// Các giá trị sẽ hiển thị trên thanh lọc nhanh
        /// </summary>
        public string QuickFilterValue { get; set; }
        /// <summary>
        /// Có Hyperlink trên Grid để click không. Y/N
        /// </summary>
        public string HasHyperlink { get; set; }
        /// <summary>
        /// Đường dẫn chuyển đến khi click trên Grid
        /// </summary>
        public string Hyperlink { get; set; }
        /// <summary>
        /// Các tham số truyền đi khi click Hyperlinkl
        /// </summary>
        public string HyperlinkParams { get; set; }
    }
}
