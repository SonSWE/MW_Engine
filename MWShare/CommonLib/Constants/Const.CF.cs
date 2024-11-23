using static CommonLib.Constants.ErrorCodes;
using static CommonLib.Constants.ErrorCodes.SA;

namespace CommonLib.Constants
{
    public static partial class Const
    {
        public static class CF_Status
        {
            public const string Pending = "N";
            public const string Active = "A";
            public const string Block = "B";
            public const string Closed = "C";
            public const string Expired = "E";
            public const string Rejected = "R";
            public const string Cancelled = "X";
            public const string PendingClose = "S";
            public const string Deleted = "D";
        }
        public static class CF_IdType
        {
            /// <summary>
            /// Giấy DKKD
            /// </summary>
            public const string BussinessId = "BID";
            /// <summary>
            /// Can cuoc cong dan
            /// </summary>
            public const string CitizenId = "CID";
            /// <summary>
            /// 
            /// </summary>
            public const string SocialId = "SID";
            /// <summary>
            /// Hộ chiếu
            /// </summary>
            public const string Passport = "PAT";
            /// Khac
            /// </summary>
            public const string OtherId = "OID";
            /// <summary>
            /// Cơ quan chính phủ
            /// </summary>
            public const string Gov = "GOV";
            /// <summary>
            /// Căn cước (new)
            /// </summary>
            public const string Citizen = "CIN";
            public static bool CheckPassport(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case Passport:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckCitizenId(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case CitizenId:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckSocialId(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case SocialId:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public static class CF_ResidentType
        {
            public const string Yes = "001";
            public const string No = "002";
            public static bool CheckYes(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                return value switch
                {
                    Yes => true,
                    _ => false,
                };
            }
        }
        public static class RegistrationType
        {
            public const string CaNhanNuocNgoai = "F";
            public const string ToChucNuocNgoai = "E";
            public const string ToChucTrongNuoc = "O";
            public const string CaNhanTrongNuoc = "C";

            //Bỏ
            public const string TuDoanhNuocNgoai = "B";
            public const string TuDoanhTrongNuoc = "P";
            public const string QuanLyCoDongOTC = "T";
            public const string CongTyQuanLyQuy = "D";
            public static bool CheckCongTyQuanLyQuy(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;
                switch (value)
                {
                    case CongTyQuanLyQuy:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckTuDoanh(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case TuDoanhNuocNgoai:
                    case TuDoanhTrongNuoc:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckNuocNgoai(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case TuDoanhNuocNgoai:
                    case CaNhanNuocNgoai:
                    case ToChucNuocNgoai:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckCaNhan(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case CaNhanNuocNgoai:
                    case CaNhanTrongNuoc:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckToChuc(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case ToChucTrongNuoc:
                    case ToChucNuocNgoai:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckToChucTrongNuoc(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case ToChucTrongNuoc:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckTrongNuoc(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case CaNhanTrongNuoc:
                    case ToChucTrongNuoc:
                        return true;
                    default:
                        return false;
                }
            }
        }
        public static class CF_ReferType
        {
            public const string Aei = "AEI";
            public const string Frn = "FRN";
            public const string Ssi = "SSI";

            public static bool CheckRunner(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case Frn:
                        return true;
                    default:
                        return false;
                }
            }

        }
        public static class CF_Country
        {
            public const string VietNam = "VNM";


            public static bool CheckVietNam(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case VietNam:
                        return true;
                    default:
                        return false;
                }
            }

        }

        public static class CF_Nationality
        {
            public const string VietNam = "VNM";
            public const string ToChucNNTaiVietNam = "ZZZ";

            public static bool CheckVietNam(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                return value switch
                {
                    VietNam => true,
                    _ => false,
                };
            }

            public static bool CheckToChucNNTaiVietNam(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                return value switch
                {
                    ToChucNNTaiVietNam => true,
                    _ => false,
                };
            }
        }

        public static class CF_Manty
        {
            public const string NormalContract = "1";
            public const string MarginContract = "6";
            public const string DerivativeContract = "8";
        }

        public static class CF_AccountType
        {
            public const string Normal = "1";
            public const string Margin = "6";
            public const string Derivative = "8";
        }

        public static class CF_AccountStatus
        {
            public const string Active = "A";
            public const string InActive = "I";
            public const string Suspend = "S";
            public const string Closed = "C";

            public static bool IsSuspend(string accountStatus)
            {
                switch (accountStatus)
                {
                    case Suspend:
                        return true;
                    default:
                        return false;
                }
            }

            public static bool IsClosed(string accountStatus)
            {
                switch (accountStatus)
                {
                    case Closed:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public static class CF_AuthType
        {
            public const string Customer = "CF";
            public const string AfAccount = "AF";
        }

        public static class CF_Position
        {
            public const string BanGiamDoc = "001";
            public const string HoiDongQuanTri = "002";
            public const string Khac = "000";
        }

        public static class CF_CfDocument_DataType
        {
            // Khách hàng
            public const string ChuKy = "001";
            public const string FileHopDongCS = "002";
            public const string FileHopDongPS = "003";
            public const string GiayChungNhanNDTChuyenNghiep = "004";
            public const string ChungTu = "005";
            public const string ChuKyNguoiDaiDien = "006";
            public const string ChuKyUyQuyen = "007";
            public const string ChukyConDau = "010";

            // Hợp đồng, Tài khoản
            public const string ChuKyUyQuyenHopDong = "008";
            public const string ChungTuHopDong = "009";

            public const string Khac = "999";
        }

        public static class CF_CfAddress_AddType
        {
            public const string Address = "ADD";
            public const string Tel = "TEL";
            public const string Email = "EML";
            public const string Fax = "FAX";
            public static bool CheckAddress(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case Address:
                        return true;
                    default:
                        return false;
                }
            }
            public static bool CheckTel(string value)
            {
                if (string.IsNullOrEmpty(value)) return false;

                switch (value)
                {
                    case Tel:
                        return true;
                    default:
                        return false;
                }
            }

        }

        public static class CF_CfAddress_InfoType
        {
            public const string Home = "HOM";
            public const string Tep = "TEP";
            public const string Ofc = "OFC";
        }

        public static class CF_CfAddress_DataType
        {
            public const string Customer = "CF";
            public const string AfAccount = "AF";
        }

        public static class CF_DataType
        {
            public const string Customer = "CUS";
            public const string Account = "ACC";

            public static bool IsCustomer(string dataType)
            {
                return dataType switch
                {
                    Customer => true,
                    _ => false,
                };
            }

            public static bool IsAccount(string dataType)
            {
                return dataType switch
                {
                    Account => true,
                    _ => false,
                };
            }
        }

        public static class CF_BrokerRelation_DataType
        {
            public const string Customer = "CF";
            public const string AfAccount = "AF";
        }

        public static class CF_CfBankAccount_DataType
        {
            public const string Customer = "CF";
            public const string AfAccount = "AF";
        }

        public static class CF_BatchId
        {
            public const string UMCAccount = "0014";
        }

        public static class CF_CfNotification_DataType
        {
            public const string Customer = "CF";
            public const string AfAccount = "AF";
        }

        public static class CF_CfNotification_Channel
        {
            public const string Sms = "SMS";
            public const string Email = "EML";
        }

        public static class CF_CfAuthDocument_DataType
        {
            public const string Customer = "CF";
            public const string AfAccount = "AF";
        }

        public static class CF_CustodianAccountType
        {
            /// <summary>
            /// Loại 1: Tiền, Chứng tại CTCK 
            /// </summary>
            public const string TienChungTaiCTCK = "TCI";
            /// <summary>
            /// Loại 2: (MapBank) Tiền tại Ngân hàng lưu ký, Chứng tại CTCK
            /// </summary>
            public const string TienTaiBankChungTaiCTCK = "TCO";
            /// <summary>
            /// Loại 3: (Custodian) Tiền, Chứng tại Ngân hàng lưu ký
            /// </summary>
            public const string TienChungTaiBank = "TOO";
        }

        public static class CF_CfBankAccount_Status
        {
            public const string Active = "A";
            public const string Deactive = "D";
        }

        public static class CF_Expiredsts
        {
            public const string Pending = "N";
            public const string Active = "A";
            public const string Expired = "E";

        }

        public static class CF_AfInvesmentTrust_Status
        {
            public const string Active = "A";
            public const string Expired = "E";

        }

        public static class CF_CustomerAccountType
        {
            public const string TuDoanh = "VSDSSIXX.P";
            public const string Moigioi_TrongNuoc = "VSDSSIXX.C";
            public const string Moigioi_NuocNgoai = "VSDSSIXX.F";
            public const string Beneficiary = "VSDSSIXX.R";
        }

        public static class CF_RemittanceInformation_AccType
        {
            public const string TuDoanh = "P";
            public const string Moigioi_TrongNuoc = "C";
            public const string Moigioi_NuocNgoai = "F";
        }

        public static class Contact_AddType
        {
            public const string DiaChi = "ADD";
            public const string Email = "EML";
            public const string Fax = "FAX";
            public const string DienThoai = "TEL";
        }

        public static class Contact_InfoType
        {
            public const string DiaChiHoaDon = "ARB";
            public const string DiaChiThuongTru = "HOM";
            public const string DienThoaiCoDinh = "HTL";
            public const string DienThoaiDiDong = "MTL";
            public const string DiaChiVanPhong = "OFC";
            public const string DienThoaiVanPhong = "OFT";
            public const string DiaChiLienLac = "TEP";
        }

        //public static class CF
        //{
        //    //
        //    public static class AuthenType
        //    {
        //        public const string Pin = "P";
        //        public const string SmsOTP = "S";
        //        public const string OTP = "A";
        //        public const string CA = "CA";
        //        public const string Grid = "GR";
        //    }

        //    //
        //    public static class VSDAct
        //    {
        //        public const string Active = "A";
        //        public const string New = "N";
        //        public const string Reject = "R";
        //    }

        //    //
        //    public static class DEStatus
        //    {
        //        public const string New = "N";
        //        public const string Pending = "P";
        //        public const string VSDAllowed = "D";
        //        public const string Rejected = "R";
        //        public const string Active = "A";
        //        public const string Block = "B";
        //        public const string Suppend = "S";
        //        public const string Closed = "C";
        //    }

        //    //
        //    public static class TEStatus
        //    {
        //        public const string New = "N";
        //        public const string Pending = "P";
        //        public const string VSDAllowed = "D";
        //        public const string Rejected = "R";
        //        public const string Active = "A";
        //        public const string Block = "B";
        //        public const string Suppend = "S";
        //        public const string Closed = "C";
        //    }

        //    //
        //    public static class CustType
        //    {
        //        public const string CaNhan = "CN";
        //        public const string ToChuc = "TC";
        //    }

        //    //
        //    public static class GrInvestor
        //    {
        //        public const string TrongNuoc = "TN";
        //        public const string NuocNgoai = "NN";
        //    }

        //    //
        //    public static class TradingType
        //    {
        //        public const string TuGiaoDich = "NM";
        //        public const string CoMoiGioi = "BR";
        //    }

        //    //
        //    public static class CustodyType
        //    {
        //        public const string LuuKyTaiCongTy = "001";
        //        public const string LuuKyTaiNganHangLuuKy = "002";
        //        public const string QuyUyThac = "003";
        //    }

        //    // 
        //    public static class Resident
        //    {
        //        public const string ThuongTru = "T";
        //        public const string TamTru = "N";
        //        public const string KT3 = "KT3";
        //        public const string Khac = "O";
        //    }

        //    // 
        //    public static class CFClass
        //    {
        //        public const string NDTChuyenNghiep = "001";
        //        public const string CaNhan = "002";
        //        public const string Khac = "";
        //    }

        //    // 
        //    public static class Staff
        //    {
        //        public const string ThongThuong = "001";
        //        public const string ThanhVienCTCK = "002";
        //        public const string CoDongLon = "003";
        //        public const string Khac = "000";
        //    }

        //    //
        //    public static class BusinessType
        //    {
        //        public const string CongTyCoPhan = "001";
        //        public const string DoanhNghiepNhaNuoc = "002";
        //        public const string Khac = "000";
        //    }

        //    //
        //    public static class InvestType
        //    {
        //        public const string DeuDan = "C";
        //        public const string NganHan = "S";
        //        public const string DaiHan = "L";
        //        public const string Khac = "O";
        //    }

        //    //
        //    public static class ExperienceType
        //    {
        //        public const string Tot = "G";
        //        public const string RatTot = "E";
        //        public const string MoiDauTu = "N";
        //        public const string Khac = "O";
        //    }

        //    //
        //    public static class OpnVia
        //    {
        //        public const string Offline = "1";
        //        public const string Ekyc = "2";
        //        public const string Online = "3";
        //        public const string Khac = "4";
        //    }
        //}

        public static class VsdStatus
        {
            public const string XX_OPEN_ACC_PENDING = "XX_OPEN_ACC_PENDING";
            public const string XX_OPEN_ACC_SENT = "XX_OPEN_ACC_SENT";
            public const string XX_OPEN_ACC_DONE = "XX_OPEN_ACC_DONE";
            public const string XX_OPEN_ACC_ERROR = "XX_OPEN_ACC_ERROR";
            public const string HN_OPEN_ACC_PENDING = "01_OPEN_ACC_PENDING";
            public const string HN_OPEN_ACC_SENT = "01_OPEN_ACC_SENT";
            public const string HN_OPEN_ACC_DONE = "01_OPEN_ACC_DONE";
            public const string HN_OPEN_ACC_ERROR = "01_OPEN_ACC_ERROR";
            public const string HCM_OPEN_ACC_PENDING = "02_OPEN_ACC_PENDING";
            public const string HCM_OPEN_ACC_SENT = "02_OPEN_ACC_SENT";
            public const string HCM_OPEN_ACC_DONE = "02_OPEN_ACC_DONE";
            public const string HCM_OPEN_ACC_ERROR = "02_OPEN_ACC_ERROR";
            public const string DER_OPEN_ACC_PENDING = "06_OPEN_ACC_PENDING";
            public const string DER_OPEN_ACC_SENT = "06_OPEN_ACC_SENT";
            public const string DER_OPEN_ACC_DONE = "06_OPEN_ACC_DONE";
            public const string DER_OPEN_ACC_ERROR = "06_OPEN_ACC_ERROR";

            public const string XX_CLOSE_ACC_PENDING = "XX_CLOSE_ACC_PENDING";
            public const string XX_CLOSE_ACC_SENT = "XX_CLOSE_ACC_SENT";
            public const string XX_CLOSE_ACC_DONE = "XX_CLOSE_ACC_DONE";
            public const string XX_CLOSE_ACC_ERROR = "XX_CLOSE_ACC_ERROR";
            public const string HN_CLOSE_ACC_PENDING = "01_CLOSE_ACC_PENDING";
            public const string HN_CLOSE_ACC_SENT = "01_CLOSE_ACC_SENT";
            public const string HN_CLOSE_ACC_DONE = "01_CLOSE_ACC_DONE";
            public const string HN_CLOSE_ACC_ERROR = "01_CLOSE_ACC_ERROR";
            public const string HCM_CLOSE_ACC_PENDING = "02_CLOSE_ACC_PENDING";
            public const string HCM_CLOSE_ACC_SENT = "02_CLOSE_ACC_SENT";
            public const string HCM_CLOSE_ACC_DONE = "02_CLOSE_ACC_DONE";
            public const string HCM_CLOSE_ACC_ERROR = "02_CLOSE_ACC_ERROR";
            public const string DER_CLOSE_ACC_PENDING = "06_CLOSE_ACC_PENDING";
            public const string DER_CLOSE_ACC_SENT = "06_CLOSE_ACC_SENT";
            public const string DER_CLOSE_ACC_DONE = "06_CLOSE_ACC_DONE";
            public const string DER_CLOSE_ACC_ERROR = "06_CLOSE_ACC_ERROR";

            public static bool IsOpenAccPending(string vsdStatus)
            {
                if (string.IsNullOrWhiteSpace(vsdStatus))
                {
                    return false;
                }

                switch (vsdStatus)
                {
                    case XX_OPEN_ACC_PENDING:
                    case HN_OPEN_ACC_PENDING:
                    case HCM_OPEN_ACC_PENDING:
                    case DER_OPEN_ACC_PENDING:
                        return true;
                    default:
                        return false;
                }
            }

            public static bool IsCloseAccPending(string vsdStatus)
            {
                if (string.IsNullOrWhiteSpace(vsdStatus))
                {
                    return false;
                }

                switch (vsdStatus)
                {
                    case XX_CLOSE_ACC_PENDING:
                    case HN_CLOSE_ACC_PENDING:
                    case HCM_CLOSE_ACC_PENDING:
                    case DER_CLOSE_ACC_PENDING:
                        return true;
                    default:
                        return false;
                }
            }

            public static bool IsDerStatus(string vsdStatus)
            {
                if (string.IsNullOrWhiteSpace(vsdStatus))
                {
                    return false;
                }

                switch (vsdStatus)
                {
                    case DER_OPEN_ACC_PENDING:
                    case DER_OPEN_ACC_SENT:
                    case DER_OPEN_ACC_DONE:
                    case DER_OPEN_ACC_ERROR:
                    case DER_CLOSE_ACC_PENDING:
                    case DER_CLOSE_ACC_SENT:
                    case DER_CLOSE_ACC_DONE:
                    case DER_CLOSE_ACC_ERROR:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public static class BicCode
        {
            public const string HN = "01";
            public const string HCM = "02";
            public const string DER = "06";
        }

        public static class CF_Notification_RecipientType
        {
            public const string ACCOUNT = "ACCOUNT";
            public const string REPORT = "REPORT";
            public const string USER = "USER";
            public const string BATCH = "BATCH";
            public const string AE = "AE";
        }

        public static class CF_Language
        {
            public const string EN = "EN";
            public const string VN = "VN";
        }

        public static class CF_AccountParameter_TransferLimited
        {
            public const string SameBankName_Registered = "1"; //Chuyển khoản ngân hàng cùng tên có đăng ký trước
            public const string OtherBankName_Registered = "2"; //Chuyển khoản ngân hàng khác tên có đăng ký trước
            public const string InternalTransfer_SameName = "3"; //Chuyển khoản nội bộ cùng tên
            public const string InternalTransfer_OtherName_Registered = "4"; //Chuyển khoản noi bộ khác tên có đăng ký trước
        }

        public static class InstitutionTypeId
        {
            public const string DOMESTIC_FUND_ASSET_MANAGEMENT_COMPANY = "DOMESTIC_FUND_ASSET_MANAGEMENT_COMPANY";
            public const string FOREIGN_FUND_ASSET_MANAGEMENT_COMPANY = "FOREIGN_FUND_ASSET_MANAGEMENT_COMPANY";

            public const string DOMESTIC_MUTUAL_FUND_OPEN_ENDED_FUND = "DOMESTIC_MUTUAL_FUND_OPEN_ENDED_FUND";
            public const string FOREIGN_MUTUAL_FUND_OPEN_ENDED_FUND = "FOREIGN_MUTUAL_FUND_OPEN_ENDED_FUND";

            public const string PORTFOLIO = "PORTFOLIO";
        }

        public static class AccountStatus4FO
        {
            public const string Normal = "Normal";
            public const string NoBuy = "NoBuy";
            public const string NoSell = "NoSell";
            public const string NoOpenPos = "NoOpenPos";
            public const string NoTrade = "NoTrade";
            public const string VsdSuspendAcc = "VsdSuspendAcc";
            public const string VsdSuspendInst = "VsdSuspendInst";
            public const string Closed = "Closed";
            public const string Suspend = "Suspend";
            public const string NoInternetTrade = "NoInternetTrade";
            public const string NoCashWithdrawOnline = "NoCashWithdrawOnline";
            public const string NoCashWithdraw = "NoCashWithdraw";
            public const string NoCashDeposit = "NoCashDeposit";
            public const string NoInstrumentDeposit = "NoInstrumentDeposit";
            public const string NoInstrumentWithdraw = "NoInstrumentWithdraw";
            public const string NoDepositIM = "NoDepositIM";
            public const string NoWithdrawIM = "NoWithdrawIM";
        }

        public static class CF_ClearingFlag
        {

        }

        public static class CF_RegistrationType_API
        {
            public const string CaNhanTrongNuoc = "1";
            public const string CaNhanNuocNgoai = "2";
            public const string ToChucTrongNuoc = "3";
            public const string ToChucNuocNgoai = "4";
        }

        public static class CF_IdType_API
        {
            public const string IdentityCard = "1";
            public const string CitizenId = "2";
            public const string CitizenIdNew = "3";
            public const string BusinessRegistrationCertificate = "4";
            public const string OtherId = "5";
            public const string Passport = "6";
            public const string Government = "7";
        }

        public static class CF_Gender_API
        {
            public const string Male = "M";
            public const string Female = "F";
            public const string Other = "O";
        }

        public static class CF_ClearingFlag_API
        {
            public const string Clearing = "1"; //Bù trừ trực tiếp
            public const string Liquidation = "2"; //Bù trừ chung
        }

        public static class ClearingFlag
        {
            public const string Clearing = "D"; //Bù trừ trực tiếp
            public const string Liquidation = "G"; //Bù trừ chung
        }

        public static class CF_AccountTypeId_API
        {
            public const string Derivative = "6";
            public const string DerivativePortfolio = "7";
        }

        public static class CF_InterfaceTypeId_API
        {
            public const string OnlineTransfer = "3";
            public const string TransferToFIIAByBank = "4";
        }

        public static class CF_OperatorAccount
        {
            public const string SignacctOrAccountant = "SIGNACCTORACCOUTANT";
            public const string SignacctAndAccountant = "SIGNACCTANDACCOUTANT";
        }

        public static class CF_OperatorAccount_API
        {
            public const string SignacctOrAccountant = "1";
            public const string SignacctAndAccountant = "2";
        }

        public static class CF_Representative_IdType_API
        {
            public const string IdentityCard = "1";
            public const string CitizenId = "2";
            public const string CitizenIdNew = "3";
            public const string OtherId = "4";
            public const string Passport = "5";
        }

        public static class ProfessionalInvestorType
        {
            public const string ASP = "ASP"; //Danh mục chứng khoán bình quân >= 2 tỷ đồng
            public const string CE = "CE"; //Có chứng chỉ hành nghề
            public const string CO = "CO"; //Công ty có VĐL >= 100 tỷ
            public const string FI = "FI"; //Tổ chức tài chính
            public const string SP = "SP"; //Danh mục chứng khoán >= 2 tỷ
            public const string SR = "SR"; //Tổ chức niêm yết/ đăng ký giao dịch
            public const string TAX = "TAX"; //Thu nhập chịu thuế >= 1 tỷ
        }

        public static class CF_ProfessionalInvestorType_API
        {
            public const string FI = "1"; //Tổ chức tài chính
            public const string CO = "2"; //Công ty có VĐL >= 100 tỷ
            public const string SR = "3"; //Tổ chức niêm yết/ đăng ký giao dịch
            public const string CE = "4"; //Có chứng chỉ hành nghề
            public const string SP = "5"; //Danh mục chứng khoán >= 2 tỷ
            public const string TAX = "6"; //Thu nhập chịu thuế >= 1 tỷ
            public const string ASP = "7"; //Danh mục chứng khoán bình quân >= 2 tỷ đồng
        }
    }
}