namespace CommonLib.Constants
{
    public static partial class Const
    {
        public static class SA
        {


        }

        public static class USER_TYPE
        {
            public const string Admin = "A";
            public const string User = "U";
        }

        public static class LOGIN_TYPE
        {
            public const string Freelancer = "F";
            public const string Client = "C";
        }

        public static class User_Status
        {
            public const string Active = "A";
            public const string PendingVerify = "P";
            public const string InActive = "I";
        }
        public static class Job_Status
        {
            public const string Open = "A";
            public const string Close = "O";
            public const string Hired = "R";
        }
        public static class Proposal_Status
        {
            public const string Sent = "A";
            public const string Read = "O";
            public const string Rejected = "R";
            public const string Offer = "D";
        }

        public static class Contract_Status
        {
            public const string Pending = "P";
            public const string Rejected = "R";
            public const string Active = "A";
            public const string Closed = "C";
            public const string End = "E";
            public const string PendingApprovalSubmit = "PS";
            public const string Reopen = "RO";
            public const string Done = "D";
            public const string Fail = "F";
        }
        public static class Wallet_Status
        {
            public const string Active = "A";
            public const string Inactive = "I";
        }
        public static class Transaction_Status
        {
            public const string Pending = "P";
            public const string Succeed = "S";
            public const string Cancel = "X";
        }

        public static class Transaction_Type
        {
            public const string Deposit = "D"; //Nạp tiền
            public const string Withdraw = "W"; //rút tiền
            public const string Payment = "P"; //thanh toán
            public const string Transfer = "T"; //Chuyển tiền
            public const string Receive = "R"; //nhận tiền
        }
    }
}
