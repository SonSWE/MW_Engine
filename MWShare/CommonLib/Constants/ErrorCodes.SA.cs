using System.Net;

namespace CommonLib.Constants
{
    /// <summary>
    /// Ma loi phan he SA: -10_XX_YYY;
    /// </summary>
    public static partial class ErrorCodes
    {
        public static class SA
        {
            // Ma loi phan he SA: -10_XX_YYY;
            // XX: 2 so the hien bang
            //		+ 00: Branch                 - Thông tin chi nhánh
            //		+ 01: Department             - Thông tin phòng ban
            //		+ 02: Bank                   - Thông tin ngân hàng
            //		+ 03: DepositoryMember       - Thông tin thành viên lưu ký
            //		+ 04: SACareBy               - Nhóm quản lý khách hàng
            //		+ 05: Issuer                 - Thông tin TCPH
            //		+ 06: Securities             - Thông tin Chứng khoán
            //		+ 07: BankBranch             - Thông tin Chi nhánh ngân hàng
            //		+ 08: FeeunType              - Thông tin về biểu phí giao dịch trong hệ thống
            //		+ 09: FeeunDetail              
            //		+ 10: FeeDetail              
            //		+ 11: SAUser              
            //		+ 12: SAGroupFunction              
            //		+ 13: SAGroupUser              
            //		+ 14: SAUserFunction              
            //		+ 15: Firm              
            //		+ 16: Trader              
            //      + 17: FeeCompliance          - Phí tuân thủ
            //      + 18: FeeDetail              - Phí giao dịch
            //      + 19: FeeTier                - Phí bậc thang
            //      + 20: FeeGrp                 - Nhóm phí giao dịch
            //		+ 21: RegistrationType       - Loại khách hàng
            //      + 22: ChannelTransaction     - Kênh giao dịch
            //      + 23: TradingStepPriceTee    - Bước giá
            //      + 24: FeeDetail-Checker      - Duyệt phí giao dịch
            //      + 25: FeeGrp-Checker         - Duyệt nhóm phí
            //      + 26: ChannelTransaction-Checker    - Duyệt kênh giao dịch
            //      + 27: TradingStepPriceTee-Checker   - Duyệt bước giá
            //      + 28: FeeService             - Phí dịch vụ
            //      + 29: FeeService-Checker     - Duyệt phí dịch vụ
            //      + 30: Department-Checker     - Phòng ban checker
            //      + 31: Bank-Checker           - Ngân hàng checker
            //      + 32: BankBranch-Checker     - Chi nhánh ngân hàng checker
            //      + 34: FeeServiceGrp          - Nhóm phí dịch vụ
            //      + 35: FeeServiceGrp-CHecker  - Duyệt nhóm phí dịch vụ
            //      + 36: Branch-Checker         - Duyệt chi nhánh
            //      + 37: SysparamCountry        - Quốc gia
            //      + 38: SysparamCountry-checker  - Quốc gia checker
            //      + 39: Currency-checker       - Tiền tệ
            //      + 40: Location               - Khu vực
            //      + 41: Board
            //      + 42: TradingRule            - Kiểu giao dịch
            //      + 43: SpecialTradingGroup    - các kiểu giao dịch đặc biệt, với rule khác so với bảng giao dịch
            //      + 44: TradingTimeTable        - định nghĩa một chu trình giao dịch của theo 1 ngày giao dịch
            //      + 45: TradingSession          - định nghĩa một phiên giao dịch 
            //      + 46: BranchDeparment         - Bảng lưu Phòng ban của Chi Nhánh
            //      + 47: LogicalBranch          - Bảng lưu Logical Branch
            //      + 48: LogicalBranchBranch    - Bảng lưu Branch của Logical Branch
            //      + 49: AccountExecutive
            //      + 50: AccountExecutiveUserRole
            //      + 51: AccountExecutiveAccessibleBranch
            //      + 52: AccountExecutiveMapping
            //      + 53: AccountExecutiveMappingAccount
            //      + 54: AccountExecutiveMappingInstrument
            //      + 55: TradingAccountSubStatus
            //      + 56: Holiday
            //      + 57: Company
            //      + 58: Market
            //      + 59: ChannelDef
            //      + 61: BankAccount
            //      + 67: FeeNature
            //      + 68: InterestClass
            //      + 71: OrderCheckingGroup
            // YYY: 3 so the hien loi

            /// <summary>
            /// Department - [-10_01_YYY] - Thông tin phòng ban
            /// </summary>
            public static class Department
            {
                public const int Err_AutoId = -10_01_001;
                public const int Err_RefAutoId = -10_01_002;
                public const int Err_DpId = -10_01_003;
                public const int Err_DpCode = -10_01_004;
                public const int Err_DpName = -10_01_005;
                /// <summary>
                /// Loại phòng ban
                /// </summary>
                public const int Err_DpType = -10_01_006;
                /// <summary>
                /// Vùng miền
                /// </summary>
                public const int Err_DpZone = -10_01_007;
                public const int Err_Address = -10_01_008;
                public const int Err_Phone = -10_01_009;
                public const int Err_Fax = -10_01_010;
                public const int Err_Description = -10_01_011;
                public const int Err_RejectDes = -10_01_012;
                public const int Err_Status = -10_01_013;
                public const int Err_DpCode_Duplicate = -10_01_014;
                public const int Err_DpName_Duplicate = -10_01_015;
                public const int Err_PendingExisted = -10_01_016;
            }

            /// <summary>
            /// Bank - [-10_02_YYY] - Thông tin ngân hàng
            /// </summary>
            public static class Bank
            {
                public const int Err_AutoId = -10_02_001;
                public const int Err_RefAutoId = -10_02_002;
                public const int Err_BankId = -10_02_003;
                public const int Err_BankCode = -10_02_004;
                public const int Err_BankName = -10_02_005;
                public const int Err_ShortName = -10_02_006;
                public const int Err_Address = -10_02_007;
                public const int Err_Phone = -10_02_008;
                public const int Err_Fax = -10_02_009;
                public const int Err_Website = -10_02_010;
                public const int Err_Status = -10_02_011;
                public const int Err_Description = -10_02_012;
                public const int Err_RejectDes = -10_02_013;
                public const int Err_BankOnline = -10_02_014;
                public const int Err_RecvMoney = -10_02_015;
                public const int Err_SendMoney = -10_02_016;
                public const int Err_Con247 = -10_02_017;
                public const int Err_ConCitad = -10_02_018;

                public const int Err_BankCode_Duplicate = -10_02_019;
                public const int Err_BankName_Duplicate = -10_02_020;
                public const int Err_PendingExisted = -10_02_021;

                public const int Err_CitadCode = -10_02_022;
                public const int Err_Fiia = -10_02_023;
                public const int Err_Napas = -10_02_024;
            }

            /// <summary>
            /// DepositoryMember - [-10_03_YYY] - Thông tin thành viên lưu ký
            /// </summary>
            public static class DepositoryMember
            {
                public const int Err_AutoId = -10_03_001;
                public const int Err_RefAutoId = -10_03_002;
                public const int Err_DepositId = -10_03_003;
                public const int Err_MemCode = -10_03_004;
                public const int Err_ShortName = -10_03_005;
                public const int Err_FullName = -10_03_006;
                public const int Err_FullNameEn = -10_03_007;
                public const int Err_Address = -10_03_008;
                public const int Err_Phone = -10_03_009;
                public const int Err_Fax = -10_03_010;
                public const int Err_Represent = -10_03_011;
                public const int Err_Ceo = -10_03_012;
                public const int Err_License = -10_03_013;
                public const int Err_LicenseMember = -10_03_014;
                public const int Err_Description = -10_03_015;
                public const int Err_Status = -10_03_016;
                public const int Err_RejectDes = -10_03_017;

                public const int Err_MemCode_Duplicate = -10_03_018;
                public const int Err_ShortName_Duplicate = -10_03_019;
                public const int Err_FullName_Duplicate = -10_03_020;
                public const int Err_PendingExisted = -10_03_021;

                public const int Err_DepoType = -10_03_022;

                public const int Err_Membership = -10_03_023;
                public const int Err_MemCodeSymbol = -10_03_024;
                public const int Err_PhoneCodeSymbol = -10_03_025;

                public const int Err_Phone_Duplicate = -10_03_026;
            }

            /// <summary>
            /// SACareBy - [-10_04_YYY] - Nhóm quản lý khách hàng
            /// </summary>
            public static class SACareBy
            {
                public const int Err_AutoId = -10_04_001;
                public const int Err_RefAutoId = -10_04_002;
                public const int Err_CareById = -10_04_003;
                public const int Err_Name = -10_04_004;
                public const int Err_Code = -10_04_005;
                public const int Err_BrId = -10_04_006;
                public const int Err_IsDefault = -10_04_007;
                public const int Err_Description = -10_04_008;
                public const int Err_Status = -10_04_009;
                public const int Err_RejectDes = -10_04_010;
                public const int Err_Name_Duplicate = -10_04_011;
                public const int Err_Code_Duplicate = -10_04_012;
                public const int Err_PendingExisted = -10_04_013;
            }

            /// <summary>
            /// Issuer - [-10_05_YYY] - Thông tin TCPH
            /// </summary>
            public static class Issuer
            {
                public const int Err_AutoId = -10_05_001;
                public const int Err_RefAutoId = -10_05_002;
                public const int Err_IssuerId = -10_05_003;
                public const int Err_ShortName = -10_05_004;
                public const int Err_FullName = -10_05_005;
                public const int Err_FullNameEng = -10_05_006;
                public const int Err_OfficeName = -10_05_007;
                public const int Err_Address = -10_05_008;
                public const int Err_Phone = -10_05_009;
                public const int Err_Fax = -10_05_010;

                public const int Err_Economic = -10_05_011;
                public const int Err_BusinessType = -10_05_012;
                public const int Err_LicenseNo = -10_05_013;
                public const int Err_LicenseDate = -10_05_014;
                public const int Err_LicensePlace = -10_05_015;
                public const int Err_OperateNo = -10_05_016;
                public const int Err_OperateDate = -10_05_017;
                public const int Err_OperatePlace = -10_05_018;
                public const int Err_LegalCaptial = -10_05_019;
                public const int Err_ShareCapital = -10_05_020;

                public const int Err_MarketSize = -10_05_021;
                public const int Err_PRPerson = -10_05_022;
                public const int Err_InfoAddress = -10_05_023;
                public const int Err_Description = -10_05_024;
                public const int Err_Status = -10_05_025;
                public const int Err_RejectDes = -10_05_026;

                public const int Err_ShortName_Duplicate = -10_05_027;
                public const int Err_FullName_Duplicate = -10_05_028;
                public const int Err_FullNameEng_Duplicate = -10_05_029;
                public const int Err_OfficeName_Duplicate = -10_05_030;
                public const int Err_PendingExisted = -10_05_031;
            }

            /// <summary>
            /// Securities - [-10_06_YYY] - Thông tin Chứng khoán
            /// </summary>
            public static class Securities
            {
                public const int Err_AutoId = -10_06_001;
                public const int Err_RefAutoId = -10_06_002;
                public const int Err_SecId = -10_06_003;
                public const int Err_Symbol = -10_06_004;
                public const int Err_SecNo = -10_06_005;
                public const int Err_Name = -10_06_006;
                public const int Err_NameEng = -10_06_007;
                public const int Err_Isin = -10_06_008;
                public const int Err_IssuerId = -10_06_009;
                public const int Err_TradePlace = -10_06_010;

                public const int Err_SecType = -10_06_011;
                public const int Err_CeilingPrice = -10_06_012;
                public const int Err_FloorPrice = -10_06_013;
                public const int Err_BasicPrice = -10_06_014;
                public const int Err_OpenPrice = -10_06_015;
                public const int Err_ClosePrice = -10_06_016;
                public const int Err_MatchPrice = -10_06_017;
                public const int Err_CRoom = -10_06_018;
                public const int Err_FRoom = -10_06_019;
                public const int Err_PrevClosePrice = -10_06_020;

