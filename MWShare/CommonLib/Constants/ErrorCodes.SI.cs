namespace CommonLib.Constants
{
    public static partial class ErrorCodes
    {
        // Ma loi phan he SI: -13_XX_YYY;
        // XX: 2 so the hien bang
        //		+ 00: IssuerMember                 - Thông tin thành viên TCPH
        // YYY: 3 so the hien loi

        public static class SI
        {
            public static class IssuerMember
            {
                public const int Err_IssuerMemberId = -13_00_001;
                public const int Err_IssuerId = -13_00_002;
                public const int Err_CustId = -13_00_003;
                public const int Err_RoleCd = -13_00_004;
                public const int Err_Description = -13_00_005;
                public const int Err_Status = -13_00_006;
                public const int Err_Symbol = -13_00_007;
                public const int Err_Relationship = -13_00_008;
                public const int Err_NumberOfShare = -13_00_009;
                public const int Err_PercentageOfShare = -13_00_010;
                public const int Err_DateInvolve = -13_00_011;
                public const int Err_DateRelease = -13_00_012;
                public const int Err_Reason = -13_00_013;
                public const int Err_DateReleaseAndDateInvolve = -13_00_014;

                public const int Err_DuplicateData = -13_00_090;
            }
        }
    }
}
