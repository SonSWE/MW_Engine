namespace CommonLib.Constants
{
    public partial class Const
    {
        public static class SE
        {
            public static class SEDepository_Status
            {
                public const string Pending = "N";
                public const string Rejected = "R";
                public const string Deposit = "D";
                public const string SentVSD = "S";
                public const string Completed = "C";
            }
        }

        public static class Instrument_Market
        {
            public const string TraiPhieuRiengLe = "007";
        }

        public static class Instrument_Board
        {
            public const string Chinh = "G1";
        }

        public static class Instrument_ListingStatus
        {
            public const string DangNiemYet = "LTD";
        }

        public static class Instrument_Status
        {
            public const string Listed = "Listed";
        }

        public static class SE_AccountStatus
        {
            public const int CloseviaVSD = 1;
            public const string Closed = "C";
            public const string Active = "A";
            public const int TransferviaVSD = 4;
            public const string Suspend = "S";
        }

        public static class SE_AccountType
        {
            public static readonly string[] ListTypeMapBankAndCustotdian = { "MAPBANK'", "MAP BANK", "MAP_BANK", "MAPBANK" };
        }

        public static class SE_TransactionCode
        {
            public const string SSI = "Physical Delivery Deposit (SSI)";
            public const string VSD = "Physical Delivery Deposit (VSD)";

        }

        public static class SE_SettleStatus
        {
            public const string Settlement = "S";
            public const string Unsettle = "U";
        }
        public static class SE_TransactionType
        {
            public const string InstrumentDeposit = "ID";
        }

    }
}