                //public const int Err_SplitFlag = -10_06_021;
                public const int Err_HaltFLag = -10_06_022;
                //public const int Err_Suspension = -10_06_023;
                //public const int Err_BenefitFlag = -10_06_024;
                //public const int Err_Meeting = -10_06_025;
                //public const int Err_Delist = -10_06_026;
                public const int Err_SessionId = -10_06_027;
                public const int Err_BoardCode = -10_06_028;
                public const int Err_SpecGrpCode = -10_06_029;
                public const int Err_TradingStatus = -10_06_030;

                public const int Err_ListingShare = -10_06_031;
                public const int Err_TradeUnit = -10_06_032;
                public const int Err_TradeLot = -10_06_033;
                public const int Err_Underlying = -10_06_034;
                public const int Err_CwRate = -10_06_035;
                public const int Err_CoveredWarrantType = -10_06_036;
                public const int Err_MaturityDate = -10_06_037;
                public const int Err_LastTradingDate = -10_06_038;
                public const int Err_DailySettlementPrice = -10_06_039;
                public const int Err_ExercisePrice = -10_06_040;

                public const int Err_ExerciseRatio = -10_06_041;
                public const int Err_ProductId = -10_06_042;
                public const int Err_ProductGrpId = -10_06_043;
                public const int Err_BoardEvtId = -10_06_044;
                public const int Err_SettlementPrice = -10_06_045;
                public const int Err_TradingHaltReason = -10_06_046;
                //public const int Err_OddLot = -10_06_047;
                public const int Err_Status = -10_06_048;
                public const int Err_RejectDes = -10_05_049;

                public const int Err_OddHaltFlag = -10_06_050;
                public const int Err_CaStatus = -10_06_051;

                public const int Err_ParValue = -10_06_052;

                public const int Err_Symbol_Duplicate = -10_06_053;

                public const int Err_Isin_Symbol = -10_06_054;

                public const int Err_Isin_Duplicate = -10_06_055;

                public const int Err_ExerciseRatio_Invalid = -10_06_056;
                public const int Err_CwRate_Invalid = -10_06_057;

                public const int Err_CeilingPriceREQ = -10_06_058;
                public const int Err_BasicPriceREQ = -10_06_059;
                public const int Err_FloorPriceREQ = -10_06_060;
            }


            /// <summary>
            /// BankBranch - [-10_07_YYY] - Thông tin Chi nhánh ngân hàng
            /// </summary>
            public static class BankBranch
            {
                public const int Err_AutoId = -10_07_001;
                public const int Err_RefAutoId = -10_07_002;
                public const int Err_BranchId = -10_07_003;
                public const int Err_BankId = -10_07_004;
                public const int Err_BranchCode = -10_07_005;
                public const int Err_BranchName = -10_07_006;
                public const int Err_ShortName = -10_07_007;
                public const int Err_Address = -10_07_008;
                public const int Err_Phone = -10_07_009;
                public const int Err_Fax = -10_07_010;
                public const int Err_Website = -10_07_011;
                public const int Err_Description = -10_07_012;
                public const int Err_Status = -10_07_013;
                public const int Err_RejectDes = -10_07_014;
                public const int Err_BranchCode_Duplicate = -10_07_015;
                public const int Err_BranchName_Duplicate = -10_07_016;
                public const int Err_PendingExisted = -10_07_017;

                public const int Err_CitadCode = -10_07_018;
            }

            /// <summary>
            /// FeeunType - [-10_08_YYY] - Thông tin về biểu phí giao dịch trong hệ thống
            /// </summary>
            public static class FeeunType
            {
                public const int Err_AutoId = -10_08_001;
                public const int Err_RefAutoId = -10_08_002;
                public const int Err_FeeunId = -10_08_003;
                public const int Err_FeeCode = -10_08_004;
                public const int Err_FeeName = -10_08_005;
                public const int Err_FeeTradingType = -10_08_006;
                public const int Err_CfType = -10_08_007;
                public const int Err_IsDefault = -10_08_008;

                public const int Err_FeeCode_Duplicate = -10_08_009;
                public const int Err_FeeName_Duplicate = -10_08_010;
                public const int Err_PendingExisted = -10_08_011;
                public const int Err_Status = -10_08_012;

                public const int Err_FeeunTypeDetails = -10_08_013;

            }

            /// <summary>
            /// FeeunType - [-10_09_YYY] - Thông tin chi tiết về biểu phí giao dịch trong hệ thống
            /// </summary>
            public static class FeeunDetail
            {
                public const int Err_AutoId = -10_9_001;
                public const int Err_RefAutoId = -10_09_002;
                public const int Err_FeeunDetaiId = -10_09_003;
                public const int Err_Code = -10_09_004;
                public const int Err_Name = -10_09_005;
                public const int Err_FeeunType = -10_09_006;
                public const int Err_FunidautoId = -10_09_007;
                public const int Err_CalType = -10_09_008;
                public const int Err_RuleType = -10_09_009;
                public const int Err_SecType = -10_09_010;
                public const int Err_RoundType = -10_09_011;
                public const int Err_ScaleNum = -10_09_012;
                public const int Err_FeeRate = -10_09_013;
                public const int Err_Feeatm = -10_09_014;
                public const int Err_MaxFeeRate = -10_09_015;
                public const int Err_Tax = -10_09_016;
                public const int Err_MaxVal = -10_09_017;
                public const int Err_MinVal = -10_09_018;
                public const int Err_Period = -10_09_019;
                public const int Err_PayDate = -10_09_020;
                public const int Err_FloorRate = -10_09_021;
                public const int Err_OnlineRate = -10_09_022;
                public const int Err_PhoneRate = -10_09_023;
                public const int Err_Description = -10_09_024;

                public const int Err_FeeCode_Duplicate = -10_09_025;
                public const int Err_FeeName_Duplicate = -10_09_026;
                public const int Err_PendingExisted = -10_09_027;
                public const int Err_Status = -10_09_028;
            }
            /// <summary>
            /// SAGroup - [-10_10_YYY] - Danh sách các nhóm chức năng
            /// </summary>
            public static class Err_SAGroup
            {
                public const int AutoId = -10_10_001;
                public const int RefAutoId = -10_10_002;
                public const int GrpId = -10_10_003;
                public const int GrpName = -10_10_004;
                public const int GrpCode = -10_10_005;
                //public const int UserType = -10_10_006;
                //public const int PrtGrpId = -10_10_007;
                public const int Right = -10_10_008;

                public const int Description = -10_10_009;

                public const int GrpCode_Duplicate = -10_10_010;
                public const int GrpName_Duplicate = -10_10_011;
                public const int PendingExisted = -10_10_012;
                public const int Status = -10_10_013;
                public const int RejectDes = -10_10_014;

                public const int GrpCode_Symbol = -10_10_016;

            }

            /// <summary>
            /// SAUser - [-10_11_YYY] - Thông tin về người sử dụng
            /// </summary>
            public static class Err_SAUser
            {
                public const int AutoId = -10_11_001;
                public const int RefAutoId = -10_11_002;
                //public const int GrpId = -10_11_003;
                public const int UserName = -10_11_004;
                public const int Password = -10_11_006;
                public const int PassTran = -10_11_007;
                public const int FullName = -10_11_008;

                public const int UsLev = -10_11_009;
                public const int UserType = -10_11_010;
                public const int GrpType = -10_11_011;
                public const int FirstLogin = -10_11_012;
                public const int FirstLoginDate = -10_11_013;
                public const int BeginLogin = -10_11_014;
                public const int LastLogin = -10_11_015;
                public const int CustodyCd = -10_11_016;
                public const int IpAddress = -10_11_017;
                public const int WsName = -10_11_018;
                public const int ResetPass = -10_11_019;
                public const int FailedLoginAttempts = -10_11_020;
                public const int LockTime = -10_11_021;
                public const int LoginChannel = -10_11_022;
                public const int Use2FA = -10_11_023;
                public const int CAPublicKey = -10_11_024;
                public const int Email = -10_11_025;
                public const int Phone = -10_11_026;
                public const int IssuperVision = -10_11_027;
                public const int SuperVision = -10_11_028;
                public const int Supporter = -10_11_029;
                public const int IsViewer = -10_11_030;
                public const int BrokerId = -10_11_031;
                public const int Brid = -10_11_032;
                public const int DPId = -10_11_033;
                public const int Description = -10_11_034;

                public const int UserName_Duplicate = -10_11_035;
                public const int Email_Duplicate = -10_11_036;
                public const int PendingExisted = -10_11_037;
                public const int RejectDes = -10_11_038;
                public const int Status = -10_11_039;


                public const int PasswordSize = -10_11_040;
                public const int PasswordSymbol = -10_11_041;
                public const int PasswordCompareWithPre = -10_11_042;
                public const int PasswordCompareWithOld = -10_11_043;

                public const int StatusInvalid = -10_11_044;

                public const int PasswordWrrong = -10_11_045;

                public const int Phone_Duplicate = -10_11_046;
            }
            /// <summary>
            /// SAGroupFunction - [-10_12_YYY] - Phân quyền chức năng - group
            /// </summary>
            public static class Err_SAGroupFunction
            {
                public const int GrpId = -10_12_001;
                public const int FuncId = -10_12_002;

            }
            /// <summary>
            /// SAGroupUser - [-10_13_YYY] - Phân quyền user - group
            /// </summary>
            public static class Err_SAGroupUser
            {
                public const int GrpId = -10_13_001;
                public const int UserName = -10_13_002;
                public const int ExpireDate = -10_13_003;
            }
            /// <summary>
            /// SAUserFunction - [-10_14_YYY] - Phân quyền user - function
            /// </summary>
            public static class Err_SAUserFunction
            {
                public const int UserName = -10_14_001;
                public const int FuncId = -10_14_002;
                public const int FunType = -10_14_003;
            }

            /// <summary>
            /// Firm - [-10_15_YYY] - firm
            /// </summary>
            public static class Err_Firm
            {
                public const int AutoId = -10_15_001;
                public const int MemFirmId = -10_15_002;
                public const int RefDepoAutoid = -10_15_003;
                public const int DepositId = -10_15_004;
                public const int TradePlace = -10_15_005;
                public const int MemCode = -10_15_006;
                public const int Firms = -10_15_007;
                public const int AutoMatchFlag = -10_15_008;
                public const int PutThroughFlag = -10_15_009;
                public const int Status = -10_15_010;

                public const int MemCode_Duplicate = -10_15_011;

            }
            /// <summary>
            /// Trader - [-10_16_YYY] - Phân quyền trader
            /// </summary>
            public static class Err_Trader
            {
                public const int AutoId = -10_16_001;
                public const int TraderFirmId = -10_16_002;
                public const int RefDepoAutoid = -10_16_003;
                public const int DepositId = -10_16_004;
                public const int TradePlace = -10_16_005;
                public const int MemCode = -10_16_006;
                public const int Firm = -10_16_007;
                public const int TraderId = -10_16_008;
                public const int TraderStatus = -10_16_009;
                public const int Status = -10_16_010;

