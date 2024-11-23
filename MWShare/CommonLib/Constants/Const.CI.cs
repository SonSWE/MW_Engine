using NLog.LayoutRenderers;
using System.Data;

namespace CommonLib.Constants
{
    public partial class Const
    {
        public static class CI
        {
            public static class CIDepository_Status
            {
                public const string Pending = "N";
                public const string Rejected = "R";
                public const string Active = "A";
            }

            public static class CIDepository_StsBank
            {
                public const string Pending = "N";
                public const string Completed = "C";
                public const string Error = "E";
            }
        }

        public static class CashTransfer_TransType
        {
            public const string Deposit = "D";
            public const string Withdraw = "W";
            public const string PostFee = "N";
        }

        public static class CI_SettleStatus
        {
            public const string Pending = "P";
            public const string Settle = "S";
            public const string Rejected = "R";
            public const string Unsettle = "U";
        }

        public static class CashTransfer_DwChannel
        {
            public const string Margin = "MG";
            public const string Settlement = "ST";
            public const string PhysicalDeliverySettlement = "DL";

            //
            public const string Online = "ON";

            public const string Offline = "OF";

            public const string Citad = "CITAD";
            public const string Napas = "NAPAS";

            public const string InternalCashTranfer_Online = "Online";
            public const string InternalCashTranfer_Offline = "Offline";
        }

        public static class CI_TransactionType
        {
            public const string DepositIM = "VSDCDIM";
            public const string WithdrawIM = "VSDCWIM";
            public const string ExtraCreditMaintenance = "CBEC";
            public const string ExtraCreditReleaseMaintenance = "CBECR";
            public const string CashDeposit = "CD";
            public const string CashHold = "CH";
            public const string CashRelease = "CR";
            public const string PostCollateralFee = "VSDFCO";
            public const string OnlineDeposit = "OCD";
            public const string OnlineCashWithdraw = "OCW";
            public const string CashWithdraw = "CW";

            //
            public const string CBSSIVSDDI = "CBSSIVSDDI";

            public const string InternalCashTranfer = "ICT";
            public const string OnlineInternalCashTranfer = "OICT";
            public const string Order = "OD";
        }

        public static class CI_TransactionId_API
        {
            public const string Deposit = "D";
            public const string Withdraw = "W";
            public const string All = "ALL";
        }

        public static class CI_WithdrawalType
        {
            public const string CallLostWithdrawal = "C";
            public const string NoPositionWithdrawal = "N";
            public const string TotalWithdrawalVSD = "T";
        }

        public static class CI_AccountStatus
        {
            public const int CloseviaVSD = 1;
            public const string Closed = "C";
            public const string Active = "A";
            public const int TransferviaVSD = 4;
            public const string Suspend = "S";
        }

        public static class CI_CustodianAccountType
        {
            public const string TOO = "TOO";
            public const string TCI = "TCI";
            public const string TCO = "TCO";
        }

        public static class CI_CashDepositConnectBankType
        {
            public const int Valid = 0;
            public const int Electronic = 1;
            public const int Error = 2;
        }

        public static class CI_CashTransfer_DepositType
        {
            public const string OnlineDeposit = "O";
            public const string CashDeposit = "C";
            public const string ErrorDeposit = "E";
        }

        public static class CI_CashTransfer_WorkflowStatus
        {
            public const string ApprovalAndPendingSendTobank = "AP";
            public const string SentToBank = "SB";
            public const string BankProcessedSuccessfully = "BP";
            public const string BankRejected = "BR";

            //
            public const string ValidData = "VD";

            public const string InvalidData = "ID";
            public const string ManualUpdate = "MU";
            public const string NeedInvestigation = "NI";
            public const string InvestigationCompleted = "IC";
            public const string Processed = "PR";
            public const string ProcessOffline = "PO";
        }

        public static class CI_MovementTypeId
        {
            public const string Deposit = "D";
            public const string Withdraw = "W";
            public const string ExtraCredit = "E";
            public const string Release = "R";
            public const string Hold = "H";
            public const string InternalCashTranfer = "T";
        }

