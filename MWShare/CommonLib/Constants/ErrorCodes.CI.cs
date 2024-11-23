namespace CommonLib.Constants
{
    public partial class ErrorCodes
    {
        // Ma loi phan he CI (Cash Information): -11_XX_YYY;
        // XX: 2 so the hien bang
        //		+ 00: CIMAST                        - TABLE     - Tài khoản tiền
        //		+ 01: CIDEPOSITORY                  - TABLE     - Giao dịch nộp tiền
        //		+ 02: CashDepository                - BUSINESS  - Nộp tiền
        //		+ 03: DepositIM                     - BUSINESS  - Nộp tiền Phái sinh
        //		+ 04: WithdrawIM                     - BUSINESS  - Rút tiền Phái sinh
        //		+ 05: PaymentST                     - BUSINESS  - Công ty nộp ST lỗ NET cho VSD
        //		+ 11: CashWithdraw                     - BUSINESS  - Rut tien

        //		+ 80: TACompanyMovement (TA: Transtion Assest): Lưu thông tin các giao dịch mức công ty 
        // YYY: 3 so the hien loi


        public static class CI_CIDepository
        {
            public const int Err_AutoId = -11_01_001;
            public const int Err_AfAccNo = -11_01_002;
            public const int Err_AfMastId = -11_01_003;
            public const int Err_TLLogId = -11_01_004;
            public const int Err_TxNum = -11_01_005;
            public const int Err_TxDate = -11_01_006;
            public const int Err_Amount = -11_01_007;
            public const int Err_FeeRate = -11_01_008;
            public const int Err_FeeVal = -11_01_009;
            public const int Err_TaxRate = -11_01_010;
            public const int Err_TaxVal = -11_01_011;
            public const int Err_DType = -11_01_012;
            public const int Err_IsAuthority = -11_01_013;
            public const int Err_CfAuthId = -11_01_014;
            public const int Err_StsBank = -11_01_015;
            public const int Err_BankReponse = -11_01_016;
            public const int Err_BankTxNum = -11_01_017;
            public const int Err_BankDesc = -11_01_018;
            public const int Err_TxStatus = -11_01_019;
            public const int Err_RejectDes = -11_01_020;
            public const int Err_AfAccNo_NotExist = -11_01_021;
            public const int Err_AfAccNo_InvalidStatus = -11_01_022;
            public const int Err_BankSrcId = -11_01_023;
            public const int Err_BankSrcId_NotExist = -11_01_024;
            public const int Err_AfAccNo_IdExpired = -11_01_025;
            public const int Err_IsCash = -11_01_026;
            public const int Err_CfAuthId_NotExist = -11_01_027;
        }
        public static class CI_CashDepository
        {
            public const int Err_AutoId = -11_02_001;
            public const int Err_AfAccNo = -11_02_002;
            public const int Err_AfMastId = -11_02_003;
            public const int Err_TxNum = -11_02_004;
            public const int Err_TxDate = -11_02_005;
            public const int Err_ActiveDate = -11_02_006;
            public const int Err_Amount = -11_02_007;
            public const int Err_DType = -11_02_008;
            public const int Err_BankSrcId = -11_02_009;
            public const int Err_BankTxNum = -11_02_010;
            public const int Err_IsAuthority = -11_02_011;
            public const int Err_CfAuthId = -11_02_012;
            public const int Err_Description = -11_02_013;
            public const int Err_DescriptionOther = -11_02_014;
            public const int Err_TxStatus = -11_02_015;
            public const int Err_RejectDes = -11_02_016;
            public const int Err_BatchId = -11_02_017;
            public const int Err_SendBank = -11_02_018;
            public const int Err_InternalDesc = -11_02_019;
            public const int Err_TranType = -11_02_020;
            public const int Err_IsCash = -11_02_021;
            public const int Err_ActiveDate_IsWeekend = -11_02_022;
            public const int Err_CfAuthId_NotExist = -11_02_023;
            public const int Err_BatchId_Existed = -11_02_024;
        }

        public static class CI_DepositIM
        {
            public const int Err_AutoId = -11_03_001;
            public const int Err_MovementId = -11_03_002;
            public const int Err_ValueDate = -11_03_003;
            public const int Err_AccountId = -11_03_004;
            public const int Err_CustId = -11_03_005;
            public const int Err_CurrencyCd = -11_03_006;
            public const int Err_TranType = -11_03_007;
            public const int Err_DwChannel = -11_03_008;
            public const int Err_Amount = -11_03_009;
            public const int Err_BankAccountId = -11_03_010;
            public const int Err_Description = -11_03_011;
            public const int Err_AccountNotExisted = -11_03_012;
            public const int Err_AccountIsNoCashDeposit = -11_03_013;
            public const int Err_AmountLimit = -11_03_014;
            public const int Err_MakerCantAccessAccountBranch = -11_03_015;
            public const int Err_CoT = -11_03_016;
            //
            public const int Err_RecordStatus = -11_03_017;
            public const int Err_ApproveSelfData = -11_03_018;
            public const int Err_CancelOtherData = -11_03_019;
            public const int Err_ApprovalLimit = -11_03_020;
            public const int Err_FoStatus = -11_03_021;
            public const int Err_CancelOldDataFailed = -11_03_022;
            public const int Err_ApproveMultiTemplate = -11_03_023;

            public const int Err_CheckingBalance = -11_03_024;
            public const int Err_MakerLimit = -11_03_025;
            public const int Err_TransactionType = -11_03_026;
            public const int Err_AmountInteger = -11_03_027;
            public const int Err_AccountStatusInvalid = -11_03_028;
            public const int Err_AccountDerivativeInvalid = -11_03_029;
            public const int Err_ApprovalCheckingBalance = -11_03_030;
            public const int Err_AccountCashInvalid = -11_03_031;
            public const int Err_RequestId = -11_03_032;
            public const int Err_AutoApproval = -11_03_033;
        }

        public static class CI_WithdrawIM
        {
            public const int Err_AutoId = -11_04_001;
            public const int Err_MovementId = -11_04_002;
            public const int Err_ValueDate = -11_04_003;
            public const int Err_AccountId = -11_04_004;
            public const int Err_CustId = -11_04_005;
            public const int Err_CurrencyCd = -11_04_006;
            public const int Err_TranType = -11_04_007;
            public const int Err_DwChannel = -11_04_008;
            public const int Err_Amount = -11_04_009;
            public const int Err_BankAccountId = -11_04_010;
            public const int Err_Description = -11_04_011;
            public const int Err_AccountNotExisted = -11_04_012;
            public const int Err_AccountCashWithdrawBlocked = -11_04_013;
            public const int Err_AmountLimit = -11_04_014;
            public const int Err_MakerCantAccessAccountBranch = -11_04_015;
            public const int Err_CoT = -11_04_016;
            //
            public const int Err_RecordStatus = -11_04_017;
            public const int Err_ApproveSelfData = -11_04_018;
            public const int Err_CancelOtherData = -11_04_019;
            public const int Err_ApprovalLimit = -11_04_020;
            public const int Err_FoStatus = -11_04_021;
            public const int Err_CancelOldDataFailed = -11_04_022;
            public const int Err_ApproveMultiTemplate = -11_04_023;
            public const int Err_MakerLimit = -11_04_024;
            public const int Err_TransactionType = -11_04_025;
            public const int Err_AmountInteger = -11_04_026;
            public const int Err_AccountStatusInvalid = -11_04_027;
            public const int Err_AccountDerivativeInvalid = -11_04_028;
            public const int Err_AccountCashInvalid = -11_04_029;
            public const int Err_RequestId = -11_04_030;
            public const int Err_AutoApproval = -11_04_031;
        }

        public static class CI_PaymentST
        {
            public const int Err_AutoId = -11_05_001;
            public const int Err_TxNum = -11_05_002;
            public const int Err_TxDate = -11_05_003;
            public const int Err_CurrencyCd = -11_05_006;
            public const int Err_TransType = -11_05_007;
            public const int Err_DwChannel = -11_05_008;
            public const int Err_Amount = -11_05_009;
            public const int Err_FirmsBankAcc = -11_05_010;
            public const int Err_Description = -11_05_011;
            //
            public const int Err_RecordStatus = -11_05_012;
            public const int Err_ApproveSelfData = -11_05_013;
            public const int Err_CancelOtherData = -11_05_014;
            public const int Err_ApprovalLimit = -11_05_015;
            public const int Err_CancelOldDataFailed = -11_05_016;
            //
            public const int Err_MakerLimit = -11_05_017;
            public const int Err_ApproveMultiTemplate = -11_05_018;
            public const int Err_CoT = -11_05_019;
        }

        public static class CI_ExtraCreditMaintenance
        {
            public const int Err_AutoId = -11_06_001;
            public const int Err_MovementId = -11_06_002;
            public const int Err_ValueDate = -11_06_003;
            public const int Err_AccountId = -11_06_004;
            public const int Err_CurrencyCd = -11_06_005;
            public const int Err_Amount = -11_06_006;
            public const int Err_ReleaseDate = -11_06_007;
            public const int Err_Description = -11_06_008;

            //
            public const int Err_AccountNotExisted = -11_06_009;
            public const int Err_MakerLimit = -11_06_010;
            public const int Err_MakerCantAccessAccountBranch = -11_06_011;
            public const int Err_RecordStatus = -11_06_012;
            public const int Err_ApproveSelfData = -11_06_013;
            public const int Err_CancelOtherData = -11_06_014;
            public const int Err_ApprovalLimit = -11_06_015;
            public const int Err_CancelOldDataFailed = -11_06_016;
            public const int Err_ApproveMultiTemplate = -11_06_017;
            public const int Err_AccountDerivativeInvalid = -11_06_018;
            public const int Err_AccountCashInvalid = -11_06_019;
            public const int Err_AccountStatusInvalid = -11_06_020;
            public const int Err_ReleaseDateEarlierThanBusDate = -11_06_021;

        }

        public static class CI_ExtraCreditReleaseMaintenance
        {
            public const int Err_AutoId = -11_07_001;
            public const int Err_MovementId = -11_07_002;
            public const int Err_ValueDate = -11_07_003;
            public const int Err_AccountId = -11_07_004;
            public const int Err_ReleaseDate = -11_07_005;
            public const int Err_ReleaseStatus = -11_07_006;
            public const int Err_RecordStatus = -11_07_007;
            //
            public const int Err_AccountNotExisted = -11_07_008;
            public const int Err_MakerLimit = -11_07_009;
            public const int Err_MakerCantAccessAccountBranch = -11_07_010;
            public const int Err_AccountDerivativeInvalid = -11_07_011;
        }

        public static class CI_DepositIMBatchPanel
        {
            public const int Err_AutoId = -11_08_001;
            public const int Err_MovementId = -11_08_002;
            public const int Err_TxDate = -11_08_003;
            public const int Err_AccountId = -11_08_004;
            public const int Err_CustId = -11_08_005;
            public const int Err_TranType = -11_08_006;
            public const int Err_Channel = -11_08_007;
            public const int Err_Amount = -11_08_008;
            public const int Err_Description = -11_08_009;
            public const int Err_AccountNotExisted = -11_08_010;
            public const int Err_AccountIsNoCashDeposit = -11_08_011;
            public const int Err_AmountLimit = -11_08_012;
            public const int Err_MakerCantAccessAccountBranch = -11_08_013;
            public const int Err_CoT = -11_08_014;
            //
            public const int Err_RecordStatus = -11_08_015;
            public const int Err_FoStatus = -11_08_016;

            public const int Err_MakerLimit = -11_08_017;
            public const int Err_TransactionType = -11_08_018;
            public const int Err_StpMarginRequestExisted = -11_08_019;
        }

        public static class CI_BatchWithdrawIM
        {
            public const int Err_AutoId = -11_09_001;
            public const int Err_MovementId = -11_09_002;
            public const int Err_TxDate = -11_09_003;
            public const int Err_AccountId = -11_09_004;
            public const int Err_CustId = -11_09_005;
            public const int Err_CurrencyCd = -11_09_006;
            public const int Err_TranType = -11_09_007;
            public const int Err_DwChannel = -11_09_008;
            public const int Err_Amount = -11_09_009;
            public const int Err_BankAccountId = -11_09_010;
            public const int Err_Description = -11_09_011;
            public const int Err_AccountNotExisted = -11_09_012;
            public const int Err_AccountCashWithdrawBlocked = -11_09_013;
            public const int Err_AmountLimit = -11_09_014;
            public const int Err_MakerCantAccessAccountBranch = -11_09_015;
            public const int Err_CoT = -11_09_016;
            //
            public const int Err_RecordStatus = -11_09_017;
            public const int Err_ApproveSelfData = -11_09_018;
            public const int Err_CancelOtherData = -11_09_019;
            public const int Err_ApprovalLimit = -11_09_020;
            public const int Err_FoStatus = -11_09_021;
            public const int Err_CancelOldDataFailed = -11_09_022;
            public const int Err_ApproveMultiTemplate = -11_09_023;
            public const int Err_MakerLimit = -11_09_024;
            public const int Err_TransactionType = -11_09_025;
            public const int Err_AmountInteger = -11_09_026;
            public const int Err_OverrideAmount = -11_09_027;
            public const int Err_CheckedFlag = -11_09_028;
            public const int Err_ConfigCheckInvalid = -11_09_029;
            public const int Err_OverrideAmountLimit = -11_09_030;
            public const int Err_BatchSettleSts = -11_09_031;
        }

        public static class CI_PostCollateralFee
        {
            public const int Err_AutoId = -11_10_001;
            public const int Err_TxNum = -11_10_002;
            public const int Err_TxDate = -11_10_003;
            public const int Err_AfAccNo = -11_10_004;
            public const int Err_TranType = -11_10_005;
            public const int Err_AccountNotExisted = -11_10_006;
            public const int Err_Description = -11_10_007;
            //
            public const int Err_TranDate = -11_10_008;
            public const int Err_SettleStatus = -11_10_009;
            public const int Err_FoStatus = -11_10_010;
            public const int Err_PostDataNull = -11_10_011;
        }

        public static class CI_CashWithdraw
        {
            public const int Err_AutoId = -11_11_001;
            public const int Err_MovementId = -11_11_002;
            public const int Err_ValueDate = -11_11_003;
            public const int Err_AccountId = -11_11_004;
            public const int Err_BatchId = -11_11_005;
            public const int Err_TransactionCode = -11_11_006;
            public const int Err_SettleCashById = -11_11_007;
            public const int Err_TransferType = -11_11_008;
            public const int Err_Amount = -11_11_009;
            public const int Err_FeeVal = -11_11_010;
            public const int Err_OverrideFee = -11_11_011;
            public const int Err_OverrideFeeVal = -11_11_012;
            public const int Err_BankAccountId = -11_11_013;
            public const int Err_ToBankName = -11_11_014;
            public const int Err_ToBankBranch = -11_11_015;
            public const int Err_ToBankAccountNo = -11_11_016;
            public const int Err_ToBankAccountName = -11_11_017;
            public const int Err_Requester = -11_11_018;
            public const int Err_AuthorizedPersonId = -11_11_019;
            public const int Err_Remark = -11_11_020;
            public const int Err_RemarkOther = -11_11_021;
            public const int Err_InternalRemark = -11_11_022;
            public const int Err_FoStatus = -11_11_023;
            public const int Err_ApprovalLimit = -11_11_024;
            public const int Err_RecordStatus = -11_11_025;
            public const int Err_ApproveSelfData = -11_11_026;
            public const int Err_CancelOldDataFailed = -11_11_027;
            public const int Err_AccountNotExisted = -11_11_028;
            public const int Err_AccountCashWithdrawBlocked = -11_11_029;
            public const int Err_AccountCustodianAccountType = -11_11_030;
            public const int Err_CheckingBalance = -11_11_031;
            public const int Err_TransactionExisted = -11_11_032;
            public const int Err_AmountLimit = -11_11_033;
            public const int Err_MakerCantAccessAccountBranch = -11_11_034;
            public const int Err_AccountStatusInvalid = -11_11_035;
            public const int Err_CheckLimit = -11_11_036;
            public const int Err_BankAccountCode_FundingAmount = -11_11_037;
            public const int Warn_TransactionExisted = -11_11_038;
            public const int Err_RemarkInternal_TransactionExisted = -11_11_039;
            public const int Err_AccountDerivativeInvalid = -11_11_040;
            public const int Err_ValueDateHoliday = -11_11_041;
            public const int Err_FromBankAccountNumber = -11_11_042;
            public const int Err_MakerLimit = -11_11_043;
            public const int Err_InputNegativeAmountNotAllowed = -11_11_044;
            public const int Err_DailyTransferLimit = -11_11_045;
            public const int Err_RequestId = -11_11_046;
            public const int Err_ApproveMaxAvailableBalanceBlocked = -11_11_047;
            public const int Err_InputOverAccountMaximumAmountPerTransaction = -11_11_048;
            public const int Err_InputOverAccountMaximumAmountPerDay = -11_11_049;
            public const int Err_ToBankIdNapasCitadCodeInvalid = -11_11_050;
            public const int Err_ToBankIdCitadCode = -11_11_051;
            public const int Err_ToBankIdNapasCode = -11_11_052;
            public const int Err_InputAmountOverMaxAvailableBalance = -11_11_053;
            public const int Err_AutoApproval = -11_11_054;
            public const int Err_BankAccountInfoUsageTypeDW = -11_11_055;
            public const int Err_BankTypeNapasCitadInvalid = -11_11_056;

            //
            public const int Err_OnlineTransaction_TransferType = -11_11_100;
        }

        public static class CI_CashDeposit
        {
            public const int Err_AutoId = -11_12_001;
            public const int Err_MovementId = -11_12_002;
            public const int Err_ValueDate = -11_12_003;
            public const int Err_AccountId = -11_12_004;
            public const int Err_AccountStatusInvalid = -11_12_005;
            public const int Err_TransactionCodeInvalid = -11_12_006;
            public const int Err_Amount = -11_12_007;
            public const int Err_BankAccNo = -11_12_008;
            public const int Err_AmountInteger = -11_12_009;
            public const int Err_MakerCantAccessAccountBranch = -11_12_010;
            public const int Warn_TransactionExisted = -11_12_011;
            public const int Err_BankTransactionCode = -11_12_012;
            public const int Err_UpdateBankInputElectronic = -11_12_013;
            public const int Err_RegistrationType = -11_12_014;
            public const int Err_AccountCashDepositBlocked = -11_12_015;
            public const int Err_CustNameUnmatch = -11_12_016;
            public const int Err_BankAccNoElectronicLedger = -11_12_017;
            public const int Err_UpdateBankInputTransactionIdExisted = -11_12_018;
            public const int Err_UpdateBankInputTransactionExisted = -11_12_019;
            public const int Err_CurrencyCd = -11_12_020;
            public const int Err_ApproveSelfData = -11_12_021;
            public const int Err_CancelOtherData = -11_12_022;
            public const int Err_RecordStatus = -11_12_023;
            public const int Err_AccountDerivativeInvalid = -11_12_024;
            public const int Err_AccountNotExisted = -11_12_025;
            public const int Err_AutoReleaseAmount = -11_12_026;
            public const int Err_AutoReleaseDate = -11_12_027;
            public const int Err_TransactionCode = -11_12_028;
            public const int Err_ValueDateHoliday = -11_12_029;
            public const int Err_TransactionExisted = -11_12_030;
            public const int Err_BankId = -11_12_031;
            public const int Err_AccountRegistrationTypeFiia = -11_12_032;
            public const int Err_AccountResidentCardExpired = -11_12_033;
            //
            public const int Response_UpdateBankInputResponse_Pending = -11_12_034;
            public const int Response_UpdateBankInputResponse_Error = -11_12_035;
            public const int Response_UpdateBankInputResponse_Success = -11_12_036;
            //
            public const int Err_BankName = -11_12_037;
            public const int Err_BankBranchId = -11_12_038;
            public const int Err_BankBranchName = -11_12_039;
            public const int Err_CustomerAcc = -11_12_040;
            public const int Err_CustomerName = -11_12_041;
            public const int Err_Description = -11_12_042;
            public const int Err_RequestId = -11_12_043;
            public const int Err_TransactionDate = -11_12_044;
        }

        public static class CI_CashDepositError
        {
            public const int Err_AutoId = -11_13_001;
            public const int Err_CustodianAccountType = -11_13_002;
            public const int Err_RegistrationType = -11_13_003;
            public const int Err_AccountStatusInvalid = -11_13_004;
            public const int Err_AccountCashDepositBlocked = -11_13_005;
            public const int Err_BankAccount = -11_13_006;
            public const int Err_MakerCantAccessAccountBranch = -11_13_007;
            public const int Err_ApprovalLimit = -11_13_008;
            public const int Err_WorkflowStatus = -11_13_009;
            public const int Err_TransactionIdExisted = -11_13_010;
            public const int Err_InputLimit = -11_13_011;
            public const int Err_ValueDate = -11_13_012;
        }

        public static class CI_CashDepositElectronic
        {
            public const int Err_AccountNotExisted = -11_14_001;
            public const int Err_MakerCantAccessAccountBranch = -11_14_002;
            public const int Err_ApprovalLimit = -11_14_003;
            public const int Err_ValueDate = -11_14_004;
        }

        public static class CI_CashHold
        {
            public const int Err_AccountNotExisted = -11_15_099;
            public const int Err_AccountStatusInvalid = -11_15_098;
            public const int Err_ValueDateSmallerThanCurrentDate = -11_15_097;
            public const int Err_AmountLimitInvalid = -11_15_096;
            public const int Err_AutoRelease_ValueDateSmallerThanCurrentDate = -11_15_095;
            public const int Err_AutoRelease_ReleaseDateSmallerThanHoldDate = -11_15_094;
            public const int Err_AutoRelease_ReleaseDateIsHoliday = -11_15_093;
            public const int Err_AutoRelease_ReleaseAmountGreaterThanHoldAmount = -11_15_092;
            public const int Err_AccountIsMapBankAccount = -11_15_091;
            public const int Err_CustodianFlag = -11_15_090;
            public const int Err_DeleteRecordCreatedInThePast = -11_15_089;
            public const int Err_DeleteRecordHadReleaseRecord = -11_15_088;
            public const int Err_ValueDate_Is_Holiday = -11_15_087;
            public const int Err_Dupplicate_BatchId = -11_15_086;
            public const int Err_Amount_MoreThan_MaxAvailableAmount = -11_15_085;


            public const int Err_ValueDate = -11_15_001;
            public const int Err_AccountId = -11_15_002;
            public const int Err_Amount = -11_15_003;
            public const int Err_BatchId = -11_15_004;
            public const int Err_LinkId = -11_15_005;
            public const int Err_RemainingHold = -11_15_006;
            public const int Err_Remark = -11_15_007;
            public const int Err_RemarkEx = -11_15_008;
            public const int Err_RemarkInternal = -11_15_009;
            public const int Err_HoldTypeId = -11_15_010;
            public const int Err_MovementTypeId = -11_15_011;
            public const int Err_TransactionType = -11_15_012;
            public const int Err_SettleStatus = -11_15_013;
            public const int Err_CurrencyId = -11_15_014;
            public const int Err_AutoReleases = -11_15_015;
            public const int Err_AutoReleaseDate = -11_15_016;
            public const int Err_AutoReleaseAmount = -11_15_017;
            public const int Err_AutoReleaseRemark = -11_15_018;
            public const int Err_MakerCantAccessAccountBranch = -11_15_019;
            //public const int Err_Remark = -11_15_020;
            //public const int Err_Remark = -11_15_021;
        }

        public static class CI_CashRelease
        {
            public const int Err_AutoId = -11_16_001;
            public const int Err_MovementId = -11_16_002;
            public const int Err_AccountNotExisted = -11_16_012;

            public const int Err_MakerCantAccessAccountBranch = -11_03_015;
            //
            public const int Err_AccountStatusInvalid = -11_16_028;
            public const int Err_AccountDerivativeInvalid = -11_16_029;
            public const int Err_CustodianFlag = -11_16_030;
            public const int Err_AutoReleaseDate_Value_Invalid = -11_16_031;
            public const int Err_AutoReleaseDate_Is_Holiday = -11_16_032;
            public const int Err_AutoReleaseDate_Smaller_Than_BusDate = -11_16_033;
            public const int Err_AutoReleaseDate_Smaller_Than_HoldDate = -11_16_034;
            public const int Err_AutoReleaseAmount = -11_16_035;
            public const int Err_AutoReleaseRemark = -11_16_036;
            public const int Err_CashReleaseDetails = -11_16_037;
            public const int Err_CashReleaseDetails_Release_Over_Limit = -11_16_038;
            public const int Err_When_Delete_Reject_Record = -11_16_039;

            public const int Err_DeleteRecordCreatedInThePast = -11_16_089;
            public const int Err_insertCashReleaseDetail_delete_oldRecord = -11_16_090;
            public const int Err_insertCashReleaseDetail_Insert_NewRecord = -11_16_091;
            public const int Err_insertCashReleaseDetail_Exception = -11_16_092;
            //public const int Err_DeleteRecordCreatedInThePast = -11_15_089;
        }

        public static class CI_InternalCashTranfer
        {
            public const int Err_MovementId = -11_17_001; // ID không hợp lệ | ID invalid
            public const int Err_AccountNotExisted = -11_17_002; // Tài khoản không tồn tại | Account is not existed
            public const int Err_AccountDerivativeInvalid = -11_17_003;  // Tài khoản phải là tài khoản phái sinh | Account type must be derivative
            public const int Err_AccountCashInvalid = -11_17_004; // Không tìm thấy mã tiền tệ trong danh mục tiền của tài khoản. Vui lòng chọn lại mã tiền tệ: {0}  // Account's cash information does not contain value of selected currency. Please choose another currency: {0}
            public const int Err_AccountStatusInvalid = -11_17_005; // Trạng thái tài khoản không hợp lệ | Account status is invalid
            public const int Err_ValueDate = -11_17_006; // Ngày giao dịch không hợp lệ | Value Date invalid
            
            public const int Err_Amount = -11_17_007; // Số tiền phải lớn hơn 0 | Amount must be greater than 0
            public const int Err_AmountLimit = -11_17_008; // Số tiền lớn hơn số tiền có thể chuyển | The amount is larger than the amount that can be transferred
            public const int Err_AmountInteger = -11_17_009; // Số tiền phải là số nguyên | Amount must be an integer

            public const int Err_BankAccountId = -11_17_010; // Tài khoản giao dịch đối ứng không hợp lệ | Firm's Bank Acc invalid
            public const int Err_MakerCantAccessAccountBranch = -11_17_011; // User không được thao tác với chi nhánh của Tài khoản | Can not access account branch
            public const int Err_MakerLimit = -11_17_012; // Vượt quá số tiền có thể nhập Hạn mức: {0} | Over input limit
            public const int Err_DailyTransferLimit = -11_17_013; // Vượt quá hạn mức giao dịch trong ngày | Over daily transfer limit
            public const int Err_FoStatus = -11_17_014; // Trạng thái FO không hợp lệ | FO status invalid
            public const int Err_ApprovalLimit = -11_17_015; // Vượt quá hạn mức có thể duyệt. Hạn mức: {0} | Input over approval limit: Limit {0}
            public const int Err_AccountId_Block_Tranfer = -11_17_016; // Tài khoản chuyển tiền bị chặn | Account tranfer is block
            public const int Err_AccountId_Block_Receive = -11_17_017; // Tài khoản nhận tiền bị chặn | Account receive is block
            public const int Err_AccountNotExisted_Receive = -11_17_018; // Tài khoản nhận không tồn tại | Account receive is not existed
            public const int Err_AccountStatusInvalid_Receive = -11_17_019; // Trạng thái tài khoản nhận không hợp lệ | Account status receive is invalid
            public const int Err_AccountDerivativeInvalid_Receive = -11_17_020;  // Tài khoản nhận phải là tài khoản phái sinh | Account receive type must be derivative
            public const int Err_TransactionCode = -11_17_021;  // Hình thức chuyển tiền không hợp lệ | Transaction code invalid
            public const int Err_Account_Receive = -11_17_022;  // Không cho phép chuyển nội bộ khác tên chưa đăng ký trước | Internal transfers to other than previously registered names are not allowed
            public const int Err_Block_Tranfer = -11_17_023;  // Không cho phép thực hiện các giao dịch chuyển tiền | Money tranfer transaction are not allowed

            //
            public const int Err_TCAccountCashMovement_Update = -11_17_024;  // [TCAccountCashMovement] Lỗi cập nhật dữ liệu | [TCAccountCashMovement] error update data
            public const int Err_BCAccountCashDer_Update = -11_17_025;  // [BCAccountCashDer] Lỗi cập nhật dữ liệu | [BCAccountCashDer] error update data
            public const int Err_TCSAccountTransaction_Insert = -11_17_026;  // [TCSAccountTransaction] Lỗi thêm mới dữ liệu | [TCSAccountTransaction] error insert data
            public const int Err_TCSAccountTransactionDetail_Insert = -11_17_027;  // [TCSAccountTransactionDetail] Lỗi thêm mới dữ liệu | [TCSAccountTransactionDetail] error insert data
            public const int Err_BCAccountCashDer_NotFound = -11_17_028;  // [BCAccountCashDer] Không có dữ liệu | [BCAccountCashDer] error data not found
            public const int Err_TCAccountCashMovement_Delete = -11_17_029;  // [TCAccountCashMovement] Lỗi xóa dữ liệu | [TCAccountCashMovement] error delete data
            public const int Err_TCAccountCashMovement_Insert = -11_17_030;  // [TCAccountCashMovement] Lỗi thêm mới dữ liệu | [TCAccountCashMovement] error insert data
            public const int Err_TransactionDateInvalid = -11_17_031;  // Ngày ghi nhận giao dịch không hợp lệ | Transaction date invalid
            public const int Err_CurrencyCd = -11_17_032;  // Tiền tệ không hợp lệ | Currency invalid
            public const int Err_AuthorizedPersonId = -11_17_033;  // Người ủy quyền không hợp lệ | Authorized person invalid
            public const int Err_CheckLimit_Invalid = -11_17_034;  // CheckLimit không hợp lệ | CheckLimit invalid

            public const int Err_InputOverAccountMaximumAmountPerTransaction = -11_17_035; // Vượt quá số tiền có thể rút trên một giao dịch của tài khoản | Amount over account's maximum available amount per transaction
            public const int Err_ApproveMaxAvailableBalanceBlocked = -11_17_036; // Vượt quá số tiền tối đa có thể chuyển khi thực hiện duyệt | Approval amount over max available balance 
            public const int Err_InputOverAccountMaximumAmountPerDay = -11_17_037; // Vượt quá số tiền có thể chuyển trong một ngày của tài khoản | Amount over account's maximum tranfer amount per day
            public const int Err_BankAccountCode_invalid = -11_17_038; // Mã TKNH nguồn của SSI không hợp lệ | Bank Account Code invalid
            public const int Err_MCBankAccount_NotExist = -11_17_039; // BankAccount không tồn tại | Bank Account invalid
            public const int Err_MCBankBranch_NotExist = -11_17_040; // BankBranch không tồn tại | Bank Branch invalid
            public const int Err_MCBank_NotExist = -11_17_041; // Bank không tồn tại | Bank invalid
            public const int Err_OnlineTransferType_Invalid = -11_17_042; // OnlineTransferType không hợp lệ | OnlineTransferType invalid
            public const int Err_OnlineTransferType_SupportElectronicYcd_Invalid = -11_17_043; // Hình thức chuyển tiền nội bộ khác tên bắt buộc chọn TKNH nguồn có hỗ trợ Chi hộ | Internal Cash Transfer - non owner's account
            public const int Err_BankType_Napas_Invalid = -11_17_044; // Ngân hàng nhận hiện không khai báo NapasCode, đề nghị chọn lại bank nguồn hợp lệ | To Bank Name has not NapasCode, please select a valid Bank Account ID
            public const int Err_BankType_CitadCode_Invalid = -11_17_045; // Ngân hàng nhận hiện không khai báo CitadCode, đề nghị chọn lại bank nguồn hợp lệ | To Bank Name has not CitadCode, please select a valid Bank Account ID
            public const int Err_BankType_Napas_Limit_Invalid = -11_17_046; // Số tiền chuyển vượt quá hạn mức Napas, đề nghị chọn lại bank nguồn hợp lệ | The transfer amount exceeds the Napas limit, please select a valid source bank
            public const int Err_BankAccountUsageType_NotExist = -11_17_047; // BankAccountUsageType không hợp lệ | BankAccountUsageType invalid
            public const int Err_SupportelEctronicLedger_Invalid = -11_17_048; // Tài khoản ngân hàng nguồn yêu cầu phải hỗ trợ chi hộ và thu hộ |  Bank Account ID required Support Credit Electronic Transfer and Support Debit Electronic Transfer

            public const int Err_MCBankAccount_BankType_invalid = -11_17_049; // BankAccount BankType không hợp lệ | BankAccount BankType invalid
            public const int Err_ToBankAccountNumber_invalid = -11_17_050; // To Bank Account Number không hợp lệ | To Bank Account Number invalid
            public const int Err_ToBankAccountName_invalid = -11_17_051; // To Bank Account Name không hợp lệ | To Bank Account Name invalid
            public const int Err_OnlineTransferType_AccountRegistered_Invalid = -11_17_052; // Hình thức chuyển tiền không hợp lệ, tài khoản nhận không được đăng ký trước | Transfer Type invalid, Transfer To Account Id is UnRegistered
            public const int Err_TransactionCode_AccountRecei_Invalid = -11_17_053; // Hình thức chuyển tiền với người nhận không hợp lệ | Transaction code to account recei invalid
            public const int Err_RequestId = -11_17_054; // Request ID không hợp lệ | Request ID is invalid

            public const int Err_AccountCashWithdrawBlocked = -11_17_055; // Tài khoản không thể thực hiện giao dịch chuyển tiền | Account cannot make money transfer

        }
    }
}