                public const int TraderIdSymbol = -10_16_011;

            }
            /// <summary>
            /// FeeCompliance - [-10_17_YYY] - Phí giao dịch
            /// </summary>
            public static class Err_FeeCompliance
            {
                public const int Err_Code_Duplicate = -10_17_001;
                public const int Err_Name_Duplicate = -10_17_002;
                public const int Err_Status = -10_17_003;
                public const int Err_AutoId = -10_17_004;
                public const int Err_RefAutoId = -10_17_005;
                public const int Err_FeeId = -10_17_006;
                public const int Err_Code = -10_17_007;
                public const int Err_FeeType = -10_17_008;
                public const int Err_Name = -10_17_009;
                public const int Err_OtherLanguage = -10_17_010;
                public const int Err_AppCode = -10_17_011;
                public const int Err_UnderAsset = -10_17_012;
                public const int Err_Government = -10_17_013;
                public const int Err_SecType = -10_17_014;
                public const int Err_InvestorClass = -10_17_015;
                public const int Err_DomexeWithDraw = -10_17_016;
                public const int Err_ChargeType = -10_17_017;
                public const int Err_RuleType = -10_17_018;
                public const int Err_FeeVal = -10_17_019;
                public const int Err_RoundType = -10_17_020;
                public const int Err_ScaleNum = -10_17_021;
                public const int Err_FeeValMin = -10_17_022;
                public const int Err_FeeValMax = -10_17_023;
                public const int Err_GLChargeCode = -10_17_024;
                public const int Err_Currency = -10_17_025;
                public const int Err_IsHoldDaily = -10_17_026;
                public const int Err_FromDateToDate = -10_17_027;
                public const int Err_FeeOrg = -10_17_028;
                public const int Err_FromDate = -10_17_029;
                public const int Err_ToDate = -10_17_030;
                public const int Err_Date = -10_17_031;
                public const int Err_DayOfHold = -10_17_032;
            }
            /// <summary>
            /// FeeDetail - [-10_18_YYY] - Phí giao dịch
            /// </summary>
            public static class Err_FeeDetail
            {
                public const int Err_Code_Duplicate = -10_18_001;
                public const int Err_Name_Duplicate = -10_18_002;
                public const int Err_Status = -10_18_003;
                public const int Err_AutoId = -10_18_004;
                public const int Err_RefAutoId = -10_18_005;
                public const int Err_FeeDetailId = -10_18_006;
                public const int Err_Code = -10_18_007;
                public const int Err_Name = -10_18_008;
                public const int Err_InstrucmentCode = -10_18_009;
                public const int Err_UnderAsset = -10_18_010;
                public const int Err_FeeType = -10_18_011;
                public const int Err_Market = -10_18_012;
                public const int Err_ChannelId = -10_18_013;
                public const int Err_ChargeType = -10_18_014;
                public const int Err_RuleType = -10_18_015;
                public const int Err_SecType = -10_18_016;
                public const int Err_RoundType = -10_18_017;
                public const int Err_FeeAmt = -10_18_018;
                public const int Err_Period = -10_18_019;
                public const int Err_PayDate = -10_18_020;
                public const int Err_IsApply = -10_18_021;
                public const int Err_BranchId = -10_18_022;
                public const int Err_OtherLanguage = -10_18_023;
                public const int Err_ScaleNum = -10_18_024;
                public const int Err_FeeRate = -10_18_025;
                public const int Err_MaxVal = -10_18_026;
                public const int Err_ToDate = -10_18_027;
                public const int Err_FromDate = -10_18_028;
                public const int Err_FrToAmt = -10_18_029;
                public const int Err_FeeVr = -10_18_030;
                public const int Err_FromToDate = -10_18_031;
                public const int Err_ToDateGreaterToDay = -10_18_032;
                public const int Err_FromDateGreaterToDay = -10_18_033;
                public const int Err_DeleteFee = -10_18_034;
                public const int Err_PayDateInvalid = -10_18_035;
                public const int Err_RecordUpdate = -10_18_036;
                public const int Err_Recorđelete = -10_18_037;
                public const int Err_BuyOrSell = -10_18_038;
            }
            /// <summary>
            /// FeeTier - [-10_19_YYY] - Phí bậc thang
            /// </summary>
            public static class Err_FeeTier
            {
                public const int Err_Need = -10_19_001;
                public const int Err_FeeTierNull = -10_19_002;
                public const int Err_FrToAmt = -10_19_003;
            }
            /// <summary>
            /// FeeGrp - [-10_20_YYY] - Nhóm phí giao dịch
            /// </summary>
            public static class Err_FeeGrp
            {
                public const int Err_Code_Duplicate = -10_20_001;
                public const int Err_Name_Duplicate = -10_20_002;
                public const int Err_Status = -10_20_003;
                public const int Err_AutoId = -10_20_004;
                public const int Err_RefAutoId = -10_20_005;
                public const int Err_FeeGrpId = -10_20_006;
                public const int Err_Code = -10_20_007;
                public const int Err_Name = -10_20_008;
                public const int Err_OtherLanguage = -10_20_009;
                public const int Err_InstrucmentCode = -10_20_010;
                public const int Err_Currency = -10_20_011;
                public const int Err_RecordUpdate = -10_20_012;
                public const int Err_Recorđelete = -10_20_013;

            }
            /// <summary>
            /// RegistrationType - [-10_21_YYY] - Loại khách hàng
            /// </summary>
            public static class Err_RegistrationType
            {
                public const int AutoId = -10_21_001;
                public const int Code = -10_21_002;
                public const int Name = -10_21_003;
                public const int NameOther = -10_21_004;
                public const int CheckExpireDate = -10_21_005;

                public const int RefAutoId = -10_21_009;
                public const int Status = -10_21_010;
                public const int MemCode_Duplicate = -10_21_011;

                public const int CustomerType = -10_21_012;
                public const int Description = -10_21_013;
                public const int StatusInvalid = -10_21_014;
                public const int StatusInvalidDel = -10_21_015;

            }
            /// <summary>
            /// ChannelTransaction - [-10_22_YYY] - Kênh giao dịch
            /// </summary>
            public static class Err_ChannelTransaction
            {
                public const int Err_AutoId = -10_22_001;
                public const int Err_ChannelCode = -10_22_002;
                public const int Err_Name = -10_22_003;
                public const int Err_NameOther = -10_22_004;
                public const int Err_TaskSchedule = -10_22_005;
                public const int Err_Status = -10_22_006;
                public const int Err_ChannelCode_Duplicate = -10_22_007;
                public const int Err_MarketExist = -10_22_008;
                public const int Err_OpenTime = -10_22_009;
                public const int Err_CloseTime = -10_22_010;
                public const int Err_ChannelDetails = -10_22_011;
            }
            /// <summary>
            /// TradingStepPriceTee - [-10_23_YYY] - Bước giá
            /// </summary>
            public static class Err_TradingStepPriceTee
            {
                public const int Err_Code_Duplicate = -10_23_001;
                public const int Err_Status = -10_23_002;
                public const int Err_FromToValue = -10_23_003;
                public const int Err_RecordUpdate = -10_23_004;
                public const int Err_Recorđelete = -10_23_005;
                public const int Err_Status1 = -10_23_006;
                public const int Err_ChannelCode_Duplicate = -10_23_007;
                public const int Err_MarketExist = -10_23_008;
                public const int Err_OpenTime = -10_23_009;
                public const int Err_CloseTime = -10_23_010;

                public const int Err_FromValueToValue = -10_23_020;
            }
            /// <summary>
            /// FeeService - [-10_28_YYY] - Phí dịch vụ
            /// </summary>
            public static class Err_FeeService
            {
                public const int Err_Code_Duplicate = -10_28_001;
                public const int Err_Status = -10_28_002;
                public const int Err_FromToValue = -10_28_003;
                public const int Err_RecordUpdate = -10_28_004;
                public const int Err_Recorđelete = -10_28_005;

            }
            /// <summary>
            /// SysParam - [-10_37_YYY] - SysParamCountry
            /// </summary>
            public static class Err_SysParamCountry
            {
                public const int Err_AutoId = -10_37_001;
                public const int Err_Grp = -10_37_002;
                public const int Err_Name = -10_37_003;
                public const int Err_PValue = -10_37_004;
                public const int Err_PType = -10_37_005;
                public const int Err_Content = -10_37_006;
                public const int Err_ContentOther = -10_37_007;
                public const int Err_Status = -10_37_008;
                public const int Err_SysParam_Duplicate = -10_37_009;
                public const int Err_Description = -10_37_010;
                public const int StatusInvalid = -10_37_011;
                public const int Err_Used = -10_37_012;
            }
            /// <summary>
            /// Currency - [-10_39_YYY] - Thông tin tiền tệ
            /// </summary>

        }

        /// <summary>
        /// Branch - [-10_00_YYY] - Thông tin chi nhánh
        /// </summary>
        public static class SA_Branch
        {
            public const int Err_AutoId = -1000001;
            public const int Err_RefAutoId = -1000002;
            public const int Err_Description = -1000003;
            public const int Err_RecordStatus = -1000004;
            public const int Err_Action = -1000005;
            public const int Err_CreateBy = -1000006;
            public const int Err_CreateDate = -1000007;
            public const int Err_LastChangeBy = -1000008;
            public const int Err_LastChangeDate = -1000009;
            public const int Err_ApproveBy = -1000010;
            public const int Err_ApproveDate = -1000011;
            public const int Err_RejectNum = -1000012;
            public const int Err_RejectDes = -1000013;
            public const int Err_CancelReason = -1000014;
            public const int Err_Deleted = -1000015;
            //
            public const int Err_BranchPid = -1000016;
            public const int Err_BranchId = -1000017;
            public const int Err_Name = -1000018;
            public const int Err_NameOther = -1000019;
            public const int Err_Address1 = -1000020;
            public const int Err_Address2 = -1000021;
            public const int Err_Address3 = -1000022;
            public const int Err_Address4 = -1000023;
            public const int Err_Country = -1000024;
            public const int Err_LineOfBusiness = -1000025;
            public const int Err_PhoneNo = -1000026;
            public const int Err_FaxNumber = -1000027;
            public const int Err_DefaultAeId = -1000028;
            public const int Err_MarginLimit = -1000029;
            public const int Err_Remark = -1000030;
            public const int Err_DxCode = -1000031;
            public const int Err_DxShortName = -1000032;
            public const int Err_ManagerUserName = -1000033;
            public const int Err_ListOfDepartments = -1000034;
            public const int Err_PendingExisted = -1000035;
            public const int Err_BranchId_Existed = -1000036;
            public const int Err_ListOfDepartments_TabName = -1000037;
            public const int Err_DxCode_Existed = -1000038;
            public const int Err_DeleteDataUsedByLogicalBranch = -1000039;
            public const int Err_XoaKhiDaGanVaoUser = -1000040;
            public const int Err_XoaKhiDaGanVaoBroker = -1000041;
            public const int Err_ApproveSelfData = -1000042;
            public const int Err_CancelOtherData = -1000043;
            public const int Err_XoaPhongBanKhiDaGanVaoUser = -1000044;
            public const int Err_XoaPhongBanKhiDaGanVaoBroker = -1000045;
            public const int Err_Status = -1000046;
            //
            public const int Err_XoaKhiDaGanVaoUserAccessibleBranch = -1000047;
            public const int Err_XoaKhiDaGanVaoCustomer = -1000048;
            public const int Err_XoaKhiDaGanVaoAccount = -1000049;
            public const int Err_XoaKhiDaGanVaoCompany = -1000050;
        }

        /// <summary>
        /// Location - [-10_40_YYY] - Khu vực
        /// </summary>
        public static class SA_Location
        {
            public const int Err_AutoId = -10_40_001;
            public const int Err_RefAutoId = -10_40_002;
            public const int Err_LocationPid = -10_40_003;
            public const int Err_Name = -10_40_004;
            public const int Err_NameOther = -10_40_005;
            public const int Err_IsDX = -10_40_006;
            public const int Err_LocationType = -10_40_007;
            public const int Err_CountryId = -10_40_008;
            public const int Err_ScriptOptionType = -10_40_009;
            public const int Err_VsdCode = -10_40_010;
            public const int Err_CustodianBank = -10_40_011;
            public const int Err_AccountNo = -10_40_012;
            public const int Err_AccountName = -10_40_013;
            public const int Err_Remark = -10_40_014;
            public const int Err_Status = -10_40_015;
            public const int Err_Description = -10_40_016;
            public const int Err_RecordStatus = -10_40_017;
            public const int Err_Action = -10_40_018;
            public const int Err_RejectDes = -10_40_019;
            public const int Err_CancelReason = -10_40_020;
            public const int Err_PendingExisted = -10_40_021;
            public const int Err_LocationId = -10_40_022;
            public const int Err_LocationId_Existed = -10_40_023;
            public const int Err_ApproveSelfData = -10_40_024;
            public const int Err_CancelOtherData = -10_40_025;
            public const int Err_DeleteDataInUse = -10_40_026;
        }
        /// <summary>
        /// Board- [-10_41_YYY]
        /// </summary>
        public static class SA_Board
        {
            public const int Err_BoardCode = -10_41_001;
            public const int Err_BoardCodeSymbol = -10_41_002;
            public const int Err_MarketCode = -10_41_003;
            public const int Err_Name = -10_41_004;
            public const int Err_TrCode = -10_41_005;
            //
            public const int Err_BoardCodeExisted = -10_41_006;
            public const int Err_BoardUsered = -10_41_007;
        }
        /// <summary>
        /// TradingRule- [-10_42_YYY] - kiểu giao dịch
        /// </summary>
        public static class SA_TradingRule
        {
            public const int Err_TrCode = -10_42_001;
            public const int Err_TrCodeSymbol = -10_42_002;
            public const int Err_Name = -10_42_003;
            //
            public const int Err_BoardCodeExisted = -10_42_006;