        public static class CI_BatchWithdrawTypeId
        {
            public const string Individual = "I";
            public const string Batch = "B";
        }

        public static class CI_FOStatus
        {
            public const string Accepted = "A";
            public const string Success = "S";
            public const string Pending = "P";
        }

        public static class CI_TransactionCode
        {
            public const string DepositIM = "CCPDCVSDIM";
            public const string OnlineDeposit = "OCD";
            public const string OnlineDepositError = "OCDE";
            public const string OnlineDepositElectronic = "OCDL";
            public const string API = "API";
            public const string OnlineCashWithdraw = "OCW";
            public const string OnlineCashWithdrawAPI = "OCWAPI";
            public const string CashReleaseCreateBySystem = "CRS";
            public const string CashReleaseCreateByUser = "CRU";
            public const string CashWithdraw = "CW";
            public const string CashWithdrawAPI = "CWAPI";
            public const string InternalCashTranfer = "ICT";
            public const string InternalCashTranfer_OtherService = "ICTOS";
            public const string InternalCashTranfer_Online = "OICT";
            public const string InternalCashTranfer_InputOnline = "OICTAPI";
            public const string TransferToOutside = "CTO";
        }

        public static class CI_CashDeposit_TransactionCode
        {
            public const string Deposit = "CD";
            public const string OnlineBankIn = "OCBI";
            public const string TransferFromOutside = "CFO";
            public const string OnlineDeposit = "OCD";
            public const string DepositMapbank = "CDC";
        }

        public static class CI_CashWithdraw_TransactionCode
        {
            public const string CashWithdraw = "CW";
            public const string TransferToOutside = "CTO";
            public const string WithdrawMapbank = "CWC";
            public const string OnlineBankOutMapBank = "OCBO";
            public const string OnlineWithdraw = "OCW";
            public const string SEC = "SEC";
            public const string CashWithdrawOtherService = "CWOS";
        }

        public static class CI_FinIn_MessageType
        {
            public const string Noti = "NOTI";
            public const string Credit = "CREDIT";
            public const string VSD_598 = "598";
            public const string NAK103 = "NAK103";
            public const string Debit = "DEBIT";
            public const string ACK103 = "ACK103";
        }

        public static class CI_FinIn_Source
        {
            public const string VSD = "VSD";
            public const string VTB = "VTB";
        }

        public static class CI_FinIn_BankSendStatus
        {
            public const string C = "C";
            public const string E = "E";
        }

        public static class CI_FinIn_BankResponseStatus
        {
            public const string Rejected = "REJ";
            public const string Zero = "0";
        }

        public static class CI_FinIn_MTCode
        {
            public const string MT910 = "MT910";
        }

        public static class CI_TransactionSubType
        {
            public const string AMT = "AMT";
            public const string FEE = "FEE";
            public const string TAX = "TAX";
            public const string COM_DAYTRADE = "COM_DAYTRADE";
            public const string COM_TRADINGFEE = "COM-TRADINGFEE";
            public const string COM_EXPIRY = "COM-EXPIRY";
            public const string EX_FEE = "EX-FEE";
            public const string VSD_FEE = "VSD-FEE";
        }

        public static class CI_ProductClass
        {
            public const string Derivative = "FOS";
            public const string Equity = "EQT";
        }

        public static class CI_PostStatus
        {
            public const string Posted = "P";
            public const string UnPosted = "U";
        }

        public static class CI_CashHoldType
        {
            public const string ThirdParty = "1";
            public const string Client = "2";
            public const string Company = "3";
        }

        public static class CI_InterestTypeID
        {
            public const string CISSI = "CISSI";
            public const string DISSI = "DISSI";
            public const string CIVSD = "CIVSD";
        }

        public static class CI_FeeNatureCategoryId
        {
            public const string DER_LEVY = "DER_LEVY";
        }

