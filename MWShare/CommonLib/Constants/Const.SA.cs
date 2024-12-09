namespace CommonLib.Constants
{
    public static partial class Const
    {
        public static class SA
        {
            public static class Status
            {
                public const string Active = "A";
                public const string Offline = "O";
                public const string Closed = "C";
                public const string Block = "B";
                public const string Expired = "E";
                public const string Pending = "N";
                public const string Rejected = "R";
                public const string Cancelled = "X";
            }

            public static class DpType
            {
                public const string Branch = "B";
                public const string Department = "D";
            }

            public static class DpZone
            {
                public const string MienBac = "N";
                public const string MienNam = "S";
                public const string MienTay = "W";
                public const string MienTrung = "C";
            }
            #region FeeunType
            public static class FeeTradingType
            {
                public const string TuGiaDich = "N";
                public const string CoHoTroTuVan = "Y";

                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return false;

                    if (value.Equals(FeeTradingType.TuGiaDich)
                        || value.Equals(FeeTradingType.CoHoTroTuVan)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }
            public static class CfType
            {
                public const string KhachHangNuocNgoai = "F";
                public const string KhachHangTrongNuoc = "D";
                public const string ToChucNN = "B";

                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return false;

                    if (value.Equals(CfType.KhachHangNuocNgoai)
                        || value.Equals(CfType.KhachHangTrongNuoc) || value.Equals(CfType.ToChucNN)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }
            public static class IsDefault
            {
                public const string BinhThuong = "N";
                public const string MacDinh = "Y";


                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return false;

                    if (value.Equals(IsDefault.BinhThuong)
                        || value.Equals(IsDefault.MacDinh)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }
            #endregion

            #region FeeunDetail
            public static class CalType
            {
                public const string TheoTyLe = "P";
                public const string SoFix = "T";

                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return true;

                    if (value.Equals(CalType.TheoTyLe)
                        || value.Equals(CalType.SoFix)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }

            public static class RuleType
            {
                public const string PhiThongThuong = "N";
                public const string PhiBacThang = "T";

                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return true;

                    if (value.Equals(RuleType.PhiThongThuong)
                        || value.Equals(RuleType.PhiBacThang)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }

            public static class SecType
            {
                public const string TatCa = "AL";
                public const string CoPhieu = "S";
                public const string TraiPhieu = "B";
                public const string ChungQuyen = "W";
                public const string ChungChiQuy = "M";
                public const string HopDongQuyenChon = "O";
                public const string HopDongTuongLai = "F";
                public const string ETF = "E";
            }

            public static class RoundType
            {
                public const string LamTronLen = "U";
                public const string LamTronXuong = "D";
                public const string LamTronSoHoc = "M";
                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return true;

                    if (value.Equals(RoundType.LamTronLen)
                        || value.Equals(RoundType.LamTronXuong)
                        || value.Equals(RoundType.LamTronSoHoc)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }
            public static class Period
            {
                public const string TheoGiaoDich = "T";
                public const string TheoNgay = "D";
                public const string TheoThang = "M";
                public const string MotNgayXacDinh = "S";
                //
                public static bool IsValid(string value)
                {
                    if (string.IsNullOrEmpty(value)) return true;

                    if (value.Equals(Period.TheoGiaoDich)
                        || value.Equals(Period.TheoNgay)
                        || value.Equals(Period.TheoThang)
                        || value.Equals(Period.MotNgayXacDinh)
                    )
                    {
                        return true;
                    }

                    return false;
                }
            }
            #endregion
            public static class SplitFlag
            {
                public const string NotApplicable = "";
                public const string Split = "S";
            }

            public static class HaltFLag
            {
                public const string NotApplicable = "";
                public const string BuyingHalt = "B";
                public const string SellingHalt = "S";
                public const string BuyingAndSellingHalt = "A";
                public const string NotChange = "X";
            }

            public static class Suspension
            {
                public const string NotApplicable = "";
                public const string SecuritySuspended = "S";
            }

            public static class BenefitFlag
            {
                public const string NotApplicable = "";
                public const string ExDividendAndExRights = "A";
                public const string ExDividend = "D";
                public const string ExRights = "R";
            }

            public static class Meeting
            {
                public const string NotApplicable = "";
                public const string ExMeeting = "M";
            }

            public static class Delist
            {
                public const string NotApplicable = "";
                public const string DelistSecurity = "D";
            }

            public static class CoveredWarrantType
            {
                public const string NotApplicable = "";
                public const string Call = "C";
                public const string Put = "P";
            }

            public static class Branch
            {

            }

            public static class SAUser_ResetPass
            {
                public const string BinhThuong = "N";
                public const string YeuCauDoiPass = "Y";

            }

            public static class SmsTemplate_NType
            {
                public const string ChangePass = "CHANGEPASS";
                public const string ResetPass = "RESETPASS";
            }
            public static class SA_IsHoldDaily
            {
                public const string Yes = "Y";
                public const string No = "N";
                public static bool CheckYes(string value)
                {
                    if (string.IsNullOrEmpty(value)) return false;
                    switch (value)
                    {
                        case Yes:
                            return true;
                        default:
                            return false;
                    }
                }
            }
            public static class FeeNatureParameter
            {
                public const string SystemCodeIdTradeTypeFOS = "SYS_TRADETYPE_FOS";
                public const string SystemCodeIdTradeTypeEQT = "SYS_TRADETYPE_EQT";

                public const string MCFeeNatureSeq = "seq_mcfeenatureid";

                public const string FeeNatureDivisorTypeCdtype = "FEE_DIVISORTYPE";
                public const string FeeNatureTypeId_DER_CONTRACT = "DER_CONTRACT";


            }

            public static class FeeNatureParameter_ParameterId
            {
                public const string ProductClass = "FNForProductClass";
                public const string Category = "FN_CATEGORY";
                public const string Type = "FN_TYPE";
                public const string RegistrationGroup = "RegistrationGroupID";
                public const string InstrumentGroup = "InstrumentGroupID";
                public const string MarketGroup = "MarketGroupID";
                public const string TradeType = "TradeType";
                public const string UnderlyingId = "UnderlyingID";
            }

            public static class PromotionPeriodParameter
            {
                public const string pTransactionTypeInput = "TransactionTypeInput"; // in
                public const string pMarketID = "MarketID"; // in
                public const string pBranch = "Branch"; // in
                public const string pAccountType = "AccountType"; // in
                public const string pAccountID = "AccountID"; //in
                public const string pOpenDateWithinXDay = "OpenDateWithinXDay"; // =
                public const string pOpenDateWithinXWeek = "OpenDateWithinXWeek"; // =
                public const string pOpenDateWithinXYear = "OpenDateWithinXYear"; // =
                public const string pOpenDateFrom = "OpenDateFrom"; // =
                public const string pOpenDateTo = "OpenDateTo"; // =
                public const string pRegistrationType = "RegistrationType"; // in
                public const string pInstrumentType = "InstrumentType"; // in
                public const string pInstrumentID = "InstrumentID"; // in
                public const string pUnderlyingID = "UnderlyingID"; // in
                public const string pAEID = "AEID"; // in
                public const string pRunnerID = "RunnerID"; // in
                public const string pAESupport = "AESupport"; // in
                public const string pFeeClassID = "FeeClassID"; // in
                public const string pGender = "Gender"; // in
                public const string pMatchedValue = "MatchedValue"; // =
                public const string pFrom = "From"; // =
                public const string pTo = "To"; // =
                public const string pTradeType = "TradeType"; // in
                public const string pChannelID = "ChannelID"; // in
                public const string pLoanType = "LoanType"; // in

                public const string oEqual = "="; // in
                public const string oIn = "in"; // in
            }

            public static class PromotionPeriodAllcode
            {
                public const string PercentDiscountTypeEQT = "ED";
                public const string PercentDiscountTypeFOS = "FD";
            }

            public static class InterestClassAllcode
            {
                public const string INTERESTCLASSRATEDIVISORCDCODE = "INTERESTCLASS_RATEDIVISOR";
                public const string INTERESTCLASSRATEDIVISORCDTYPEANNUMRATE = "ANNUMRATE";
                public const string INTERESTCLASSRATEDIVISORCDTYPEMONTHLYRATE = "MONTHLYRATE";
                public const string INTERESTCLASSRATEDIVISORCDTYPEDAILYRATE = "DAILYRATE";


            }

            public static class InterestClassParameter
            {
                public const string INTERESTCLASSSEQ = "seq_interestclassid";



            }
        }

        public static class User_UserType
        {
            public const string UserAdmin = "ADM";
            public const string UserCustomer = "USER";
        }

        //public static class User_Source
        //{
        //    public const string UserBO = "BO";
        //    public const string UserAPI = "API";
        //    public const string UserAdmin = "ADM";
        //    public const string UserSystem = "SYS";
        //    public const string UserCustomer = "CU";
        //    public const string UserAE = "AE";
        //    public const string UserStreamServer = "SV";
        //    public const string UserOnline = "TO";
        //}

        public static class User_Status
        {
            public const string Active = "A";
            public const string PendingVerify = "P";
            public const string InActive = "I";
        }

        public static class Title
        {
            public const string NhanVien = "OF";
            public const string ChuyenVien = "EX";
            public const string ChuyenVienCaoCao = "HEX";
            public const string PhoPhong = "VCO";
            public const string TruongPhong = "CO";
            public const string GiamDoc = "DR";
            public const string GiamDocKhoi = "SDR";
        }

        public static class User_Position
        {
            public const string DichVuKhachHang = "CS";
            public const string LuuKy = "DP";
            public const string DichVuTaiChinh = "FS";
            public const string VanHanhSanPham = "PO";
            public const string KiemSoatNghiepVu = "BC";
            public const string NghiepVuVanHanh = "OP";
            public const string QuanTriMoiGioiVaKhachHang = "ACM";
            public const string ChamSocKhachHang = "CA";
            public const string VanHanhIT = "IT";
        }

        public static class Location_LocationType
        {
            public const string VSD = "VSD";
            public const string CUSTODIAN = "CUSTODIAN";
        }

        public static class Location_ScriptOptionType
        {
            public const string CashOnly = "C";
            public const string ReinvestOnly = "R";
        }
        public static class BranchType
        {
            public const string Branch = "B";
            public const string LogicalBranch = "LB";
            public const string All = "A";
            public const string Department = "D";
            public const string BranchGroup = "BG";
        }

        public static class RoleInputApprovalLimit_Type
        {
            public const string Input = "I";
            public const string Approval = "A";
        }

        public static class Company_ProductParameter
        {
            public const string GEN = "GEN";
            public const string EQT = "EQT";
            public const string FOS = "FOS";
        }

        public static class FeeClass_FeeClassTypeId
        {
            public const string ServiceFee = "S";
            public const string TradingFee = "T";
        }

        public static class UserInputApprovalLimit_ParameterId
        {
            public const string CAN_MAKE_DEPOSITIM_NO_CHECKING_BALANCE = "CAN_MAKE_DEPOSITIM_NO_CHECKING_BALANCE";
            public const string CAN_APPROVE_DEPOSIT_IM_NO_CHECKING_BALANCE = "CAN_APPROVE_DEPOSIT_IM_NO_CHECKING_BALANCE";
            public const string DEPOSIT_IM_LIMIT = "DEPOSIT_IM_LIMIT";
            public const string WITHDRAW_IM_LIMIT = "WITHDRAW_IM_LIMIT";
            public const string EXTRACREDITMAINTENANCE_LIMIT = "EXTRA_CREDIT_MAINTENANCE_LIMIT";
            public const string APPROVAL_LIMIT_FOR_DEPOSIT_IM = "APPROVAL_LIMIT_FOR_DEPOSIT_IM";
            public const string APPROVAL_LIMIT_FOR_WITHDRAW_IM = "APPROVAL_LIMIT_FOR_WITHDRAW_IM";
            public const string APPROVAL_LIMIT_FOR_EXTRA_CREDIT_MAINTENANCE = "APPROVAL_LIMIT_FOR_EXTRA_CREDIT_MAINTENANCE";
            public const string APPROVAL_LIMIT_FOR_CASHDEPOSIT = "APPROVAL_LIMIT_FOR_CASH_DEPOSIT";

            // Tham số check hạn mức giao dịch
            public const string DEPOSIT_STDL_LIMIT = "DEPOSIT_STDL_LIMIT";
            public const string APPROVAL_LIMIT_FOR_DEPOSIT_STDL = "APPROVAL_LIMIT_FOR_DEPOSIT_STDL";
            public const string APPROVAL_LIMIT_FOR_CASH_HOLD = "APPROVAL_LIMIT_FOR_CASH_HOLD";
            public const string APPROVAL_LIMIT_FOR_CASH_RELEASE = "APPROVAL_LIMIT_FOR_CASH_RELEASE";
            //
            public const string APPROVAL_LIMIT_FOR_CASH_WITHDRAW = "APPROVAL_LIMIT_FOR_CASH_WITHDRAW";
            public const string MAKER_LIMIT_FOR_CASH_WITHDRAW = "MAKER_LIMIT_FOR_CASH_WITHDRAW";
            public const string INPUT_LIMIT_FOR_CASH_DEPOSIT = "INPUT_LIMIT_FOR_CASH_DEPOSIT";
            public const string CAN_MAKE_CASH_WITHDRAW_NO_CHECKING_BALANCE = "CAN_MAKE_CASH_WITHDRAW_NO_CHECKING_BALANCE";
            public const string CAN_INPUT_CASH_WITHDRAWAL_GREATER_THAN_MAX_WITH_BAL_FOR_NON_MARGIN_ACC = "CAN_INPUT_CASH_WITHDRAWAL_GREATER_THAN_MAX_WITH_BAL_FOR_NON_MARGIN_ACC";

            public const string CAN_APPROVE_CASH_WITHDRAWAL = "CAN_APPROVE_CASH_WITHDRAWAL";
            public const string CAN_INPUT_CASH_WITHDRAWAL_GREATER_THAN_AVAIL_BAL_FOR_DER_ACC = "CAN_INPUT_CASH_WITHDRAWAL_GREATER_THAN_AVAIL_BAL_FOR_DER_ACC";
            public const string CAN_APPROVE_CASH_WITHDRAWAL_GREATER_THAN_AVAIL_BAL_FOR_DER_ACC = "CAN_APPROVE_CASH_WITHDRAWAL_GREATER_THAN_AVAIL_BAL_FOR_DER_ACC";
            public const string CAN_INSTALL_OVERRIDE_CALCULATION_METHOD_FOR_FOREIGN_INSTITUTIONAL_WITH_VIETNAM_NATIONALITY = "CAN_INSTALL_OVERRIDE_CALCULATION_METHOD_FOR_FOREIGN_INSTITUTIONAL_WITH_VIETNAM_NATIONALITY";
        }

        public static class CompanyParameter_ParameterId
        {
            public const string DepositIM_AutoApproval_Limit = "Auto Approve deposit Cash Limit IM";
            public const string WithdrawIM_AutoApproval_Limit = "Auto Approve Withdraw Cash Limit IM";
            public const string PROHIBIT_DEPOSIT_IM = "PROHIBIT_DEPOSIT_IM";
            public const string PROHIBIT_WITHDRAW_IM = "PROHIBIT_WITHDRAW_IM";
            public const string PROHIBIT_CASH_DEPOSIT = "PROHIBIT_CASH_DEPOSIT";
            public const string PROHIBIT_CASH_WITHDRAW = "PROHIBIT_CASH_WITHDRAW";


            //
            public const string VTB_HOUSE_BANK_ACCOUNT = "VTB House Bank Account";
            public const string VTB_HOUSE_MARGIN_BANK_ACCOUNT = "VTB House Margin Bank Account";
            public const string VTB_CLIENT_BANK_ACCOUNT = "VTB Client Bank Account";
            public const string VTB_CLIENT_MARGIN_BANK_ACCOUNT = "VTB Client Margin Bank Account";
            //
            public const string VSD_HOUSE_MARGIN_BANK_ACCOUNT = "VSD House Margin Bank Account (Alias)";
            public const string VSD_CLIENT_MARGIN_BANK_ACCOUNT = "VSD Client Margin Bank Account (Alias)";
            public const string VSD_CLEARING_MARGIN_BANK_ACCOUNT = "VSD Clearing Member Bank Account (Alias)";


            public const string VTB_SETTLEMENT_BANK_ACCOUNT = "VTB Settlement Bank Account";
            public const string VTB_CLEARING_MEMBER_BANK_ACCOUNT = "VTB Clearing Member Bank Account";

            public const string CashDeposit_AutoApproval_Limit = "Bank cash limit for auto approve";
            public const string CUTOFTIME_FOR_OCT = "Cut-off-time for OCT (FROM hh:mm TO hh:mm)";
            public const string CUTOFTIME_FOR_OCT_BANK_ACCOUNT_FOR_TRANSACTION_AFTER_COT = "Cut-off-time for OCT - Bank Account ID for OCT transaction after cut-off-time";
            public const string DEFAULT_CITAD_BANK_ACCOUNT = "Default CITAD Bank Account";
            public const string DEFAULT_NAPAS_BANK_ACCOUNT = "Default NAPAS Bank Account";
            public const string SSI_BANK_GW_NAPAS_TRANSFER_LITMIT_FOR_CMVT = "SSI Banking Gateway - NAPAS transfer limit for Cash Movement";
            public const string AUTO_APPROVAL_LIMIT_FOR_OCT = "Auto approval limit For OCT";
            public const string INPUT_LIMIT_FOR_CASH_DEPOSIT = "INPUT_LIMIT_FOR_CASH_DEPOSIT";
            public const string DEFAULT_VALUE_OF_DAILY_TRANSFER_LIMIT = "Default value of Daily Transfer Limit";
            public const string ALLOW_NONREGISTER_TRANSFER = "Allow nonregister transfer";
            public const string MAXIMUM_LIMIT_PER_TRANSACTION = "Maximum limit per transaction";
            public const string CASH_MOV_AUTO_APPROVAL_LIMIT = "CASH_MOV_AUTO_APPROVAL_LIMIT";
            public const string ACCOUNT_MASTER_CALCULATION_METHOD_FOR_TAX_RELATED_FEE_FOR_FOREIGN_INSTITUTIONAL_WITH_VIETNAM_NATIONALITY = "Account Master - Calculation method for tax related fee for Foreign Institutional with Vietnam Nationality";
        }

        public static class InterestClass_InterestTypeId
        {
            public const string DebitInterestSSI = "DISSI";
            public const string CrebitInterestSSI = "CISSI";
            public const string CrebitInterestVSD = "CIVSD";

        }


        public static class InterestClass_ProductClass
        {
            public const string FOS = "FOS";
            public const string GENERAL = "GENERAL";
            public const string cdTypeForCalculateBy = "FEE_CALCULATEBY";


        }
        public static class FinancialClassUnderlyingTypeId
        {
            public const string SSI = "SSI";
            public const string VSD = "VSD";

        }
        /// <summary>
        /// Giá trị map với product group id
        /// </summary>
        public static class ProductGroup
        {
            /// <summary>
            /// Chứng khoán cơ sở
            /// </summary>
            public const string EQT = "EQT";
            /// <summary>
            /// Chứng khoán phái sinh
            /// </summary>
            public const string FOS = "FOS";
        }

        public static class TransactionCodeTypeId
        {
            public const string Account_Instrument = "I";
            public const string Account_Cash = "C";
        }

        public static class TransactionCatalogId
        {
            public const string Instrument_Deposit = "ID";
        }

        public static class ExportType
        {
            public const string PDF = "pdf";
            public const string Excel = "excel";
            public const string HTML = "html";

        }
    }
}
