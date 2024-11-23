namespace CommonLib.Constants
{
    public partial class ErrorCodes
    {
        // Ma loi phan he SE (Securities Equity): -22_XX_YYY;
        // XX: 2 so the hien bang
        //		+ 00: SEMAST                            - TABLE     - Tài khoản chứng khoán
        //		+ 01: SEDEPOSITORY                      - TABLE     - Giao dịch Lưu ký chứng khoán
        //		+ 02: SecuritesDepository               - BUSINESS  - Nộp tiền
        //		+ 03: Instrument               - Instrument
        // YYY: 3 so the hien loi

        public static class SE
        {
            /// <summary>
            /// -22_00_YYY
            /// </summary>
            public static class Err_SEMast
            {

            }

            /// <summary>
            /// -22_01_YYY
            /// </summary>
            public static class Err_SEDepository
            {
                public const int SeDepoId = -22_01_001;
                public const int AfAccNo = -22_01_002;
                public const int SeAccNo = -22_01_003;
                public const int TlLogId = -22_01_004;
                public const int TxNum = -22_01_005;
                public const int TxDate = -22_01_006;
                public const int TlTxCd = -22_01_007;
                public const int Symbol = -22_01_008;
                public const int TradePlace = -22_01_009;
                public const int SecType = -22_01_010;
                public const int MemberCode = -22_01_011;
                public const int CustodyCd = -22_01_012;
                public const int FullName = -22_01_013;
                public const int TranferType = -22_01_014;
                public const int Trade = -22_01_015;
                public const int Qtty = -22_01_016;
                public const int QttyWait = -22_01_017;
                public const int QttyRestrict = -22_01_018;
                public const int QttyTax = -22_01_019;
                public const int Price = -22_01_020;
                public const int ShareholderBook = -22_01_021;
                public const int ReleaseCode = -22_01_022;
                public const int IsAuthority = -22_01_023;
                public const int CfAuthId = -22_01_024;
                public const int DesInternal = -22_01_025;
                public const int SendVsd = -22_01_026;
                public const int VsdResSts = -22_01_027;
                public const int VsdResTime = -22_01_028;
                public const int VsdResDes = -22_01_029;
                public const int Status = -22_01_030;
                public const int AfAccNo_NotExist = -22_01_031;
                public const int AfAccNo_InvalidStatus = -22_01_032;
                public const int Symbol_NotExist = -22_01_033;
                public const int AfAccNo_IdExpired = -22_01_034;
                public const int CfAuthId_NotExist = -22_01_035;
            }

            /// <summary>
            /// -22_02_YYY
            /// </summary>
            public static class Err_SecuritesDepository
            {
                public const int AutoId = -22_02_001;
                public const int AfAccNo = -22_02_002;
                public const int BatchId = -22_02_003;
                public const int TlTxCd = -22_02_004;
                public const int TxNum = -22_02_005;
                public const int TxDate = -22_02_006;
                public const int ActiveDate = -22_02_007;
                public const int Symbol = -22_02_008;
                public const int TradePlace = -22_02_009;
                public const int Trade = -22_02_010;
                public const int Qtty = -22_02_011;
                public const int Price = -22_02_012;
                public const int QttyTax = -22_02_013;
                public const int IsAuthority = -22_02_014;
                public const int CfAuthId = -22_02_015;
                public const int Description = -22_02_016;
                public const int DescriptionOther = -22_02_017;
                public const int DesInternal = -22_02_018;
                public const int TxStatus = -22_02_019;
                public const int SecType = -22_02_020;
                public const int SendVsd = -22_02_021;
                public const int VsdPlaceRecv = -22_02_022;
                public const int ActiveDate_IsWeekend = -22_02_023;
                public const int CfAuthId_NotExist = -22_02_024;
                public const int Err_BatchId_Existed = -22_02_025;
            }
        }

        public static class SE_Instrument
        {
            public const int Err_AutoId = -23_03_001;
            public const int Err_RefAutoId = -23_03_002;
            public const int Err_Description = -22_03_003;
            public const int Err_RecordStatus = -22_03_004;
            public const int Err_Action = -22_03_005;
            public const int Err_CreateBy = -22_03_006;
            public const int Err_CreateDate = -22_03_007;
            public const int Err_LastChangeBy = -22_03_008;
            public const int Err_LastChangeDate = -22_03_009;
            public const int Err_ApproveBy = -22_03_010;
            public const int Err_ApproveDate = -22_03_011;
            public const int Err_RejectNum = -22_03_012;
            public const int Err_RejectDes = -22_03_013;
            public const int Err_CancelReason = -22_03_014;
            public const int Err_Deleted = -22_03_015;
            //
            public const int Err_Market = -22_03_017;
            public const int Err_Board = -22_03_018;
            public const int Err_InstrumentId = -22_03_019;
            public const int Err_Name = -22_03_020;
            public const int Err_NameOther = -22_03_021;
            public const int Err_ListingStatus = -22_03_022;
            public const int Err_RegistryDate = -22_03_023;
            public const int Err_DelistingDate = -22_03_024;
            public const int Err_ListingDate = -22_03_025;
            public const int Err_Remark = -22_03_026;
            public const int Err_PendingExisted = -22_03_027;
            public const int Err_InstrumentId_Existed = -22_03_028;
            public const int Err_ApproveSelfData = -22_03_029;
            public const int Err_CancelOtherData = -22_03_030;
            public const int Err_ExternalIdd = -22_03_031;
            public const int Err_ISIN = -22_03_032;
            public const int Err_ShortName = -22_03_033;
            public const int Err_ShortNameOther = -22_03_034;
            public const int Err_InstrumentType = -22_03_035;
            public const int Err_SettleCurrency = -22_03_036;
            public const int Err_Status = -22_03_037;
            public const int Err_Halt = -22_03_038;
            public const int Err_UnderlyingAssetId = -22_03_039;
            public const int Err_MaturityMonth = -22_03_040;
            public const int Err_LastTradingDate = -22_03_040;
            public const int Err_ExpirationDate = -22_03_041;
            public const int Err_LastSettlementDate = -22_03_042;
            public const int Err_LiquidationTrading = -22_03_043;
            public const int Err_OptionType = -22_03_044;
            public const int Err_SpreadCompositionCode = -22_03_045;
            public const int Err_IsinLegA = -22_03_046;
            public const int Err_IsinLegB = -22_03_047;
            public const int Err_HairCut = -22_03_048;
        }
        public static class SE_Underlying
        {
            public const int Err_AutoId = -23_03_001;
            public const int Err_RefAutoId = -23_03_002;
            public const int Err_Description = -23_03_003;
            public const int Err_RecordStatus = -23_03_004;
            public const int Err_Action = -23_03_005;
            public const int Err_CreateBy = -23_03_006;
            public const int Err_CreateDate = -23_03_007;
            public const int Err_LastChangeBy = -23_03_008;
            public const int Err_LastChangeDate = -23_03_009;
            public const int Err_ApproveBy = -23_03_010;
            public const int Err_ApproveDate = -23_03_011;
            public const int Err_RejectNum = -23_03_012;
            public const int Err_RejectDes = -23_03_013;
            public const int Err_CancelReason = -23_03_014;
            public const int Err_Deleted = -23_03_015;
            //
            public const int Err_Underlying = -23_03_016;
            public const int Err_ProductName = -23_03_017;
            public const int Err_Status = -23_03_018;
            public const int Err_PgCode = -23_03_019;
            public const int Err_Market = -23_03_020;
            public const int Err_NameOther = -23_03_021;
            public const int Err_MM = -23_03_022;
            public const int Err_RIM = -23_03_023;
            public const int Err_RSM = -23_03_024;
            public const int Err_RPP = -23_03_025;
            public const int Err_RSecDeposit = -23_03_026;
            public const int Err_RNomal = -23_03_027;
            public const int Err_RWarning = -23_03_028;
            public const int Err_RAlert = -23_03_029;
            public const int Err_UnderlyingExistedInInstrument = -23_03_030;
            public const int Err_UnderlyingExistedInAccountType = -23_03_031;
            public const int Err_DesignedDateIsNotWorkingDay = -23_03_032;
            public const int Err_MaturityDateIsNotWorkingDay = -23_03_033;

        }

        public static class SE_AccountInstrumentMovement
        {
            public const int Err_MovementId = -22_04_001;
            public const int Err_TransactionCode = -22_04_002;
            public const int Err_AccountId = -22_04_003;
            public const int Err_AccountNotExisted = -22_04_004;
            public const int Err_AccountDerivativeInvalid = -22_04_005;
            public const int Err_AccountStatusInvalid = -22_04_006;
            public const int Err_MakerCantAccessAccountBranch = -22_04_007;
            public const int Err_AccountTypeNotAccess = -22_04_008;
            public const int Err_DerivativeNotAllowProcessingInBatch = -22_04_009;
            public const int Err_AccountIdNoInstrumentDeposit = -22_04_010;

            public const int Err_InstrumentId = -22_04_011;
            public const int Err_Quantity = -22_04_012;
            public const int Err_QuantityGreaterThanRequiredQuantity = -22_04_013;
            public const int Err_QuantityGreaterThanDepositable = -22_04_014;
            public const int Err_QuantityGreaterThanDrawableQuantity = -22_04_015;
            public const int Err_TransactionDate = -22_04_016;
            public const int Err_ValueDate = -22_04_017;
            public const int Err_ValueDateLessThanBusDate = -22_04_018;
            public const int Err_ValueDateHoliday = -22_04_019;
            public const int Err_ValueDateLessThanTransactionDate = -22_04_020;


        }
    }
}