        public static class CI_InterestAdjustmentType
        {
            /// <summary>
            /// Điều chỉnh lãi
            /// </summary>
            public const string Interest_Adjustments = "IA";

            /// <summary>
            /// Thanh toán lãi
            /// </summary>
            public const string Interest_Payments = "IP";

            /// <summary>
            /// Điều chỉnh và thanh toán lãi
            /// </summary>
            public const string Adjustments_Interest_Payments = "AI";
        }

        public static class CI_AccountInterface_TransferType
        {
            public const string DifferentName = "1";
            public const string SameName = "2";
        }

        public static class CI_CashWithdraw_TransferType
        {
            public const string SameName_Registered = "1";
            public const string SameName_Unregistered = "2";
            public const string OtherName_Registered = "3";
            public const string OtherName_Unregistered = "4";
            public const string Other = "5";
        }

        public static class CI_BankDeposit_AccountType
        {
            public const string P = "P";
            public const string C = "C";
        }

        public static class CI_BankDeposit_DepositType
        {
            public const string IM = "IM";
        }

        public static class CI_BankCashWithdrawResponseStatus
        {
            public const string A = "A";
            public const string T = "T";
            public const string E = "E";
            public const string S = "S";
        }

        public static class CI_OnlineTransferType
        {
            public const string CHUYEN_TIEN_NOI_BO_CUNG_TEN = "11";
            public const string CHUYEN_TIEN_NOI_BO_KHAC_TEN_CO_DANG_KY_TRUOC = "12";
            public const string CHUYEN_TIEN_NOI_BO_KHAC_TEN_KHONG_DANG_KY_TRUOC = "13";
        }

        public static class CI_AccountSubStatusCode
        {
            public const string NO_CASH_WITHDRAW = "No Cash Withdraw";
            public const string NO_CASH_DEPOSIT = "No Cash Deposit";
            public const string NO_CASH_WITHDRAW_ONLINE = "No Cash Withdraw Online";
            public const string PROHIBIT_DEPOSIT_IM = "Prohibit Deposit IM";
            public const string PROHIBIT_WITHDRAW_IM = "Prohibit Withdraw IM";
        }

        public static class CashTransfer_Requester
        {
            public const string AuthorizedPerson = "A";
            public const string Owner = "O";
        }

        public static class CI_FOApprove
        {
            public const string ReceiFromFOResponse = "FO";
        }

        public static class CI_AutoApproval
        {
            public const string AutoApproval_NoCheckLimit = "0";
            public const string NoAutoApproval_NoCheckLimit = "1";
            public const string NoAutoApproval_CheckLimit = "2";
        }

        public static class CI_ConstantUser
        {
            public const string Sys = "Sys";
            public const string FO = "FO";
            public const string AutoApproval = "Auto Approval";
            public const string AutoApproved = "Auto Approved";
            public const string UserBank = "User Bank";
        }

        public static class CI_DataType
        {
            public const string Uy_Quyen_Theo_Tai_Khoan = "ACC";
            public const string Uy_Quyen_Theo_Khach_Hang = "CUS";
        }

        public static class CI_Authority_Type
        {
            public const string Uy_Quyen_Giao_Dich = "1";
            public const string Uy_Quyen_Giao_Nhan_Chung_Tu = "2";
            public const string Uy_Thac_Dau_Tu = "3";
        }

        public static class CI_Authority_AuthorityScope
        {
            public const string Uy_Quyen_Toan_Bo = "1";
            public const string Uy_Quyen_Giao_Dich_Tien_Tren_Tai_Khoan = "3"; // : Ủy quyền giao dịch Tiền trên tài khoản
        }

        public static class CI_ConstantMessage
        {
            public const string DepositIM_SendBOC = "Nop tien ky quy";
            public const string DerNotAllowProcessingInBatch = "Error derivatives not allow processing inbatch";
            public const string InternalServerError = "InternalServerError";
            public const string ExtraCreditRelease = "Extra Credit Release";
        }

        public static class CI_BankCashDepositReturnCode
        {
            public const string Success = "0";
            public const string Error = "1";
        }

