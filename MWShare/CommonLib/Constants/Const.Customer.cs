namespace CommonLib.Constants
{
    public static partial class Const
    {
        public static class Customer_RegistrationType
        {
            /// <summary>
            /// Local Retail
            /// </summary>
            public const string CaNhanTrongNuoc = "C";

            /// <summary>
            /// Asset Management
            /// </summary>
            public const string CongTyQuanLyQuy = "D";

            /// <summary>
            /// Foreign Institution
            /// </summary>
            public const string ToChucNuocNgoai = "E";

            /// <summary>
            /// Local Institutional
            /// </summary>
            public const string ToChucTrongNuoc = "O";

            /// <summary>
            /// Sharehoder
            /// </summary>
            public const string QuanLyCoDongOTC = "T";

            /// <summary>
            /// Foreign Retail
            /// </summary>
            public const string CaNhanNuocNgoai = "F";

            /// <summary>
            /// Local Porfolio 
            /// </summary>
            public const string TuDoanhTrongNuoc = "P";

            /// <summary>
            /// Foreign Porfolio 
            /// </summary>
            public const string TuDoanhNuocNgoai = "B";
        }

        public static class Customer_Resident
        {
            public const string Resident = "001";
            public const string Homeless = "002";
        }

        public static class Customer_Status
        {
            public const string Active = "A";
            public const string Close = "C";
            public const string New = "N";
        }

        public static class Contact_DataType
        {
            public const string KhachHang = "CUS";
            public const string TaiKHoan = "ACC";
        }

        public static class Authority_Status
        {
            public const string Active = "A";
            public const string Expired = "E";
            public const string Pending = "N";
        }

        public static class Authority_Type
        {
            public const string Transaction = "1";
            public const string Document = "2";
            public const string Investment = "3";

            public static bool IsInvestment(string type)
            {
                return type switch
                {
                    Investment => true,
                    _ => false,
                };
            }
        }

        public static class Authority_Scope
        {
            public const string Full = "1";
            public const string AccountTransaction = "2";
            public const string MonetaryTransaction = "3";
            public const string SercuritiesCustodyAndExecutionOfRights = "4";
            public const string Other = "5";
        }
    }
}
