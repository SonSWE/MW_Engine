namespace CommonLib.Constants
{
    public static partial class ErrorCodes
    {

        public const int Success = 1;
        //
        public const int Err_Unknown = -1;
        public const int Err_Exception = -2;
        public const int Err_NotFound = -3;
        public const int Err_Existed = -4;
        public const int Err_InvalidData = -5;
        public const int Err_InvalidArgument = -6;
        public const int Err_DataNull = -7;
        public const int Err_Undefined = -8;
        public const int Err_ChildData = -9;
        public const int Err_ApproveUserSameCreateUser = -10;
        public const int Err_CancelUserSameCreateUser = -11;
        public const int Err_CancelReasonNull = -12;
        public const int Err_DerivativeNotAllowProcessingInBatch = -13;

        public static class CUS_Wallet
        {
            public const int Err_StatusInactive = -100100;
        }

        public static class SA_SystemCode
        {
            public const int Err_SystemCodeId_Invalid = -10_75_001;
            public const int Err_SystemCodeDescription_Invalid = -10_75_002;
            public const int Err_SystemCodeValues_ValuesInvalid = -10_75_003;
            public const int Err_SystemCodeValues_ContentInvalid = -10_75_004;
            public const int Err_SystemCodeValues_ContentOtherInvalid = -10_75_005;
            public const int Err_SystemCodePurpose_PurposeInvalid = -10_75_006;

        }

    }
}