        public static class CI_BankCashDepositResponseMessage
        {
            public const string Success = "THÀNH CÔNG";
        }

        public static class CI_BankAPIWithdrawIM_CheckBicCode
        {
            public const string CheckBicCode_06 = "06";
        }

        public static class CI_BankAPI_ReturnCode
        {
            public const string ReturnCode_000 = "000";
            public const string ReturnCode_Empty = "";
        }

        public static class CI_CashRelease_const
        {
            public const string Updated = "Updated";
            public const string RejectToDeleteStatus = "RD";
        }

        public static class CI_CashDeposit_Constant
        {
            public const string Updated = "Updated";
            public const string RejectToDeleteStatus = "RD";

            public const string Account_003C = "003C";
            public const string Account_003F = "003F";

            public static long GetRemarkByTransactionCode(string transactionCode, out string remark, out string remarkOther)
            {
                remark = string.Empty;
                remarkOther = string.Empty;
                if (transactionCode == Const.CI_CashDeposit_TransactionCode.Deposit)
                {
                    remark = "Nop tien tai quay";
                    remarkOther = "Deposit";
                }
                else if (transactionCode == Const.CI_CashDeposit_TransactionCode.TransferFromOutside)
                {
                    remark = "Nhận lại tiền do YCCK ghi sai thông tin người thụ hưởng";
                    remarkOther = "Cash repayment due to incorrect beneficiary information";
                }
                else if (transactionCode == Const.CI_CashDeposit_TransactionCode.OnlineBankIn)
                {
                    remark = "CASH AT BANK DEPOSIT VND";
                    remarkOther = "CASH AT BANK DEPOSIT VND";
                }
                else if (transactionCode == Const.CI_CashDeposit_TransactionCode.DepositMapbank)
                {
                    remark = "Nop tien TK MapBank";
                    remarkOther = "MapBank Deposit";
                }

                return 1;
            }
        }

        public static class CI_CashWithdraw_Constant
        {
            public static long GetRemarkByTransactionCode(string transactionCode, out string remark, out string remarkOther)
            {
                remark = string.Empty;
                remarkOther = string.Empty;
                if (transactionCode == Const.CI_CashWithdraw_TransactionCode.TransferToOutside)
                {
                    remark = "Chuyển khoản TK ngân hàng";
                    remarkOther = "Transfer to Outside";
                }
                else if (transactionCode == Const.CI_CashWithdraw_TransactionCode.CashWithdraw)
                {
                    remark = "Rut tien tai quay";
                    remarkOther = "Withdrawal";
                }
                else if (transactionCode == Const.CI_CashWithdraw_TransactionCode.WithdrawMapbank)
                {
                    remark = "";
                    remarkOther = "";
                }
                else if (transactionCode == Const.CI_CashWithdraw_TransactionCode.OnlineBankOutMapBank)
                {
                    remark = "CASH AT BANK WITHDRAW VND";
                    remarkOther = "CASH AT BANK WITHDRAW VND";
                }

                return 1;
            }
        }

        public static class CI_TSAccountCashMovement_API
        {
            public const string Default = "1";
        }

        public static class CI_SettleCashById
        {
            public const string InAvailableBalance = "1";
            public const string UnCheckBalance = "2";
            public const string EE = "3";
            public const string EECertainRatio = "4";
            public const string UnderCallForceSell = "5";
            public const string Rw1 = "6";
            public const string OverWithdrawalSSI = "7";
        }

        public class TYPE_OPENCLOSEPOSITIONSUMMARY
        {
            public const string CLOSE = "Close";
            public const string OPEN = "Open";
        }

        public class TYPE_CONTACT
        {
            public const string ADDRESS = "ADD";
            public const string PHONE = "TEL";
            public const string EMAIL = "EML";
        }
        public class CI_TYPE_CHANGE_TRANSITION
        {
            public const string CHANGE_SSI = "SSI";
            public const string CHANGE_VSD = "VSD";
        }
    }
}