            public const int Err_ExistedInSpecialTradingGrp = -10_42_020;
            public const int Err_ExistedInTradingTimeTable = -10_42_021;
            public const int Err_ExistedInBoard = -10_42_022;
        }
        /// <summary>
        /// SpecialTradingGroup- [-10_43_YYY] - các kiểu giao dịch đặc biệt, với rule khác so với bảng giao dịch
        /// </summary>
        public static class SA_SpecialTradingGroup
        {
            public const int Err_SpecGrpCode = -10_43_001;
            public const int Err_SpecGrpCodeSymbol = -10_43_002;
            public const int Err_Name = -10_43_003;
            public const int Err_TrCode = -10_43_004;
            //
            public const int Err_SpecGrpCodeExisted = -10_43_006;
        }
        /// <summary>
        /// TradingTimeTable- [-10_44_YYY] - định nghĩa một chu trình giao dịch của theo 1 ngày giao dịch
        /// </summary>
        public static class SA_TradingTimeTable
        {
            public const int Err_TimeTableCode = -10_44_001;
            public const int Err_TimeTableCodeSymbol = -10_44_002;
            public const int Err_Name = -10_44_003;
            public const int Err_TrCode = -10_44_004;
            public const int Err_TType = -10_44_005;
            public const int Err_Eoro = -10_44_006;
            public const int Err_SignalControl = -10_44_007;
            //
            public const int Err_SpecGrpCodeExisted = -10_44_020;
            public const int Err_ExistedInTradingSession = -10_44_021;
            //public const int Err_ExistedInSpecialTradingGrp = -10_44_022;
        }

        /// <summary>
        /// TradingSession- [-10_45_YYY] - định nghĩa một phiên giao dịch 
        /// </summary>
        public static class SA_TradingSession
        {
            public const int Err_TradingSessionId = -10_45_001;
            public const int Err_TradingSessionIdSymbol = -10_45_002;
            public const int Err_TimeTableCode = -10_45_003;
            public const int Err_Name = -10_45_004;
            public const int Err_TimeStart = -10_45_005;
            public const int Err_TimeEnd = -10_45_006;
            public const int Err_MatchType = -10_45_007;
            public const int Err_OrderTypeList = -10_45_008;
            public const int Err_BuyAllow = -10_45_009;
            public const int Err_SellAllow = -10_45_010;
            public const int Err_CorAllow = -10_45_011;
            public const int Err_CancAllow = -10_45_012;
            public const int Err_CancExeAllow = -10_45_013;
            public const int Err_BuyAndSellAllow = -10_45_014;
            public const int Err_ExChangeIdMap = -10_45_015;
            public const int Err_OrderTypeReserveList = -10_45_016;
            public const int Err_TimeStartTimeEnd = -10_45_017;

            //
            public const int Err_TradingSessionIdExisted = -10_45_020;
            public const int Err_TradingSessionSameTime = -10_45_021;

        }

        /// <summary>
        /// BranchDepartment - [-10_46_YYY] - Phòng ban của Chi nhánh
        /// </summary>
        public static class SA_BranchDepartment
        {
            public const int Err_AutoId = -10_46_001;
            public const int Err_RefAutoId = -10_46_002;
            public const int Err_DepartmentPid = -10_46_003;
            public const int Err_DepartmentId = -10_46_004;
            public const int Err_Name = -10_46_005;
            public const int Err_NameOther = -10_46_006;
            public const int Err_ManagerUserName = -10_46_007;
            public const int Err_BranchAutoId = -10_46_008;
            public const int Err_BranchPid = -10_46_009;
            public const int Err_DepartmentId_Existed = -10_46_010;
            public const int Err_Status = -10_46_011;
            public const int Err_DeleteDepartmentInUser = -10_46_012;
            public const int Err_DeleteDepartmentInBroker = -10_46_013;
            public const int Err_DeleteDepartmentInCustomer = -10_46_014;
            public const int Err_DeleteDepartmentInAccount = -10_46_015;
        }

        /// <summary>
        /// LogicalBranch - [-10_47_YYY]
        /// </summary>
        public static class SA_LogicalBranch
        {
            public const int Err_AutoId = -10_47_001;
            public const int Err_RefAutoId = -10_47_002;
            public const int Err_Description = -10_47_003;
            public const int Err_RecordStatus = -10_47_004;
            public const int Err_Action = -10_47_005;
            public const int Err_CreateBy = -10_47_006;
            public const int Err_CreateDate = -10_47_007;
            public const int Err_LastChangeBy = -10_47_008;
            public const int Err_LastChangeDate = -10_47_009;
            public const int Err_ApproveBy = -10_47_010;
            public const int Err_ApproveDate = -10_47_011;
            public const int Err_RejectNum = -10_47_012;
            public const int Err_RejectDes = -10_47_013;
            public const int Err_CancelReason = -10_47_014;
            public const int Err_Deleted = -10_47_015;
            //
            public const int Err_LogicalBranchPid = -10_47_016;
            public const int Err_LogicalBranchId = -10_47_017;
            public const int Err_Name = -10_47_018;
            public const int Err_NameOther = -10_47_019;
            public const int Err_ListOfBranches_TabName = -10_47_020;
            public const int Err_LogicalBranchId_Existed = -10_47_021;
            public const int Err_PendingExisted = -10_47_022;
            public const int Err_BranchInAnotherLogicalBranch = -10_47_023;
            public const int Err_ApproveSelfData = -10_47_024;
            public const int Err_CancelOtherData = -10_47_025;
            public const int Err_XoaKhiDaGanVaoUser = -10_47_026;
            public const int Err_XoaKhiDaGanVaoBroker = -10_47_027;
            public const int Err_XoaKhiDaGanVaoUserAccessibleBranch = -10_47_028;
            public const int Err_StatusInactive = -10_47_029;
            public const int Err_ManagerAeId = -10_47_030;
            public const int Err_ListOfBranches = -10_47_031;
        }

        /// <summary>
        /// LogicalBranchBranch - [-10_48_YYY]
        /// </summary>
        public static class SA_LogicalBranchDetail
        {
            public const int Err_AutoId = -10_48_001;
            public const int Err_RefAutoId = -10_48_002;
            public const int Err_Pid = -10_48_003;
            public const int Err_LogicalBranchAutoId = -10_48_004;
            public const int Err_LogicalBranchPid = -10_48_005;
            public const int Err_BranchAutoId = -10_48_006;
            public const int Err_BranchPid = -10_48_007;
            public const int Err_Deleted = -10_48_008;
            public const int Err_BranchPid_NotExisted = -10_48_009;
            public const int Err_BranchPid_UsedByOtherLogicalBranch = -10_48_010;
            public const int Err_BranchId_Status = -10_48_011;
        }

        /// <summary>
        /// Branch - [-10_49_YYY] - Thông tin chi nhánh
        /// </summary>
        public static class SA_Holiday
        {
            public const int Err_AutoId = -10_56_001;
            public const int Err_RefAutoId = -10_56_002;
            public const int Err_Description = -10_56_003;
            public const int Err_RecordStatus = -10_56_004;
            public const int Err_Action = -10_56_005;
            public const int Err_CreateBy = -10_56_006;
            public const int Err_CreateDate = -10_56_007;
            public const int Err_LastChangeBy = -10_56_008;
            public const int Err_LastChangeDate = -10_56_009;
            public const int Err_ApproveBy = -10_56_010;
            public const int Err_ApproveDate = -10_56_011;
            public const int Err_RejectNum = -10_56_012;
            public const int Err_RejectDes = -10_56_013;
            public const int Err_CancelReason = -10_56_014;
            public const int Err_Deleted = -10_56_015;
            //
            public const int Err_SbDate = -10_56_017;
            public const int Err_Calendar = -10_56_018;
            public const int Err_SaturdayType = -10_56_019;
            public const int Err_SundayType = -10_56_020;
            public const int Err_ListHolidayDetail = -10_56_021;

            public const int Err_ListHolidayDetail_SbDate_smaller_than_current_date_max_Payment_Cycle = -10_56_022;

            public const int Err_ListHolidayDetail_SbDate_existing_loan_due_date_ = -10_56_023;

            public const int Err_ListHolidayDetail_DateType_Tllog_activeDate = -10_56_025;
            public const int Err_ListHolidayDetail_Weekend_Date = -10_56_026;
            public const int Err_DeleteDataHasBeenUsed = -10_56_024;

            public const int Err_SbDate_smaller_than_current_date = -10_56_027;

            public const int Err_ListHolidayDetail_DataType = -10_56_028;
            public const int Err_ListHolidayDetail_Remark = -10_56_029;
            public const int Err_ListHolidayDetail_Description = -10_56_029;

        }

        //
        public static class SA_AccountExecutive
        {
            public const int Err_Description = -1049003;
            public const int Err_RecordStatus = -1049004;
            public const int Err_Action = -1049005;
            public const int Err_CreateBy = -1049006;
            public const int Err_CreateDate = -1049007;
            public const int Err_LastChangeBy = -1049008;
            public const int Err_LastChangeDate = -1049009;
            public const int Err_ApproveBy = -1049010;
            public const int Err_ApproveDate = -1049011;
            public const int Err_RejectNum = -1049012;
            public const int Err_RejectDes = -1049013;
            public const int Err_CancelReason = -1049014;
            //
            public const int Err_AeId = -1049017;
            public const int Err_BranchId = -1049019;
            public const int Err_DepartmentId = -1049021;
            public const int Err_Name = -1049022;
            public const int Err_NameOther = -1049023;
            public const int Err_ManagerOfDept = -1049024;
            public const int Err_AeType = -1049025;
            public const int Err_Status = -1049026;
            public const int Err_ReadOnlyUser = -1049027;
            public const int Err_SuperVisor = -1049028;
            public const int Err_Supporter = -1049029;
            public const int Err_Gender = -1049030;
            public const int Err_PhoneNo = -1049031;
            public const int Err_EmailAddress = -1049032;
            public const int Err_Remark = -1049033;
            public const int Err_RemarkOther = -1049034;
            public const int Err_AeOIId = -1049040;
            public const int Err_HireDate = -1049041;
            public const int Err_ContractDate = -1049042;
            public const int Err_AeId_Existed = -1049043;
            public const int Err_PendingExisted = -1049044;
            public const int Err_SuperVisor_BranchIdNotMatch = -1049045;
            public const int Err_Supporter_BranchIdNotMatch = -1049046;
            public const int Err_DeleteUsedData = -1049047;
            public const int Err_DeleteUsedDataByCustomer = -1049048;
            public const int Err_UpdateCustomerOnApprove = -1049049;

            public const int Err_SupervisorTitle = -1049050;
            public const int Err_SupervisorEmail = -1049051;
            public const int Err_ExposureLimit = -1049052;
            public const int Err_Blacklist = -1049053;
            public const int Err_CompanyAE = -1049054;

            public const int Err_LogicalBranchId = -1049055;
            public const int Err_OrderCheckingGroupId = -1049056;
            public const int Err_InactiveUsedData = -1049057;
        }

