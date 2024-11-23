namespace Object.Core.Share
{
    public class BaseInfo
    {
        public int Code { get; set; }
        /// <summary>
        /// Mã trả về
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Kết quả trả về
        /// </summary>
        public string JsonData { get; set; }
        /// <summary>
        /// Thuộc tính bị lỗi
        /// </summary>
        public string PropertyName { get; set; }
    }
}
