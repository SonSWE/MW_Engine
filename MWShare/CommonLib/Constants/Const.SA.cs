namespace CommonLib.Constants
{
    public static partial class Const
    {
        public static class SA
        {


        }

        public static class USER_TYPE
        {
            public const string Admin = "ADMIN";
            public const string User = "USER";
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

        public static class Freelancer_Status
        {
            public const string Active = "A";
            public const string Close = "C";
        }
        public static class Client_Status
        {
            public const string Active = "A";
            public const string Close = "C";
        }

        public static class Contract_Status
        {
            public const string Offer = "O";
            public const string Rejected = "R";
            public const string Active = "A";
            public const string Closed = "C";
            public const string PendingPayment = "PP";
            public const string PendingApprovalSubmit = "PA";
            public const string PendingApprovalEnd = "PE";
            public const string Done = "D";
            public const string Fail = "F";
        }
        public static class Contract_EndReason
        {
            public const string Complaint = "C";
            public const string Other = "O";
        }

        public static class Contract_Complaint_Status
        {
            public const string Accept = "A";
            public const string Reject = "R";
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