        //
        public static class SA_AccountExecutiveRole
        {
            public const int Err_AutoId = -1050001;
            public const int Err_RefAutoId = -1050002;
            public const int Err_Pid = -1050003;
            public const int Err_AePid = -1050004;
            public const int Err_AeAutoId = -1050005;
            public const int Err_UserRolePid = -1050006;
            public const int Err_UserRoleAutoId = -1050007;
            public const int Err_Deleted = -1050008;
        }

        //
        public static class SA_AccountExecutiveAccessibleBranch
        {
            public const int Err_AutoId = -1051001;
            public const int Err_RefAutoId = -1051002;
            public const int Err_Pid = -1051003;
            public const int Err_AePid = -1051004;
            public const int Err_AeAutoId = -1051005;
            public const int Err_BranchType = -1051006;
            public const int Err_BranchPid = -1051007;
            public const int Err_BranchId = -1051008;
            public const int Err_Deleted = -1051009;
        }


        //
        public static class SA_AccountExecutiveMapping
        {
            public const int Err_AutoId = -1052001;
            public const int Err_RefAutoId = -1052002;
            public const int Err_Description = -1052003;
            public const int Err_RecordStatus = -1052004;
            public const int Err_Action = -1052005;
            public const int Err_CreateBy = -1052006;
            public const int Err_CreateDate = -1052007;
            public const int Err_LastChangeBy = -1052008;
            public const int Err_LastChangeDate = -1052009;
            public const int Err_ApproveBy = -1052010;
            public const int Err_ApproveDate = -1052011;
            public const int Err_RejectNum = -1052012;
            public const int Err_RejectDes = -1052013;
            public const int Err_CancelReason = -1052014;
            public const int Err_Deleted = -1052015;
            //
            public const int Err_AeMappingPid = -1052016;
            public const int Err_AePid = -1052017;
            public const int Err_AeId = -1052018;
            public const int Err_Status = -1052019;
            public const int Err_EffectiveDate = -1052020;
            public const int Err_ExpiryDate = -1052021;
            public const int Err_SupportedAccounts = -1052022;
            public const int Err_SupportedInstruments = -1052023;
            public const int Err_AePid_Existed = -1052024;
            public const int Err_PendingExisted = -1052025;
            public const int Err_ExpiryDate_LessThanEffectiveDate = -1052026;
            public const int Err_AeMainPid = -1052027;
            public const int Err_SupportAllAeMainAccounts = -1052028;
            public const int Err_ApproveSelfData = -1052029;
            public const int Err_CancelOtherData = -1052030;
        }

        //
        public static class SA_AccountExecutiveMappingAccount
        {
            public const int Err_AutoId = -1053001;
            public const int Err_RefAutoId = -1053002;
            public const int Err_Pid = -1053003;
            public const int Err_AeMappingPid = -1053004;
            public const int Err_AeMappingAutoId = -1053005;
            public const int Err_AfAccNo = -1053006;
            public const int Err_AfAccName = -1053007;
            public const int Err_Deleted = -1053008;
        }

        //
        public static class SA_AccountExecutiveMappingInstrument
        {
            public const int Err_AutoId = -1054001;
            public const int Err_RefAutoId = -1054002;
            public const int Err_Pid = -1054003;
            public const int Err_AeMappingPid = -1054004;
            public const int Err_AeMappingAutoId = -1054005;
            public const int Err_Type = -1054006;
            public const int Err_Instrument = -1054007;
            public const int Err_Deleted = -1054008;
        }

        //
        public static class SA_TradingAccountSubStatus
        {
            public const int Err_AutoId = -1055001;
            public const int Err_RefAutoId = -1055002;
            public const int Err_TradingAcctPid = -1055003;
            public const int Err_SubStatusCode = -1055004;
            public const int Err_SubStatusName = -1055005;
            public const int Err_DataType = -1055006;
            public const int Err_Description = -1055007;
            public const int Err_RecordStatus = -1055008;
            public const int Err_Action = -1055008;

            public const int Err_ListOfTradingAccountSubStatusDetail_TabName = -1055030;
            public const int Err_Detail_RightCode = -1055031;
            public const int Err_Detail_Allow = -1055032;


            public const int Err_Derivative = -1055033;
            public const int Err_Underlying = -1055034;
            public const int Err_RemoveMappingValueVsd = -1055035;
            public const int Err_MappingValueVsd = -1055036;
            public const int Err_NameOther = -1055037;
            public const int Err_StatusMember = -1055038;
            public const int Err_StatusVsd = -1055039;
        }

        //
        public static class SA_Company
        {
            public const int Err_CompanyId = -1057001;
            public const int Err_Name = -1057002;
            public const int Err_NameOther = -1057003;
            public const int Err_Address1 = -1057004;
            public const int Err_Address1Other = -1057005;
            public const int Err_Address2 = -1057006;
            public const int Err_Address2Other = -1057007;
            public const int Err_Country = -1057008;
            public const int Err_PhoneNumber = -1057009;
            public const int Err_FaxNumber = -1057010;
            public const int Err_Website = -1057011;
            public const int Err_TaxCode = -1057012;
            public const int Err_BussinessCode = -1057013;
            //
            public const int Err_Settings_Currency = -1057014;
            public const int Err_Settings_BusCalendar = -1057015;
            public const int Err_Settings_DateFormat = -1057016;
            public const int Err_Settings_DecimalPlace = -1057017;
            public const int Err_Settings_ThousandSparator = -1057018;
            public const int Err_Settings_PrimaryLanguage = -1057019;
            public const int Err_Settings_SecondaryLanguage = -1057020;
            public const int Err_Settings_TabName = -1057021;
            //
            public const int Err_Policy_UseLDAP = -1057022;
            public const int Err_Policy_MaxLoginFail = -1057023;
            public const int Err_Policy_ExpirenDay = -1057024;
            public const int Err_Policy_NotRepeatLastCharacter = -1057025;
            public const int Err_Policy_LongThanCharater = -1057026;
            public const int Err_Policy_UseUperAndLower = -1057027;
            public const int Err_Policy_AtLeastOneNumber = -1057028;
            public const int Err_Policy_TabName = -1057029;
            //
            public const int Err_SystemDefaul_MarketAutoId = -1057030;
            public const int Err_SystemDefaul_MarketCode = -1057031;
            public const int Err_SystemDefaul_Currency = -1057032;
            public const int Err_SystemDefaul_RegistrationType = -1057033;
            public const int Err_SystemDefaul_AccountChannel = -1057034;
            public const int Err_SystemDefaul_Nationallity = -1057035;
            public const int Err_SystemDefaul_AccountType = -1057036;
            public const int Err_SystemDefaul_AccountLanguage = -1057037;
            public const int Err_SystemDefaul_AccountClass = -1057038;
            public const int Err_SystemDefaul_AccountMergeTrade = -1057039;
            public const int Err_SystemDefaul_AccountIdType = -1057040;
            public const int Err_SystemDefaul_ReferType = -1057041;
            public const int Err_SystemDefaul_AccountIdIssuePlace = -1057042;
            public const int Err_SystemDefaul_BranchId = -1057043;
            public const int Err_SystemDefaul_TabName = -1057044;
            //
            public const int Err_ProductSetting_ParameterId = -1057045;
            public const int Err_ProductSetting_ProductValue = -1057046;
            public const int Err_ProductSetting_TabName = -1057047;

            //
            public const int Err_RecordStatus = -1057048;
            public const int Err_Action = -1057049;
            public const int Err_RejectDes = -1057050;
            public const int Err_CancelReason = -1057051;
            public const int Err_ApproveSelfData = -1057052;
            public const int Err_CancelOtherData = -1057053;
            public const int Err_PendingExisted = -1057054;
            //
            public const int Err_Settings_DataExisted = -1057055;
            public const int Err_Policy_DataExisted = -1057056;
            public const int Err_SystemDefaul_DataExisted = -1057057;
            public const int Err_ProductSetting_DataExisted = -1057058;
            //
            public const int Err_Address3 = -1057059;
            public const int Err_Address3Other = -1057060;
            public const int Err_DuplicateCompanyId = -1057061;
            public const int Err_OnlyDataOneAllowed = -1057062;

            public const int Err_SystemDefaul_AccountInterface = -1057063;
            public const int Err_ProductSettings_Value_Invalid = -1057064;
            public const int ERR_RECORD_WITH_VALID_STATUS_ALREADY_EXISTS = -1057065;
            public const int ERR_USER_DOES_NOT_HAVE_PERMISSION_TO_SET_PARAMETER = -1057066;

        }

        //
        public static class SA_Market
        {
            public const int Err_Name = -1058001;
            public const int Err_NameOther = -1058002;
            public const int Err_DayOffSet = -1058003;
            public const int Err_Market = -1058004;
            public const int Err_LocalMarket = -1058005;
            public const int Err_DefaultTradeType = -1058006;
            public const int Err_MarketKrxId = -1058006;

            //Location
            public const int Err_AccountType = -1058007;
            public const int Err_LocationId = -1058009;
            public const int Err_IsDefault = -1058010;
            public const int Err_Location = -1058057;

            //MarketInstrumentSetting
            public const int Err_MarketInstrumentSetting_Price = -1058011;
            public const int Err_MarketInstrumentSetting_Quality = -1058012;
            public const int Err_MarketInstrumentSetting_Trade = -1058013;
            public const int Err_MarketInstrumentSetting_BrokerSettle = -1058014;
            public const int Err_MarketInstrumentSetting_AccountSettle = -1058015;
            public const int Err_MarketInstrumentSetting_CashAccountBuy = -1058016;
            public const int Err_MarketInstrumentSetting_CashAccountSell = -1058017;
            public const int Err_MarketInstrumentSetting_CashBrokerBuy = -1058018;
            public const int Err_MarketInstrumentSetting_CashBrokerSell = -1058019;
            public const int Err_MarketInstrumentSetting_InstAccountBuy = -1058020;
            public const int Err_MarketInstrumentSetting_InstAccountSell = -1058021;
            public const int Err_MarketInstrumentSetting_InstBrokerBuy = -1058022;
            public const int Err_MarketInstrumentSetting_InstBrokerSell = -1058023;
            public const int Err_MarketInstrumentSetting_NoCIAForWithdrawal = -1058024;
            public const int Err_MarketInstrumentSetting = -1058058;

            //MarketInfomation
            public const int Err_MarketInfomation_MarginCalculation = -1058025;
            public const int Err_MarketInfomation_CalPremium = -1058055;
            public const int Err_MarketInfomation_Separate_Client_Hose = -1058026;
            public const int Err_MarketInfomation_LoadRiskParameter = -1058027;
            public const int Err_MarketInfomation_ExchangeCode = -1058028;
            public const int Err_MarketInfomation_ComplexCode = -1058029;
            public const int Err_MarketInfomation_FileFormat = -1058030;
            public const int Err_MarketInfomation_LoadData = -1058031;
            public const int Err_MarketInfomation_CustomerClientPercent = -1058032;
            public const int Err_MarketInfomation_FileLinkPrefix = -1058033;
            public const int Err_MarketInfomation_CustomerHousePercent = -1058034;
            public const int Err_MarketInfomation_CustomerInitExtra = -1058035;
            public const int Err_MarketInfomation_CustomerMaintExtra = -1058036;
            public const int Err_MarketInfomation_BrokerClientPercent = -1058037;
            public const int Err_MarketInfomation_BrokerHousePercent = -1058038;
            public const int Err_MarketInfomation_BrokerInitExtra = -1058039;
            public const int Err_MarketInfomation_BrokerMaintExtra = -1058040;
            public const int Err_MarketInfomation = -1058060;



            //ParameterSetting
            public const int Err_ParameterSetting_ParameterId = -1058041;
            public const int Err_ParameterSetting_Value = -1058042;
            public const int Err_ParameterSetting_TabName = -1058043;
            public const int Err_ParameterSetting = -1058056;

