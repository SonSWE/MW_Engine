namespace MWShare.ExportHelpers
{
    public class ExportOptions
    {
        public ExportType ExportType { get; set; } = ExportType.None;
        /// <summary>
        /// Đường dẫn file mẫu kết xuất
        /// </summary>
        public string TemplatePath { get; set; } = string.Empty;
        public Stream TemplateStream { get; set; }
        /// <summary>
        /// Đường dẫn file kết xuất
        /// </summary>
        public string ExportPath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Dùng cho kết xuất không theo mẫu. Đánh dấu có kết xuất theo dữ liệu DataSet không. Mặc định False.
        /// Nếu True thì kết xuất đầy đủ cột theo  DataSet, [ExportColDefs] chỉ dùng để lấy tiêu đề cột, định dạng.
        /// Nếu False thì kết xuất theo các cột đã được định nghĩa, cấu hình trong [ExportColDefs]
        /// </summary>
        public bool KeepDataSourceColumn { get; set; } = false;
        /// <summary>
        /// Dùng cho kết xuất không theo mẫu. Định nghĩa danh sách cột, cấu hình sẽ hiển thị trên file kết xuất.
        /// </summary>
        public Dictionary<string, ExportColumnDef> ExportColDefs { get; set; } = new();
        public Dictionary<string, object> ExportParams { get; set; } = new();
    }

    public class ExportColumnDef
    {
        public string ColumnName { get; set; } = string.Empty;
        public string ColumnDesc { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public int Width { get; set; } = 18;
        public string Align { get; set; } = string.Empty;
        public string Display { get; set; } = "Y";
        public int Position { get; set; }
    }
}
