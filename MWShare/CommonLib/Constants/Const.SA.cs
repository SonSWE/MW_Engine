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
    }
}