            //MarketOthers
            public const int Err_MarketOthers_VsdInterface = -1058044;
            public const int Err_MarketOthers_MarketCode = -1058045;
            public const int Err_MarketOthers_TradeDate = -1058046;
            public const int Err_MarketOthers_LastTradeDate = -1058049;
            public const int Err_MarketOthers_NexTradeDate = -1058050;
            public const int Err_MarketOthers_IdividualOrderCheckingGroupId = -1058051;
            public const int Err_MarketOthers_IdividualPositionLimitGrpId = -1058052;
            public const int Err_MarketOthers_InstitutionPositionLimitGrpId = -1058053;
            public const int Err_MarketOthers_InstitutionOrderCheckingGroupId = -1058054;
            public const int Err_MarketOthers = -1058059;
            public const int Err_Market_Description = -1058060;

            public const int ERR_MARKET_VALIDATE_DELETE_INSTRUMENT = -1058068; // xoá bản ghi market đã gán vào mcinstrument
            public const int ERR_MARKET_VALIDATE_DELETE_BANKINSTRUMENT = -1058069;
            public const int ERR_MARKET_VALIDATE_PARAM_REQUIRED = -1058070;

            public const string ERR_DEFAULT_PARAMETER_SETTINGS_TAB = "Cấu hình tham số mặc định";
            public const string ERR_DEFAULT_PARAMETER_SETTINGS_TAB_EN = "Default Paramter Settings";

            public const int ERR_MARKET_TRADEDATE_IS_HOLIDAY = -1058071;
            public const int ERR_MARKET_LASTTRADEDATE_IS_HOLIDAY = -1058072;
            public const int ERR_MARKET_NEXTTRADEDATE_IS_HOLIDAY = -1058073;

            public const int ERR_MARKET_DEFAULT_PARAMETER_SETTINGS_VALUE = -1058074;
            public const int ERR_MARKET_VALIDATE_DELETE_MARKETGROUP = -1058075;

            public const int ERR_MARKET_VALIDATE_DELETE_COMPANY = -1058076;

            //
            public const int ERR_MARKET_VALIDATE_DELETE_ACCOUNT_MARKET = -1058077;
            public const int ERR_MARKET_VALIDATE_DELETE_ACCOUNT_MARKET_UNDERLYING = -1058078;
            public const int ERR_MARKET_VALIDATE_DELETE_POSITION_LIMIT_GROUP_DETAIL = -1058079;
            public const int ERR_MARKET_VALIDATE_DELETE_ORDER_CHECKING_GROUP_DETAIL = -1058080;
            public const int ERR_MARKET_VALIDATE_DELETE_UNDERLYING = -1058081;
            public const int ERR_MARKET_VALIDATE_DELETE_MARKET_GROUP_DETAIL = -1058082;
            public const int WARNING_MARKET_INSTRUMENT_UPDATE = -1058084;

        }

        //
        public static class SA_Channel
        {
            public const int Err_ChannelCode = -1059001;
            public const int Err_ChannelStatus = -1059002;
            public const int Err_Name = -1059003;
            public const int Err_NameOther = -1059004;
            public const int Err_ChannelGroup = -1059005;
            public const int Err_ConnectionMethod = -1059006;
            public const int Err_Remark = -1059007;

            public const int Err_DuplicateChannelCode = -1059008;
            public const int Err_RecordStatus = -1059009;
            public const int Err_Action = -1059010;
            public const int Err_RejectDes = -1059011;
            public const int Err_CancelReason = -1059012;
            public const int Err_ApproveSelfData = -1059013;
            public const int Err_CancelOtherData = -1059014;
            public const int Err_PendingExisted = -1059015;
            public const int Err_UsegaInCalculationMethod = -1059016;
            public const int Err_UsegaInAccount = -1059017;
            public const int Err_UsegaInOther = -1059018;

            public const int Err_ProductClassId = -1059019;
            public const int Err_UsegaInOrderChannel = -1059020;
            public const int Err_IsForExpiryOrder = -1059021;
            public const int Err_IsForExpiryOrderChecked = -1059022;
        }

        public static class SA_Bank
        {
            public const int Err_BankId = -1060001;
            public const int Err_ClearingCode = -1060002;
            public const int Err_Name = -1060003;
            public const int Err_NameOther = -1060004;
            public const int Err_CitadCode = -1060005;
            public const int Err_NapasCode = -1060006;
            public const int Err_Decription = -1060007;
            public const int Err_ListOfBranch = -1060008;
            public const int Err_InstrumentSettings = -1060009;
            public const int Err_DefaultFeeSettings = -1060010;
            public const int Err_BankOtherSettings = -1060011;
            public const int Err_UserParameters = -1060012;
            public const int Err_ItParameters = -1060013;

            public const int Err_DuplicateBankId = -1060014;
            //
            public const int Err_RecordStatus = -1060015;
            public const int Err_Action = -1060016;
            public const int Err_RejectDes = -1060017;
            public const int Err_CancelReason = -1060018;
            public const int Err_ApproveSelfData = -1060019;
            public const int Err_CancelOtherData = -1060020;
            public const int Err_PendingExisted = -1060021;

            //branch
            public const int Err_BranchIdExisted = -1060022;
            public const int Err_BranchId = -1060023;
            public const int Err_BranchName = -1060024;
            public const int Err_BranchCitadCode = -1060025;
            public const int Err_BranchStatus = -1060026;

            //instrument
            public const int Err_InstrumentIdDuplicate = -1060027;
            public const int Err_MarketId = -1060028;
            public const int Err_Instrument = -1060029;

            //default fee
            public const int Err_DefaultFeeBankId = -1060030;
            public const int Err_FeeNatureId = -1060031;
            public const int Err_FeeNatureType = -1060032;
            public const int Err_CalculationMethod = -1060033;

            //other
            public const int Err_OtherBankId = -1060034;
            public const int Err_CashInterfaceType = -1060035;

            //param
            public const int Err_ParamBankId = -1060036;
            public const int Err_COM_BANK_ACCOUNT_NAME = -1060038;
            public const int Err_COM_BANK_ACCOUNT_NO = -1060039;
            public const int Err_BANK_TRANS_CODE_REQUIRED = -1060040;

            public const int Err_Status = -1060037;
            public const int Err_bankIdNotMatching = -1060041;
            public const int Err_BankContainInBankAccount = -1060044;
            public const int Err_BankBranchContainInBankAccount = -1060043;
            public const int Err_StatusOfInstrument = -1060045;

            public const int Err_CitadCodeExited = -1060042;
            public const int Err_NapasCodeExited = -1060046;

        }

        public static class SA_BankAccount
        {
            public const int Err_BankAccNo = -1061001;
            public const int Err_BankAccPid = -1061002;
            public const int Err_BankAccId = -1061003;
            public const int Err_Name = -1061004;
            public const int Err_NameOther = -1061005;
            public const int Err_CurrencyCd = -1061006;
            public const int Err_IsActive = -1061007;
            public const int Err_SupportElectronicLedger = -1061008;
            public const int Err_SupportElectronicYcd = -1061009;
            //public const int Err_IsDefault = -1061010;
            public const int Err_SendNapas = -1061011;
            public const int Err_SendCitad = -1061012;
            public const int Err_BankAccountHolderName = -1061013;
            public const int Err_BankAccoutHolderAdd = -1061015;
            public const int Err_BankAccountUsage = -1061018;
            public const int Err_MerchantId = -1061019;
            public const int Err_MerchantName = -1061020;
            public const int Err_DefaulForOnlineTransfer = -1061021;
            public const int Err_Internal = -1061022;


            //Bank Account Details
            public const int Err_UsageType = -1061023;
            public const int Err_FundingType = -1061024;
            public const int Err_UsedAmount = -1061025;
            public const int Err_FundingAmount = -1061026;
            public const int Err_IsDefault = -1061027;
            public const int Err_BankAccountDetails = -1061028;
            public const int Err_BankAccountDetailsDefaultUsageType = -1061031;

            //
            public const int Err_BankAccNoExisted = -1061032;
            public const int Err_BankDefaultOnlineTransfer = -1061033;
            public const int Err_BankSupportElectronicYcd = -1061034;
            public const int Err_RemittanceChannel = -1061035;
            public const int Err_UsedInAccountCashMovement = -1061036;
            public const int Err_BankType = -1061037;
        }

        public static class SA_Currency
        {
            public const int Err_CurrencyId = -10_39_003;

        }

        public static class SA_RegistrationGroup
        {
            public const int Err_RegistrationGroupId = -10_62_001;
            public const int Err_Name = -10_62_002;
            public const int Err_NameOther = -10_62_003;
            public const int Err_ListOfRegistrationTypes = -10_62_004;
            public const int Err_ListOfRegistrationTypes_Empty = -10_62_005;
            public const int Err_RegistrationGroup_Existed = -10_62_006;
            public const int Err_ExistedInFeeNature = -10_62_007;
        }

        public static class SA_RegistrationGroupRegistrationType
        {
            public const int Err_RegistrationTypeId = -10_63_001;
        }

        public static class SA_MarketGroup
        {
            public const int Err_MarketID_Require = -10_64_001;
            public const int Err_MGName_Require = -10_64_002;
            public const int Err_ProductGroup_Invalid = -10_64_003;
        }

        public static class SA_CalculationMethod
        {
            public const int Err_CalculationMethodId = -10_65_001;
            public const int Err_Name = -10_65_002;
            public const int Err_NameOther = -10_65_003;
            public const int Err_Enable = -10_65_004;
            public const int Err_ExistedInFeeClassFeeNature = -10_65_005;
            public const int Err_ExistedInBankFee = -10_65_006;
            public const int Err_ExistedInPromotionPeriod = -10_65_007;
            public const int Err_ExistedInAccountCashMovementFee = -10_65_008;
            public const int Err_OldDataChanged = -10_65_009;
            public const int Err_ExistedAccountOverrideFee = -10_65_010;
            public const int Err_ExistedAccountContractFee = -10_65_011;
            public const int Err_ExistedAccountAccuredFee = -10_65_012;
            public const int Err_ExistedAccountInstrumentMovementFee = -10_65_013;

            //
            public const int Err_ListTimeTables_TabName = -10_65_020;
            public const int Err_TimeTable_EffectDate = -10_65_021;
            public const int Err_TimeTable_CalculationBase = -10_65_022;
            public const int Err_TimeTable_CalculationLookUp = -10_65_023;
            public const int Err_TimeTable_ExtraCalculationBase = -10_65_024;
            public const int Err_TimeTable_ExtraCalculationLookUp = -10_65_025;
            public const int Err_ListTimeTables_Empty = -10_65_026;
            public const int Err_TimeTable_EffectDate_Busdate = -10_65_027;
            public const int Err_TimeTable_EffectDate_Existed = -10_65_028;

            //
            public const int Err_ListTimeTableDetails_TabName = -10_65_030;
            public const int Err_TimeTableDetail_ChannelId = -10_65_031;
            public const int Err_TimeTableDetail_CurrencyId = -10_65_032;
            public const int Err_TimeTableDetail_MinMaxTime = -10_65_033;
            public const int Err_TimeTableDetail_RateTypeId = -10_65_034;
            public const int Err_ListTimeTableDetail_Empty = -10_65_035;
            public const int Err_TimeTableDetail_Rounding = -10_65_036;
            public const int Err_TimeTable_ChannelId_Existed = -10_65_037;
            public const int Err_TimeTableDetail_FactorDuplicated = -10_65_038;
        }

        public static class SA_FeeClass
        {
            public const int Err_FeeClassID_Require = -10_66_001;
            public const int Err_FeeClassName_Require = -10_66_002;
            public const int Err_FeeClassID_Exist = -10_66_003;
            public const int Err_FeeClass_Default = -10_66_004;
            public const int Err_FeeClass_Decline_Delete = -10_66_005;
            public const int Err_UserCantUpdateDeleteDefaultFeeClass = -10_66_006;
            public const int Err_HasBeenUsedByAccountType_DeleteNotAllowed = -10_66_007;
            public const int Err_HasBeenUsedByServiceClass_DeleteNotAllowed = -10_66_008;
            public const int Err_HasBeenUsedByAccount_DeleteNotAllowed = -10_66_009;
            public const int Err_HasBeenUsedByAccountType_CantChangeEnable = -10_66_010;
            public const int Err_HasBeenUsedByServiceClass_CantChangeEnable = -10_66_011;
            public const int Err_HasBeenUsedByAccount_CantChangeEnable = -10_66_012;
            public const int Err_NameOther = -10_66_013;
            public const int Err_Enable = -10_66_014;
            public const int Err_ProductClassId = -10_66_015;
            public const int Err_FeeClassTypeId = -10_66_016;

