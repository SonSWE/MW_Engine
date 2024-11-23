
using System;

namespace Object.Core.Attribute
{

    /// <summary>
    /// Tổng hợp các loại attribute dùng để kiểm tra dữ liệu
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckValAttribute : System.Attribute
    {
        /// <summary>
        /// Specifies whether a field is writable in the database.
        /// </summary>
        /// <param name="k">The key value.</param>
        /// <param name="m">The maximum value.</param>
        /// <param name="r">Whether the field is required.</param>
        /// <param name="isD">Whether the field is a date.</param>
        /// <param name="_cdType">The code type.</param>
        /// <param name="_cdCode">The code.</param>
        /// <param name="_sql">The SQL statement.</param>
        public CheckValAttribute(int k = 0, int m = 0, bool r = false, bool isD = false, string _cdType = "", string _cdCode = "", string _sql = "")
        {
            Key = k;
            max = m;
            IsDate = isD;
            required = r;
            cdType = _cdType;
            cdCode = _cdCode;
            sql = _sql;
        }

        /// <summary>
        /// Whether a field is writable in the database.
        /// </summary>
        public int Key { get; set; }
        public bool IsDate { get; set; } = false;
        public bool required { get; set; } = false;
        public string cdType { get; set; } = string.Empty;
        public string cdCode { get; set; } = string.Empty;
        public string sql { get; set; } = string.Empty;
        public int max { get; set; }
        public bool ckAudit { get; set; }
    }
}