            public const int Err_FeeClassDetails = -10_66_017;
            public const int Err_FeeClassDetails_FeeNatureId = -10_66_018;
            public const int Err_FeeClassDetails_CalculationMethodId = -10_66_019;
        }

        public static class SA_FeeNature
        {
            public const int Err_FeeNature_Name = -10_67_001;
            public const int Err_FeeNature_NameOther = -10_67_002;
            public const int Err_FeeNature_Enable = -10_67_003;
            public const int Err_FeeNature_FeeNatureTypeId = -10_67_004;
            public const int Err_FeeNature_FeeNatureCategoryId = -10_67_005;
            public const int Err_FeeNature_AddToSettleAmount = -10_67_006;
            public const int Err_FeeNature_AccountFee = -10_67_007;
            public const int Err_FeeNature_AccrualBasis = -10_67_008;
            public const int Err_FeeNature_AccrueForOneDayOnly = -10_67_009;
            public const int Err_FeeNature_OperandTypeId = -10_67_010;
            public const int Err_FeeNature_PeriodDivisorType = -10_67_011;
            public const int Err_FeeNature_PeriodTypeId = -10_67_012;
            public const int Err_FeeNature_PostingCurrencyId = -10_67_013;
            public const int Err_FeeNature_PostingGroupId = -10_67_014;
            public const int Err_FeeNature_NthWorkingDay = -10_67_015;
            public const int Err_FeeNature_WaivePostingAmount = -10_67_016;
            public const int Err_FeeNature_MinimumPostingAmount = -10_67_017;
            public const int Err_FeeNature_MaximumPostingAmount = -10_67_018;
            public const int Err_FeeNature_Description = -10_67_019;
            public const int Err_FeeNature_ShowZeroAmount = -10_67_020;
            public const int Err_FeeNatureFilterSetting = -10_67_021;
            public const int Err_FeeNatureFilterSetting_TradeType = -10_67_022;
            public const int Err_FeeNatureFilterSetting_ParamValue_Invalid = -10_67_023;
            public const int Err_FeeNature_Has_Been_Used_MCBankFee = -10_67_024;
            public const int Err_FeeNature_Has_Been_Used_FeeClassFeeNature = -10_67_025;
            public const int Err_FeeNature_Has_Been_Used_PromotionPeriod = -10_67_026;
            public const int Err_FeeNature_RegistrationGroup_Does_Not_Exist = -10_67_027;
            public const int Err_FeeNature_MarketGroup_Does_Not_Exist = -10_67_028;
            public const int Err_FeeNature_Has_Been_Used_MCBankFee_For_Enable = -10_67_029;
            public const int Err_FeeNature_Has_Been_Used_FeeClassFeeNature_For_Enable = -10_67_030;
            public const int Err_FeeNature_Has_Been_Used_PromotionPeriod_For_Enable = -10_67_031;
        }

        public static class SA_InterestClass
        {
            public const int SA_InterestClass_Name = -10_68_001;
            public const int SA_InterestClass_NameOther = -10_68_002;
            public const int SA_InterestClass_Enable = -10_68_003;
            public const int SA_InterestClass_CurrencyId = -10_68_004;
            public const int SA_InterestClass_RateTypeId = -10_68_005;
            public const int SA_InterestClass_Rounding = -10_68_006;
            public const int SA_InterestClass_DecimalPlaces = -10_68_007;
            public const int SA_InterestClass_CalculateBy = -10_68_008;
            public const int SA_InterestClass_RateDivisorTypeId = -10_68_009;
            public const int SA_InterestClass_Factor1 = -10_68_010;
            public const int SA_InterestClass_Value1 = -10_68_011;
            public const int SA_InterestClass_Factor2 = -10_68_012;
            public const int SA_InterestClass_Value2 = -10_68_013;
            public const int SA_InterestClass_Factor3 = -10_68_014;
            public const int SA_InterestClass_Value3 = -10_68_015;
            public const int SA_InterestClass_Factor4 = -10_68_016;
            public const int SA_InterestClass_Value4 = -10_68_017;
            public const int SA_InterestClass_Factor5 = -10_68_018;
            public const int SA_InterestClass_Value5 = -10_68_019;
            public const int SA_InterestClass_Dupplicate_EffectiveDate = -10_68_020;
            public const int SA_InterestClass_Use_For_AccountType = -10_68_021;
            public const int SA_InterestClass_Use_For_ServiceClass = -10_68_023;
            public const int SA_InterestClass_Use_For_AccountOverrideSetting = -10_68_024;
            public const int SA_InterestClass_Use_For_AccountAccruedInterest = -10_68_025;
            public const int SA_InterestClass_Use_For_AccountAccruedInterestTransaction = -10_68_026;
            public const int SA_InterestClass_Use_For_PromotionPeriod = -10_68_030;
            public const int Err_OldDataChanged = -10_68_027;
            public const int Err_Approve_EffectiveDate_Smaller_Than_Busdate = -10_68_028;
            public const int Err_Uncheck_Enable = -10_68_029;
        }
        public static class SA_TransactionCode
        {
            public const int Err_TranCode_Require = -10_69_001;
            public const int Err_TransactionCodeType_Require = -10_69_002;
            public const int Err_TransactionCode_Name_Require = -10_69_003;
            public const int Err_TransactionCatalog_Require = -10_69_004;
            public const int Err_TransactionCodeType_TransactionCodeCatalogId = -10_69_005;
            public const int Err_IsCash_Invalid = -10_69_006;
            public const int Err_BankId_Invalid = -10_69_007;
            public const int Err_Allow_BankAccount_Invalid = -10_69_008;
            public const int Err_AllowBankAccountMandatory_Invalid = -10_69_009;
            public const int Err_PostNegativeAmount_Invalid = -10_69_010;
            public const int Err_AllowTransferBank_Invalid = -10_69_011;
            public const int Err_AllowTransferToSameClient_Invalid = -10_69_012;
            public const int Err_AllowTransferToDifferentClient_Invalid = -10_69_013;
            public const int Err_ToBankId_Invalid = -10_69_014;
            public const int Err_ToBankBranchId_Invalid = -10_69_015;
            public const int Err_ToBankAccountNumber_Invalid = -10_69_016;
            public const int Err_ToBankAccountName_Invalid = -10_69_017;


        }

        public static class SA_AccountType
        {
            public const int Err_AccountType_Name = -10_68_001;
            public const int Err_AccountType_NameOther = -10_68_002;
            public const int Err_AccountType_Enable = -10_68_003;
            public const int Err_AccountType_AccountTypeId = -10_68_004;
            public const int Err_AccountType_AccountTypeCategoryId = -10_68_005;
            public const int Err_AccountType_AddToSettleAmount = -10_68_006;
            public const int Err_AccountType_AccountFee = -10_68_007;
            public const int Err_AccountType_AccrualBasis = -10_68_008;
            public const int Err_AccountType_AccrueForOneDayOnly = -10_68_009;
            public const int Err_AccountType_OperandTypeId = -10_68_010;
            public const int Err_AccountType_PeriodDivisorType = -10_68_011;
            public const int Err_AccountType_PeriodTypeId = -10_68_012;
            public const int Err_AccountType_PostingCurrencyId = -10_68_013;
            public const int Err_AccountType_PostingGroupId = -10_68_014;
            public const int Err_AccountType_NthWorkingDay = -10_68_015;
            public const int Err_AccountType_WaivePostingAmount = -10_68_016;
            public const int Err_AccountType_MinimumPostingAmount = -10_68_017;
            public const int Err_AccountType_MaximumPostingAmount = -10_68_018;
            public const int Err_AccountType_Description = -10_68_019;
            public const int Err_AccountType_ShowZeroAmount = -10_68_020;
            public const int Err_AccountTypeFilterSetting = -10_68_021;
            public const int Err_AccountTypeFilterSetting_TradeType = -10_68_022;
            public const int Err_AccountTypeFilterSetting_ParamValue_Invalid = -10_68_023;
            public const int Err_AccountType_Has_Been_Used_MCBankFee = -10_68_024;
            public const int Err_AccountType_Has_Been_Used_FeeClassAccountType = -10_68_025;
            public const int Err_AccountType_Has_Been_Used_PromotionPeriod = -10_68_026;
            public const int Err_AccountType_RegistrationGroup_Does_Not_Exist = -10_68_027;
            public const int Err_AccountType_MarketGroup_Does_Not_Exist = -10_68_028;
            public const int Err_AccountType_UsingInExistData = -10_68_053;
            public const int Err_AccountType_EnableInOtherData = -10_68_054;
        }
        public static class SA_ServiceClass
        {
            public const int Err_ServiceClass_Name = -10_69_001;
            public const int Err_ServiceClass_NameOther = -10_69_002;
            public const int Err_ServiceClass_Enable = -10_69_003;
            public const int Err_ServiceClass_ServiceClassId = -10_69_004;
            public const int Err_ServiceClass_ServiceClassCategoryId = -10_69_005;
            public const int Err_ServiceClass_AddToSettleAmount = -10_69_006;
            public const int Err_ServiceClass_AccountFee = -10_69_007;
            public const int Err_ServiceClass_AccrualBasis = -10_69_008;
            public const int Err_ServiceClass_AccrueForOneDayOnly = -10_69_009;
            public const int Err_ServiceClass_OperandTypeId = -10_69_010;
            public const int Err_ServiceClass_PeriodDivisorType = -10_69_011;
            public const int Err_ServiceClass_PeriodTypeId = -10_69_012;
            public const int Err_ServiceClass_PostingCurrencyId = -10_69_013;
            public const int Err_ServiceClass_PostingGroupId = -10_69_014;
            public const int Err_ServiceClass_NthWorkingDay = -10_69_015;
            public const int Err_ServiceClass_WaivePostingAmount = -10_69_016;
            public const int Err_ServiceClass_MinimumPostingAmount = -10_69_017;
            public const int Err_ServiceClass_MaximumPostingAmount = -10_69_018;
            public const int Err_ServiceClass_Description = -10_69_019;
            public const int Err_ServiceClass_ShowZeroAmount = -10_69_020;
            public const int Err_ServiceClassFilterSetting = -10_69_021;
            public const int Err_ServiceClassFilterSetting_TradeType = -10_69_022;
            public const int Err_ServiceClassFilterSetting_ParamValue_Invalid = -10_69_023;
            public const int Err_ServiceClass_Has_Been_Used_MCBankFee = -10_69_024;
            public const int Err_ServiceClass_Has_Been_Used_FeeClassServiceClass = -10_69_025;
            public const int Err_ServiceClass_Has_Been_Used_PromotionPeriod = -10_69_026;
            public const int Err_ServiceClass_RegistrationGroup_Does_Not_Exist = -10_69_027;
            public const int Err_ServiceClass_MarketGroup_Does_Not_Exist = -10_69_028;
        }
        public static class SA_FinancialClass
        {
            public const int Err_FinancialClass_Name = -10_70_001;
            public const int Err_FinancialClass_NameOther = -10_70_002;
            public const int Err_FinancialClass_Enable = -10_70_003;
            public const int Err_FinancialClass_FinancialClassId = -10_70_004;
            public const int Err_FinancialClass_FinancialClassCategoryId = -10_70_005;
            public const int Err_FinancialClass_AddToSettleAmount = -10_70_006;
            public const int Err_FinancialClass_AccountFee = -10_70_007;
            public const int Err_FinancialClass_AccrualBasis = -10_70_008;
            public const int Err_FinancialClass_AccrueForOneDayOnly = -10_70_009;
            public const int Err_FinancialClass_OperandTypeId = -10_70_010;
            public const int Err_FinancialClass_PeriodDivisorType = -10_70_011;
            public const int Err_FinancialClass_PeriodTypeId = -10_70_012;
            public const int Err_FinancialClass_PostingCurrencyId = -10_70_013;
            public const int Err_FinancialClass_PostingGroupId = -10_70_014;
            public const int Err_FinancialClass_NthWorkingDay = -10_70_015;
            public const int Err_FinancialClass_WaivePostingAmount = -10_70_016;
            public const int Err_FinancialClass_MinimumPostingAmount = -10_70_017;
            public const int Err_FinancialClass_MaximumPostingAmount = -10_70_018;
            public const int Err_FinancialClass_Description = -10_70_019;
            public const int Err_FinancialClass_ShowZeroAmount = -10_70_020;
            public const int Err_FinancialClassFilterSetting = -10_70_021;
            public const int Err_FinancialClassFilterSetting_TradeType = -10_70_022;
            public const int Err_FinancialClassFilterSetting_ParamValue_Invalid = -10_70_023;
            public const int Err_FinancialClass_Has_Been_Used_MCBankFee = -10_70_024;
            public const int Err_FinancialClass_Has_Been_Used_FeeClassFinancialClass = -10_70_025;
            public const int Err_FinancialClass_Has_Been_Used_PromotionPeriod = -10_70_026;
            public const int Err_FinancialClass_RegistrationGroup_Does_Not_Exist = -10_70_027;
            public const int Err_FinancialClass_MarketGroup_Does_Not_Exist = -10_70_028;
        }

        public static class SA_OrderCheckingGroup
        {
            public const int Err_OrderCheckingGroup_Status = -10_71_001;
            public const int Err_OrderCheckingGroupDetail_OverrideInstrument = -10_71_002;
            public const int Err_OrderCheckingGroupDetail_InvestorType = -10_71_003;
            public const int Err_OrderCheckingGroupDetail_RegistrationType = -10_71_004;
            public const int Err_OrderCheckingGroupDetail_MarketId = -10_71_005;
            public const int Err_OrderCheckingGroupDetail_UnderlyingId = -10_71_006;
            public const int Err_OrderCheckingGroupDetail_InstrumentId = -10_71_007;
            public const int Err_OrderCheckingGroupDetail_MaxVolumeQty = -10_71_008;
            public const int Err_OrderCheckingGroupDetail_WarnVolumeQty = -10_71_009;
            public const int Err_OrderCheckingGroupDetail_SsiUsedLimitWarningLevel1 = -10_71_010;
            public const int Err_OrderCheckingGroupDetail_SsiUsedLimitWarningLevel2 = -10_71_011;
            public const int Err_OrderCheckingGroupDetail_SsiUsedLimit = -10_71_012;
            public const int Err_OrderCheckingGroup_OrderCheckingGroupId = -10_71_013;
            public const int Err_HasBeenUsedByAccount_DeleteNotAllowed = -10_71_014;
            public const int Err_HasBeenUsedByAccountType_DeleteNotAllowed = -10_71_015;
            public const int Err_HasBeenUsedByFinancialClass_DeleteNotAllowed = -10_71_016;
            public const int Err_HasBeenUsedByMarket_DeleteNotAllowed = -10_71_017;
            public const int Err_HasBeenUsedByAccount_CantChangeStatus = -10_71_018;
            public const int Err_HasBeenUsedByAccountType_CantChangeStatus = -10_71_019;
            public const int Err_HasBeenUsedByFinancialClass_CantChangeStatus = -10_71_020;
            public const int Err_HasBeenUsedByMarket_CantChangeStatus = -10_71_021;
        }

        public static class SA_PositionLimiGroup
        {
            public const int Err_PositionLimitGroupId_Invalid = -10_72_001;
            public const int Err_Status_Invalid = -10_72_002;
            public const int Err_OverrideInstrument_Invalid = -10_72_003;
            public const int Err_InvestorType_Invalid = -10_72_004;
            public const int Err_MarketId_Invalid = -10_72_005;
            public const int Err_UnderlyingId_Invalid = -10_72_006;
            public const int Err_InstrumentId_Invalid = -10_72_007;
            public const int Err_Registration_Invalid = -10_72_008;
            public const int Err_PositionLimitGroupDetail_Dupplicate = -10_72_009;

            public const int Err_HasBeenUsedByAccount_CantChangeStatus = -10_72_010;
            public const int Err_HasBeenUsedByAccountType_CantChangeStatus = -10_72_011;
            public const int Err_HasBeenUsedByServiceClass_CantChangeStatus = -10_72_012;
            public const int Err_HasBeenUsedByMarket_CantChangeStatus = -10_72_013;
            public const int Err_HasBeenUsedByAccount_DeleteNotAllowed = -10_72_014;
            public const int Err_HasBeenUsedByAccountType_DeleteNotAllowed = -10_72_015;
            public const int Err_HasBeenUsedByServiceClass_DeleteNotAllowed = -10_72_016;
            public const int Err_HasBeenUsedByMarket_DeleteNotAllowed = -10_72_017;
        }



        public static class SA_Notification
        {
            public const int Err_Name_Invalid = -10_74_001;
            public const int Err_NameOther_Invalid = -10_74_002;
            public const int Err_RecipientType_Invalid = -10_74_003;
            public const int Err_DefaultReceive_Invalid = -10_74_004;
            public const int Err_ChargeFee_Invalid = -10_74_005;
            public const int Err_ContactType_Invalid = -10_74_006;
            public const int Err_RegistrationType_Invalid = -10_74_007;
            public const int Err_FileType_Invalid = -10_74_008;
            public const int Err_Status_Invalid = -10_74_009;

            public const int Err_SendStatus_Invalid = -10_74_010;
            public const int Err_TempContent_Invalid = -10_74_011;
            public const int Err_TransationtypeId_Invalid = -10_74_012;
            public const int Err_TempFile_Invalid = -10_74_013;
            public const int Err_DefaultLanguage_Invalid = -10_74_014;
            public const int Err_ReadFile = -10_74_015;
            public const int Err_Id_Existed = -10_74_016;
            public const int Err_Notification_Has_Been_Used = -10_74_017;
            public const int Err_Notification_Has_Been_Used_Warning_Change_Status = -10_74_018;
            public const int Err_Notification_Has_Been_Used_Cannot_Delete = -10_74_019;
            public const int Err_ReportCategoryId = -10_74_020;
            public const int Err_UploadFileMinIO = -10_74_021;
        }
        public static class SA_SendNotification
        {
            public const int Err_ContactReportId_Invalid = -10_73_001;
            public const int Err_ContactType_Invalid = -10_73_002;
            public const int Err_AccountId_Invalid = -10_73_003;
            public const int Err_SendStatus_Invalid = -10_73_004;
            public const int Err_Cannot_Find_Record = -10_73_005;
            public const int Err_Error_When_Update = -10_73_006;
            public const int Err_Error_When_Approve = -10_73_007;
            public const int Err_Error_When_Resend = -10_73_008;
            public const int Err_Error_When_Import = -10_73_009;
            public const int Err_Error_When_Delete = -10_73_010;
            public const int Err_Wrong_Export_Condition = -10_73_011;
            public const int Err_Cannot_Find_Notification = -10_73_012;
            public const int Err_Only_Process_Noti_WaitForApproval = -10_73_013;
            public const int Err_Noti_Not_Send_Customer = -10_73_014;
            public const int Err_Account_Not_Register_Get_Notification = -10_73_015;
            public const int Err_When_Generate_Notification_Customer = -10_73_016;
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

        public static class SA_PromotionPeriod
        {
            public const int Err_Name_Invalid = -10_76_001;
            public const int Err_Enable_MaxLength = -10_76_002;
            public const int Err_ProductClass_ValuesInvalid = -10_76_003;
            public const int Err_ProductClass_MaxLength = -10_76_003;
            public const int Err_EffectiveDateFrom_Invalid = -10_76_004;
            public const int Err_EffectiveDateTo_Invalid = -10_76_005;
            public const int Err_FeenatureId_MaxLength = -10_76_006;
            public const int Err_InterestClassId_MaxLength = -10_76_007;
            public const int Err_NewInterestClassid_MaxLength = -10_76_026;
            public const int Err_Method_Value_Invalid = -10_76_008;
            public const int Err_DiscountTypeId_Value_Invalid = -10_76_009;
            public const int Err_Criteria_Value = -10_76_010;
            public const int Err_LoanType_Value = -10_76_011;
            public const int Err_Factor1 = -10_76_012;
            public const int Err_Value1 = -10_76_013;
            public const int Err_Factor2 = -10_76_014;
            public const int Err_Value2 = -10_76_015;
            public const int Err_Factor3 = -10_76_016;
            public const int Err_Value3 = -10_76_017;
            public const int Err_Factor4 = -10_76_018;
            public const int Err_Value4 = -10_76_019;
            public const int Err_Factor5 = -10_76_020;
            public const int Err_Value5 = -10_76_021;
            public const int Err_Description_MaxLength = -10_76_022;
            public const int Err_NameOther_MaxLength = -10_76_023;
            public const int Err_CalculationMethodId_MaxLength = -10_76_024;
            public const int Err_PromotionFiterSetting = -10_76_025;
            public const int Err_NewInterestClassInvalid = -10_76_026;

            public const int Err_PromotionHasBeenUsedIn_TCAccountCashMovementFee = -10_76_027;
            public const int Err_PromotionHasBeenUsedIn_TSAccountInstrumentMovementFee = -10_76_028;
            public const int Err_PromotionHasBeenUsedIn_TPAccountAccruedInterestTransaction = -10_76_029;
            public const int Err_PromotionHasBeenUsedIn_TPAccountAccruedInterest = -10_76_030;
            public const int Err_PromotionHasBeenUsedIn_TPAccountAccuredFee = -10_76_031;
            public const int Err_PromotionHasBeenUsedIn_TCSAccountContractFee = -10_76_032;


            public const int Err_Approve_Record_Change_With_EffectDateTo_Smaller_Than_Busdate = -10_76_099;
            public const int Err_Approve_Record_With_EffectDateFrom_Smaller_Than_Busdate = -10_76_098;
            public const int Err_OldDataChanged = -10_76_097;
            public const int Err_OldDataChildListChanged = -10_76_096;
            public const int Err_Required_IC_Or_FN = -10_76_095;
            public const int Err_Required_Parameter_TransactionTypeInput = -10_76_094;
            public const int Err_Dupplicate_Factor = -10_76_093;
            public const int Err_ParamId = -10_76_092;
            public const int Err_ParamValue = -10_76_091;
        }

        public static class SA_OrderChanel
        {
            public const int Err_SubmitFail = -10_77_004;
        }

        public static class SA_PrintSingleReport
        {
            public const int Err_NoDataQueried = -10_78_001;
            public const int Err_NoTemplate = -10_78_002;
            public const int Err_DRP104_RequireAccountId = -10_78_003;
        }

        public static class SA_BranchGroup
        {
            public const int Err_BranchGroupId = -10_79_001;
            public const int Err_Name = -10_79_002;
            public const int Err_NameOther = -10_79_003;
            public const int Err_Status = -10_79_004;
            public const int Err_BranchGroupDetails = -10_79_005;
            public const int Err_BranchGroupDetails_BranchType = -10_79_006;
            public const int Err_BranchGroupDetails_BranchId = -10_79_007;
            public const int Err_BranchGroupDetails_DepartmentId = -10_79_008;
            public const int Err_BranchGroupDetails_BranchId_existed = -10_79_009;
            public const int Err_BranchGroupDetails_LogicalId_existed = -10_79_010;
            public const int Err_BranchGroupDetails_DepartmentId_existed = -10_79_011;
            public const int Err_BranchGroup_Assigned_To_MCUserAccessibleBranch_Can_Not_Be_Deleted = -10_79_012;
            public const int Err_BranchGroup_Assigned_To_MCUserAccessibleBranch_Can_Not_Be_Updated = -10_79_013;
            public const int Err_BranchGroupDetails_Empty = -10_79_014;
        }
    }
}
