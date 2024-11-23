namespace CommonLib.Constants
{
    public static partial class ErrorCodes
    {
        // Error code phan he CF: -12XXYYY;
        // XX: 2 so the hien bang
        //		+ 00: CFMAST - Thông tin khách hàng
        //		+ 01: COMAST - Thông tin hợp đồng
        //		+ 02: CFADDRESS - Thông tin liên hệ
        //		+ 03: CFREPRESENTER- Thông tin người đại diện
        //		+ 04: CFDOCUMENT - Thông tin chữ ký
        //		+ 05: CFAUTH - Thông tin ủy quyền
        //		+ 06: CFBANKONLINE - Thông tin ngân hàng thanh toán online
        //		+ 07: AFMAST - Thông tin tài khoản giao dịch
        //		+ 08: BANKCFMAST - Thông tin tài khoản chuyển tiền ngân hàng
        //		+ 09: REGISNOTIFICATION - Thông tin đăng ký dịch vụ SMS, Email
        //		+ 10: CFBANKACCOUNT - Thông tin ngân hàng của NĐT
        //		+ 11: CfAuthDocument - Thông tin ủy quyền GD chứng từ 
        //		+ 12: AfSecuritiesRestrict - Thông tin chứng khoán hạn chế của TK
        //		+ 13: CfRegTranferMoney - Thông tin đăng ký hạn mức chuyển tiền
        //		+ 14: CfControlling - Thông tin người giám hộ
        //		+ 15: CfNotification - Thông tin nhận thông báo SMS/Email
        //		+ 16: CfRelation - Thông tin quan hệ khách hàng
        //		+ 17: BrokerRelation - Liên quan môi giới
        //		+ 18: AfInternalMoneyTransfer - Đăng ký chuyển tiền nội bộ khác tên
        //		+ 19: ShortInfoAccount - Danh sách ngắng gọn thông tin tài khoản(f8)
        //		+ 20: AFSUBSTS - SubStatus của tài khoản
        //		+ 21: AfInvestmentTrust - Ủy thác đầu tư
        // YYY: 3 so the hien loi

        public static class CF
        {
            /// <summary>
            /// CFMast - [-12_00_YYY] - Thông tin khách hàng
            /// </summary>
            public static class CfMast
            {
                public const int Err_CustId = -12_00_001;
                public const int Err_SoTKLK = -12_00_002;
                public const int Err_ContractNo = -12_00_003;
                public const int Err_FullName = -12_00_004;
                public const int Err_ShortName = -12_00_005;
                public const int Err_Dob = -12_00_006;
                public const int Err_IdType = -12_00_007;
                public const int Err_IdCode = -12_00_008;
                //public const int Err_FirmCd = -12_00_009;
                public const int Err_IdDate = -12_00_010;
                public const int Err_IdPlace = -12_00_011;
                public const int Err_Address = -12_00_012;
                //public const int Err_AddressContact = -12_00_013;
                //public const int Err_AddressOffice = -12_00_014;
                //public const int Err_AddressOther = -12_00_015;
                //public const int Err_PhoneNoti = -12_00_016;
                public const int Err_Mobile = -12_00_017;
                //public const int Err_HomeTel = -12_00_018;
                //public const int Err_MobileTel = -12_00_019;
                //public const int Err_Fax = -12_00_020;
                public const int Err_AuthenType = -12_00_021;
                //public const int Err_Pin = -12_00_022;
                public const int Err_Email = -12_00_023;
                //public const int Err_EmailNoti = -12_00_024;
                //public const int Err_NotiLang = -12_00_025;
                public const int Err_Country = -12_00_026;
                public const int Err_Province = -12_00_027;
                //public const int Err_PostCode = -12_00_028;
                //public const int Err_Resident = -12_00_029;
                //public const int Err_CFClass = -12_00_030;
                //public const int Err_GrInvestor = -12_00_031;
                public const int Err_TradingCode = -12_00_032;
                public const int Err_TradingCodeIssuePlace = -12_00_033;
                public const int Err_TradingCodeDate = -12_00_034;
                public const int Err_ResidentCard = -12_00_035;
                public const int Err_ResidentCardActive = -12_00_036;
                public const int Err_ResidentCardExpire = -12_00_037;
                //public const int Err_StaffRelatedAc = -12_00_038;
                //public const int Err_StaffRelatedId = -12_00_039;
                public const int Err_ReferType = -12_00_040;
                public const int Err_ReferBy = -12_00_041;
                public const int Err_ReferExpire = -12_00_042;
                public const int Err_CustodyCd = -12_00_043;
                //public const int Err_Staff = -12_00_044;
                public const int Err_CompanyId = -12_00_045;
                //public const int Err_Position = -12_00_046;
                public const int Err_Gender = -12_00_047;
                //public const int Err_Sector = -12_00_048;
                //public const int Err_BusinessType = -12_00_049;
                //public const int Err_TradeFloor = -12_00_050;
                //public const int Err_TradeTelephone = -12_00_051;
                //public const int Err_TradeOnline = -12_00_052;
                //public const int Err_TradePhone = -12_00_053;
                public const int Err_BranchId = -12_00_054;
                public const int Err_DpId = -12_00_055;
                public const int Err_BrokerId = -12_00_056;
                //public const int Err_Language = -12_00_057;
                //public const int Err_Married = -12_00_058;
                public const int Err_FATCA = -12_00_059;
                //public const int Err_IsCheckPw = -12_00_060;
                //public const int Err_TradingType = -12_00_061;
                public const int Err_CFType = -12_00_062;
                public const int Err_OpnVia = -12_00_063;
                public const int Err_OpnDate = -12_00_064;
                public const int Err_CloseDate = -12_00_065;
                //public const int Err_RecvSms = -12_00_066;
                //public const int Err_RecvEmail = -12_00_067;
                public const int Err_Tax = -12_00_068;
                public const int Err_TaxCode = -12_00_069;
                //public const int Err_CheckLimitTranMoney = -12_00_070;
                public const int Err_DocumentSts = -12_00_071;
                public const int Err_DocDate = -12_00_072;
                public const int Err_IdExpired = -12_00_073;
                public const int Err_Description = -12_00_074;
                public const int Err_VSDSts = -12_00_075;
                public const int Err_VSDActDate = -12_00_076;
                public const int Err_VSDCloseDate = -12_00_077;
                public const int Err_RecordStatus = -12_00_078;
                public const int Err_RejectDes = -12_00_079;
                //public const int Err_Education = -12_00_080;
                //public const int Err_FoundingDate = -12_00_081;

                public const int Err_FullNameOrther = -12_00_082;
                public const int Err_Omnibusun = -12_00_083;
                public const int Err_Omnibusde = -12_00_084;
                public const int Err_Custodian = -12_00_085;
                public const int Err_MutualFund = -12_00_086;
                public const int Err_AssetManagement = -12_00_087;
                public const int Err_EnableSubAccount = -12_00_088;
                public const int Err_PlaceOfBirth = -12_00_089;
                public const int Err_ResidentCountry = -12_00_090;
                public const int Err_BrokerCare = -12_00_091;
                public const int Err_EnableeditBroker = -12_00_092;
                public const int Err_Pwdtran = -12_00_093;
                public const int Err_Proinvest = -12_00_094;
                public const int Err_RelatedStaffId = -12_00_095;
                public const int Err_Vsdsts = -12_00_096;
                public const int Err_VsdDescription = -12_00_097;
                public const int Err_AuthDocument = -12_00_098;
                public const int Err_Clearing = -12_00_099;
                public const int Err_ResidentId = -12_00_100;
                public const int Err_ResidentIdPlace = -12_00_101;
                public const int Err_Proinvestde = -12_00_102;
                public const int Err_Isrecvsms = -12_00_103;
                public const int Err_IsrecvEmail = -12_00_104;
                public const int Err_Suspendsms = -12_00_105;
                public const int Err_SuspendEmail = -12_00_106;
                public const int Err_Descriptionother = -12_00_107;
                public const int Err_IdCode_Symbol = -12_00_108;
                public const int Err_IsControlling = -12_00_109;
                public const int Err_ResidentType = -12_00_110;
                public const int Err_CustodyCdLength = -12_00_111;
                public const int Err_IdType_CaNhan = -12_00_112;
                public const int Err_ResidentType_RuleInput = -12_00_113;
                public const int Err_ResidentCard_RuleInput = -12_00_114;
                public const int Err_ResidentCardActive_RuleInput = -12_00_115;
                public const int Err_ResidentIdPlace_RuleInput = -12_00_116;
                public const int Err_ResidentCardExpire_RuleInput = -12_00_117;
                public const int Err_Country_RuleTrongNuoc = -12_00_118;
                public const int Err_Gender_BatBuocVoiCaNhan = -12_00_119;
                public const int Err_TaxCode_Required = -12_00_120;
                public const int Err_ResidentCountry_CheckNuocNgoai = -12_00_121;
                public const int Err_CustodyCd_MemberTrade = -12_00_122;
                public const int Err_CustodyCd_Last6Digit = -12_00_123;
                public const int Err_CustodyCd_PcfFlag = -12_00_124;
                public const int Err_BrokerId_ChangeWhenDataActivated = -12_00_125;
                public const int Err_RegisteredCapital = -12_00_126;
                public const int Err_CfAddresses_Only1Default1AddType = -12_00_127;
                public const int Err_ApproveSelfData = -12_00_128;
                public const int Err_CancelOtherData = -12_00_129;
                public const int Err_Status = -12_00_130;

                public const int Err_Table_IssuerMember = -12_00_131;
                public const int Err_Table_CfAuth = -12_00_132;
                public const int Err_Table_CfControlling = -12_00_133;
                public const int Err_Table_CfAuthDocument = -12_00_134;
                public const int Err_Table_SmsNotification = -12_00_135;
                public const int Err_Table_EmailNotification = -12_00_136;
                public const int Err_Table_CfRepresenter = -12_00_137;
                public const int Err_Table_BrokerRelation = -12_00_138;
                public const int Err_Table_SignStamps = -12_00_139;
                public const int Err_Table_CfAddress = -12_00_140;

                // == Loi nghiep vu, rang buoc giua cac dong
                public const int Err_IdCode_Duplicate = -12_00_899;
                public const int Err_TradingCode_Duplicate = -12_00_898;
                public const int Err_CustodyCd_Duplicate = -12_00_897;
                public const int Err_CustodyCd_Invalid = -12_00_896;
                public const int Err_FirmCd_Duplicate = -12_00_895;
                public const int Err_ContractNo_Duplicate = -12_00_894;
                public const int Err_Mobile_DuplicateWithBroker = -12_00_893;
                public const int Err_Email_DuplicateWithBroker = -12_00_892;
                public const int Err_Mobile_Duplicate = -12_00_891;

                public const int Err_PendingExisted = -12_00_890;
                public const int Err_AutoId = -12_00_889;
                public const int Err_RefAutoId = -12_00_888;
                public const int Err_CFId = -12_00_887;
                public const int Err_CustId_Duplicate = -12_00_886;
                public const int Err_OperateAccount = -12_00_885;

                public const int Err_CannotChangeCustId = -12_00_884;
                public const int Err_DeleteCustomerHasAccount = -12_00_883;

                // Loi cac bang lien quan

                /// <summary>
                /// Không nhập thông tin hợp đồng
                /// </summary>
                public const int Err_ThongTinHopDong = -12_00_999;
                /// <summary>
                /// Không nhập thông tin người đại diện đối với NDT Tổ chức
                /// </summary>
                public const int Err_ThongTinNguoiDaiDien = -12_00_998;
                /// <summary>
                /// Không nhập thông tin chữ ký
                /// </summary>
                public const int Err_ThongTinChuKy = -12_00_997;
                /// <summary>
                /// Không nhập thông tin ủy quyền đối với NDT Tổ chức
                /// </summary>
                public const int Err_ThongTinUyQuyen = -12_00_996;
                public const int Err_ThongTinLienHe = -12_00_995;
                public const int Err_ThongTinNganHang = -12_00_994;
                public const int Err_ThongTinThanhVienTCPH = -12_00_993;
                public const int Err_ThongTinChungTu = -12_00_992;
                public const int Err_ThongTinDangKyDichVuSMSEmail = -12_00_991;
                public const int Err_ThongTinUyQuyenGNChungTu = -12_00_990;

                /// <summary>
                /// Không nhập thông tin người giám hộ đối với NDT >=15 <18 tuôi
                /// </summary>
                public const int Err_ThongTinNguoiGiamHo = -12_00_989;
                public const int Err_ThongTinQuanHeKhachHang = -12_00_988;
                public const int Err_ThongTinUyQuyenNum = -12_00_987;

                public const int Err_AddType = -12_00_986;
                public const int Err_AddTypeIsDefaul = -12_00_985;

                public const int Err_AddTimeAuth = -12_00_984;
                public const int Err_UpdateTimeAuth = -12_00_983;
                /// <summary>
                /// Chu ky con dau
                /// </summary>
                public const int Err_ThongTinChuKyConDau = -12_00_982;

                /// <summary>
                /// Thong tin lỗi các bảng liên quan
                /// </summary>
                public const int Err_ThongTinUyQuyenDes = -12_00_981;
                public const int Err_ThongTinLienHeDes = -12_00_980;
                public const int Err_ThongTinThanhVienTCPHDes = -12_00_978;
                public const int Err_ThongTinChungTuDes = -12_00_977;
                public const int Err_ThongTinDangKyDichVuSMSEmailDes = -12_00_976;
                public const int Err_ThongTinUyQuyenGNChungTuDes = -12_00_975;
                public const int Err_ThongTinChuKyConDauDes = -12_00_974;
                public const int Err_ThongTinNguoiDaiDienDes = -12_00_973;
                public const int Err_ThongTinChuKyDes = -12_00_972;
                public const int Err_ThongTinQuanHeKhachHangDes = -12_00_971;
                public const int Err_ThongTinNguoiGiamHoDes = -12_00_970;
                public const int Err_Representer_RuleNhapDuLieu = -12_00_969;
                public const int Err_SignStamps = -12_00_968;
            }

            /// <summary>
            /// COMast - [-12_01_YYY] - Thông tin hợp đồng
            /// </summary>
            public static class COMast
            {
                public const int Err_CoNum = -12_01_001;
                public const int Err_CustId = -12_01_002;
                public const int Err_Manty = -12_01_003;
                public const int Err_DeAccno = -12_01_004;
                public const int Err_TradeAccno = -12_01_005;
                public const int Err_DeStatus = -12_01_006;
                public const int Err_TeStatus = -12_01_007;
                public const int Err_AssetManager = -12_01_008;
                public const int Err_MutualFun = -12_01_009;
                public const int Err_Custodian = -12_01_010;
                public const int Err_Omnibus = -12_01_011;
                public const int Err_AucSessionTradeAllow = -12_01_012;
                public const int Err_CoType = -12_01_013;
                public const int Err_AcType = -12_01_014;
                public const int Err_MapBank = -12_01_015;
                public const int Err_BankId = -12_01_016;
                public const int Err_Bankno = -12_01_017;
                public const int Err_FeeId = -12_01_018;
                public const int Err_LnId = -12_01_019;
                public const int Err_AdvId = -12_01_020;
                public const int Err_ClId = -12_01_021;
                public const int Err_Marginline = -12_01_022;
                public const int Err_Advanceline = -12_01_023;
                public const int Err_Depositline = -12_01_024;
                public const int Err_Repoline = -12_01_025;
                public const int Err_Mortgageline = -12_01_026;
                public const int Err_TeleLimit = -12_01_027;
                public const int Err_Description = -12_01_028;
                public const int Err_Status = -12_01_029;
                public const int Err_AutoId = -12_01_030;
                public const int Err_RefAutoId = -12_01_031;
                public const int Err_CoId = -12_01_032;
                public const int Err_RejectNum = -12_01_033;
                public const int Err_RejectDes = -12_01_034;

                // Loi cac bang lien quan
                public const int Err_ThongTinTaiKhoan = -12_01_999;
                public const int Err_ThongTinUyQuyen = -12_01_998;
                public const int Err_ThongTinNganHang = -12_01_997;
                public const int Err_ThongTinChungTu = -12_01_996;
                public const int Err_PendingExisted = -12_01_995;

            }


            /// <summary>
            /// CFRepresenter - [-12_03_YYY] - Thông tin người đại diện
            /// </summary>
            public static class CFRepresenter
            {
                public const int Err_CFRepresentId = -12_03_001;
                public const int Err_CustId = -12_03_002;
                public const int Err_RefCustId = -12_03_003;
                public const int Err_Name = -12_03_004;
                public const int Err_NameEn = -12_03_005;
                public const int Err_Dob = -12_03_006;
                public const int Err_Country = -12_03_007;
                public const int Err_Gender = -12_03_008;
                public const int Err_IdType = -12_03_009;
                public const int Err_IdCode = -12_03_010;
                public const int Err_IdDate = -12_03_011;
                public const int Err_IdPlace = -12_03_012;
                public const int Err_IdExpired = -12_03_013;
                public const int Err_Address1 = -12_03_014;
                public const int Err_Address2 = -12_03_015;
                public const int Err_Address3 = -12_03_016;
                public const int Err_Address4 = -12_03_017;
                public const int Err_HomePhone = -12_03_018;
                public const int Err_Mobile = -12_03_019;
                public const int Err_Email = -12_03_020;
                public const int Err_LegalRepresentType = -12_03_021;
                public const int Err_DocumentNo = -12_03_022;
                public const int Err_Description = -12_03_023;
                public const int Err_Signs = -12_03_024;
                public const int Err_Position = -12_03_025;
                public const int Err_ShortName = -12_03_026;
                public const int Err_Nationality = -12_03_027;
                public const int Err_LegalPresentType = -12_03_028;
                public const int Err_LinkData = -12_03_029;
                public const int Err_AgeMustGreaterThanOrEqual18 = -12_03_030;
                //
                public const int Err_DataExisted = -12_03_999;
            }





            /// <summary>
            /// CFBankOnline - [-12_06_YYY] - Thông tin ngân hàng thanh toán online
            /// </summary>
            public static class CFBankOnline
            {
                /// <summary>
                /// Mã khách hàng
                /// </summary>
                public const int Err_MaKH = -12_06_001;
                /// <summary>
                /// Mã ngân hàng
                /// </summary>
                public const int Err_MaNganHang = -12_06_002;
                /// <summary>
                /// Chi nhánh ngân hàng
                /// </summary>
                public const int Err_ChiNhanh = -12_06_003;
                /// <summary>
                /// Số TK ngân hàng
                /// </summary>
                public const int Err_SoTK = -12_06_004;
                /// <summary>
                /// Tên chủ tài khoản ngân hàng
                /// </summary>
                public const int Err_TenChuTK = -12_06_005;
            }

            /// <summary>
            /// BankCFMast - [-12_08_YYY] - Thông tin tài khoản chuyển tiền ngân hàng
            /// </summary>
            public static class BankCFMast
            {
                public const int Err_CustId = -12_08_001;
                public const int Err_COAutoId = -12_08_002;
                public const int Err_CoNum = -12_08_003;
                public const int Err_BankNo = -12_08_004;
                public const int Err_BankId = -12_08_005;
                public const int Err_BranchId = -12_08_006;
                public const int Err_IsMaster = -12_08_007;
                public const int Err_FullName = -12_08_008;
                public const int Err_LimitInday = -12_08_009;
                public const int Err_LimitIntran = -12_08_010;
                public const int Err_Description = -12_08_011;
                public const int Err_Status = -12_08_012;

                public const int Err_BankNo_Duplicate = -12_08_980;
            }
        }

        /// <summary>
        /// AfMast - [-12_07_YYY] - Thông tin tài khoản giao dịch
        /// </summary>
        public static class CF_AfMast
        {
            public const int Err_AutoId = -1207001;
            public const int Err_RefAutoId = -1207002;
            public const int Err_AfMastId = -1207003;
            public const int Err_CfAutoId = -1207004;
            public const int Err_CustodyCd = -1207005;
            public const int Err_CustId = -1207006;
            public const int Err_IsParent = -1207007;
            public const int Err_IsParentText = -1207008;
            public const int Err_AccountTypeId = -1207009;
            public const int Err_MantyText = -1207010;
            public const int Err_AfAccNo = -1207011;
            public const int Err_SubAccNum = -1207012;
            public const int Err_GroupOpenAccNo = -1207013;
            public const int Err_Name = -1207014;
            public const int Err_NameOther = -1207015;
            public const int Err_AeId = -1207016;
            public const int Err_BrokerName = -1207017;
            public const int Err_BranchId = -1207018;
            public const int Err_BranchName = -1207019;
            public const int Err_CustodianAccountType = -1207020;
            public const int Err_AssetManagementCompany = -1207021;
            public const int Err_ShareholderCode = -1207022;
            public const int Err_BlacklistFlag = -1207023;
            public const int Err_CheckAvailableBalFlag = -1207024;
            public const int Err_CheckAvailableStockFlag = -1207025;
            public const int Err_AutoCia = -1207026;
            public const int Err_ManualCia = -1207027;
            public const int Err_IdType = -1207028;
            public const int Err_IdTypeText = -1207029;
            public const int Err_IdNumber = -1207030;
            public const int Err_IdIssueDate = -1207031;
            public const int Err_IdIssuePlace = -1207032;
            public const int Err_IdExpiryDate = -1207033;
            public const int Err_FiiaFlag = -1207034;
            public const int Err_BankId = -1207035;
            public const int Err_BankName = -1207036;
            public const int Err_Clearing = -1207037;
            public const int Err_DeAccount = -1207038;
            public const int Err_DeTradeAccount = -1207039;
            public const int Err_DeStatus = -1207040;
            public const int Err_TeStatus = -1207041;
            public const int Err_IsCommission = -1207042;
            public const int Err_TrustCompany = -1207043;
            public const int Err_CheckPower = -1207044;
            public const int Err_OpnDate = -1207045;
            public const int Err_ActiveDate = -1207046;
            public const int Err_SuspendDate = -1207047;
            public const int Err_CloseDate = -1207048;
            public const int Err_IsRecvSms = -1207049;
            public const int Err_IsRecvEmail = -1207050;
            public const int Err_SuspendSms = -1207051;
            public const int Err_SuspendEmail = -1207052;
            public const int Err_ReferType = -1207053;
            public const int Err_ReferTypeText = -1207054;
            public const int Err_ReferBy = -1207055;
            public const int Err_ReferExpiryDate = -1207056;
            public const int Err_FeeGrpId = -1207057;
            public const int Err_FeeGrpName = -1207058;
            public const int Err_FeeGrpServiceId = -1207059;
            public const int Err_FeeGrpServiceName = -1207060;
            public const int Err_LnId = -1207061;
            public const int Err_AdvId = -1207062;
            public const int Err_ClId = -1207063;
            public const int Err_MarginLine = -1207064;
            public const int Err_AdvanceLine = -1207065;
            public const int Err_DepositLine = -1207066;
            public const int Err_RepoLine = -1207067;
            public const int Err_Mortgageline = -1207068;
            public const int Err_TeleLimit = -1207069;
            public const int Err_BlockCash = -1207070;
            public const int Err_Description = -1207071;
            public const int Err_Status = -1207072;
            public const int Err_StatusText = -1207073;
            public const int Err_Deleted = -1207074;
            public const int Err_CreateBy = -1207075;
            public const int Err_CreateDate = -1207076;
            public const int Err_LastChangeBy = -1207077;
            public const int Err_LastChangeDate = -1207078;
            public const int Err_ApproveBy = -1207079;
            public const int Err_ApproveDate = -1207080;
            public const int Err_RejectNum = -1207081;
            public const int Err_RejectDes = -1207082;
            public const int Err_Action = -1207083;
            public const int Err_Auths = -1207084;
            public const int Err_LastTradingDate = -1207085;
            public const int Err_Contacts = -1207086;
            public const int Err_BankAccounts = -1207087;
            public const int Err_SecuritiesRestricts = -1207088;
            public const int Err_RegTranferMoneys = -1207089;
            public const int Err_Address = -1207090;
            public const int Err_Mobile = -1207091;
            public const int Err_Email = -1207092;
            public const int Err_CurrencyCd = -1207093;
            public const int Err_InterestId = -1207094;
            public const int Err_Notifications = -1207095;
            public const int Err_AuthDocument = -1207096;
            public const int Err_CfAuthDocuments = -1207097;
            public const int Err_MapBankHasOneBankAccount = -1207098;
            public const int Err_FiiaAccOfForeignCustomer = -1207099;
            public const int Err_OmnibusDFlag = -1207100;
            public const int Err_InternalMoneyTransfers = -1207101;
            //
            public const int Err_TabName_Auths = -1207102;
            public const int Err_TabName_AuthDocuments = -1207103;
            public const int Err_TabName_Contacts = -1207104;
            public const int Err_TabName_BankAccounts = -1207105;
            public const int Err_TabName_SecuritiesRestricts = -1207106;
            public const int Err_TabName_RegTranferMoneys = -1207107;
            public const int Err_TabName_SmsNotifications = -1207108;
            public const int Err_TabName_InternalMoneyTransfers = -1207109;
            //
            public const int Err_Auth_CaNhanChiNhap1UyQuyen = -1207110;
            public const int Err_Auth_ThoiGianTrungNhau = -1207111;
            public const int Err_Auth_ThoiGianTrungNhauTrenCungDKSH = -1207112;
            public const int Err_Auth_LoiSuaXoaUQHetHieuLuc = -1207113;
            public const int Err_TabName_AfSubSts = -1207114;
            public const int Err_BankAccounts_RuleNhapOnlineTransfer = -1207115;
            public const int Err_BankAccounts_RuleNhapCashAtBank = -1207116;
            public const int Err_BankAccounts_RuleNhapFIIA = -1207117;
            public const int Err_InternalMoneyTransfers_RuleNhap = -1207118;
            public const int Err_BankAccounts_DuplicateIsDefault = -1207119;
            public const int Err_IdCode_Existed = -1207120;
            public const int Err_MustHasNnAccountBeforeDeAccount = -1207121;
            public const int Err_NameOfFiiaBankAccOfForeignCustomer = -1207122;
            public const int Err_BankAccounts_TCIWithoutFIIA = -1207123;
            public const int Err_BankAccounts_TCIWithFIIA_MarginContract = -1207124;
            public const int Err_BankAccounts_TCIWithFIIA_ForeignCustomer = -1207125;
            public const int Err_BankAccounts_TCOWithoutFIIA_MarginContract = -1207126;
            public const int Err_BankAccounts_TCOWithoutFIIA = -1207127;
            public const int Err_BankAccounts_TOOWithoutFIIA_MarginContract = -1207128;
            public const int Err_BankAccounts_TOOWithoutFIIA = -1207129;
            public const int Err_BrokerId_ChangeWhenDataActivated = -1207130;
            public const int Err_Contacts_Only1Default1AddType = -1207131;
            public const int Err_BankAccounts_ForeignCustomerAndResidentExpiredInputOnlineTransfer = -1207132;
            public const int Err_ApproveSelfData = -1207133;
            public const int Err_CancelOtherData = -1207134;

            public const int Err_AccountStatus = -1207135;
            public const int Err_VsdStatus = -1207136;
            public const int Err_SuspendExpiryDate = -1207137;
            //public const int Err_DepositoryMember = -1207138;
            public const int Err_BeneficialAccount = -1207139;
            public const int Err_DocumentClose = -1207140;
            public const int Err_AccountClosingReasonId = -1207141;
            public const int Err_CloseFee = -1207142;
            public const int Err_AccountFee = -1207143;
            public const int Err_FeeCurrencyCd = -1207144;
            public const int Err_SubStatus = -1207145;
            public const int Err_SubStatusVsd = -1207146;
            public const int Err_AccountStatusDescription = -1207147;
            public const int Err_CommissionDescription = -1207148;

            public const int Err_TabName_InvestmentTrusts = -1207149;
            public const int Err_InvestmentTrusts_ThoiGianTrungNhau = -1207150;
            public const int Err_DongTKPSSub1KhiChuaDongSubN = -1207151;
            public const int Err_DongTKCashSub1KhiChuaDongCacTKSubKhac = -1207152;

            public const int Err_DongTKCashSub1QuaVSDKhiChuaDongCacTKSubKhac = -1207153;
            public const int Err_MoLaiTKKhiChuaCoTKCashSub1 = -1207154;
            public const int Err_MoLaiTKPSSubNKhiChuaCoTKPSSub1 = -1207155;
            public const int Err_MoLaiTKPSKhiVSDChuaDongY = -1207156;
            public const int Err_MoLaiTKCashSub1VoiLoaiTKLK2vs3 = -1207157;

            public const int Err_KhachHangChuaDuocDuyet = -1207158;
            public const int Err_ThayDoiTrangThaiKhiChuaDuocVSDChapNhan = -1207159;
            public const int Err_XoaTaiKhoanDaGuiDienLenVSD = -1207160;

            public const int Err_TabName_EmailNotifications = -1207161;

            public const int Err_IsManageTradingCode = -1207162;
            public const int Err_IsCanceledTradingCode = -1207163;
            public const int Err_ValidDateTradingCode = -1207164;
            public const int Err_TradingCodeDocumentStatusId = -1207165;
            public const int Err_TradingCodeManagingFirmId = -1207166;
            public const int Err_EffectiveDateTradingCode = -1207167;
            public const int Err_IsCloseDocument = -1207168;
            public const int Err_FeeCurrencyId = -1207169;
            public const int Err_CloseDescription = -1207170;
            public const int Err_OrderCheckingGroupId = -1207172;

            public const int Err_MappingCorpBondIsEnable = -1207173;
            public const int Err_MappingCorpBondGwRecordStatus = -1207174;
            public const int Err_MappingGovBondIsEnable = -1207175;
            public const int Err_MappingGovBondGwRecordStatus = -1207176;
            public const int Err_MappingStockIsEnable = -1207177;
            public const int Err_MappingStockGwRecordStatus = -1207178;
            public const int Err_MappingDerIsEnable = -1207179;
            public const int Err_MappingDerGwRecordStatus = -1207180;

            public const int Err_AccountClassId = -1207181;
            public const int Err_ServiceClassId = -1207182;
            public const int Err_FinancialClassId = -1207183;
            public const int Err_TradingFeeClassId = -1207184;

            public const int Err_ServiceFeeSettings = -1207185;
            public const int Err_ServiceFeeSettings_FeeNatureId = -1207186;
            public const int Err_ServiceFeeSettings_CalculationMethodId = -1207187;

            public const int Err_TradingFeeSettings = -1207188;
            public const int Err_TradingFeeSettings_FeeNatureId = -1207189;
            public const int Err_TradingFeeSettings_CalculationMethodId = -1207190;

            public const int Err_DebitInterestClassId = -1207191;
            public const int Err_CreditSSIInterestClassId = -1207192;
            public const int Err_CreditVSDInterestClassId = -1207193;
            public const int Err_PositionLimitGroupId = -1207194;

            public const int Err_UnderlyingMarginSettings = -1207195;
            public const int Err_UnderlyingMarginSettings_UnderlyingId = -1207196;
            public const int Err_UnderlyingMarginSettings_Risk = -1207197;
            public const int Err_UnderlyingMarginSettings_Rsc = -1207198;
            public const int Err_UnderlyingMarginSettings_Ppc = -1207199;
            public const int Err_UnderlyingMarginSettings_Spread = -1207200;
            public const int Err_UnderlyingMarginSettings_Minimum = -1207201;

            public const int Err_UnderlyingDeliveryMarginRatios = -1207202;
            public const int Err_UnderlyingDeliveryMarginRatios_Ex = -1207203;
            public const int Err_UnderlyingDeliveryMarginRatios_BuyRatio = -1207204;
            public const int Err_UnderlyingDeliveryMarginRatios_SellRatio = -1207205;
            public const int Err_UnderlyingDeliveryMarginRatios_UnderlyingId = -1207206;

            public const int Err_ServiceFeeSettings_UserCantCalculationMethodId = -1207207;
            public const int Err_TradingFeeSettings_UserCantCalculationMethodId = -1207208;

            public const int Err_AccountSubStatuses_SubStatusCodeNotExisted = -1207209;

            public const int Err_AccountInterfaces = -1207210;
            public const int Err_AccountRegisteredAccount = -1207211;
            public const int Err_OpenVia = -1207212;
            public const int Err_DescriptionOther = -1207213;
            public const int Err_EffectiveDate = -1207214;

            public const int Err_MarketIds = -1207215;
            public const int Err_LocationId = -1207216;
            public const int Err_MarketUnderlyings = -1207217;
            public const int Err_MarketUnderlyings_UnderlyingId = -1207218;
            public const int Err_MarketUnderlyings_AggreementAsigned = -1207219;
            public const int Err_MarketUnderlyings_EffectiveDate = -1207220;
            public const int Err_MarketUnderlyings_ExpiryDate = -1207221;

            public const int Err_AccountClosingFee = -1207222;
            public const int Err_CannotChangeAccountStatusFromClosedToSuspend = -1207223;

            // ===
            public const int Err_HasNoActivatedAccountSub1 = -1207980;
            public const int Err_InhouseApi_RuleCallApiOmnibus = -1207981;
            public const int Err_CancelSub1HasSubN = -1207982;
            public const int Err_AfAccNo_Existed = -1207983;
            public const int Err_CustId_NotExisted = -1207984;
            public const int Err_ActiveCustomerNotExist = -1207985;
            public const int Err_ActiveCashAccountNotExist = -1207986;
            public const int Err_LessThan18NotHasControllingPerson = -1207987;
            public const int Err_LessThan18CannotOpenPS = -1207988;
            public const int Err_LessThan15 = -1207989;
            public const int Err_MapBankAndCustodianCannotOpenMgAccount = -1207990;
            public const int Err_Sub1AccountInvalid = -1207991;
            public const int Err_MustHasTciAccountBeforeMgAccount = -1207992;
            public const int Err_HasSubNCannotDeleteSub1 = -1207993;

            //
            public const int Err_PendingExisted = -1207999;
        }


        /// <summary>
        /// CFADDRESS - [-12_02_YYY] - Thông tin liên hệ
        /// </summary>
        public static class CF_CfAddress
        {
            public const int Err_CfAddressId = -1202001;
            public const int Err_CfAutoId = -1202002;
            public const int Err_CustId = -1202003;
            public const int Err_AfAutoId = -1202004;
            public const int Err_AfAccNo = -1202005;
            public const int Err_AddType = -1202006;
            public const int Err_InfoType = -1202007;
            public const int Err_Contact = -1202008;
            public const int Err_ContactOther = -1202009;
            public const int Err_Country = -1202010;
            public const int Err_FaxAttention = -1202011;
            public const int Err_Description = -1202012;
            public const int Err_Deleted = -1202013;
            public const int Err_CreateBy = -1202014;
            public const int Err_CreateDate = -1202015;
            public const int Err_LastChangeBy = -1202016;
            public const int Err_LastChangeDate = -1202017;
            public const int Err_ApproveBy = -1202018;
            public const int Err_ApproveDate = -1202019;
            public const int Err_DataType = -1202020;
            public const int Err_Status = -1202021;
            public const int Err_IsDefault = -1202022;
            public const int Err_IsInheritance = -1202023;
            public const int Err_InheritanceCfAddressId = -1202024;
            public const int Err_IsOverride = -1202025;
            public const int Err_DeleteAddressWasInherited = -1202026;
        }

        /// <summary>
        /// CFDocument - [-12_04_YYY] - Thông tin chữ ký
        /// </summary>
        public static class CF_CfDocument
        {
            public const int Err_CfDocId = -1204001;
            public const int Err_CfAutoId = -1204002;
            public const int Err_AfAutoId = -1204003;
            public const int Err_AfAccNo = -1204004;
            public const int Err_CustId = -1204005;
            public const int Err_CustName = -1204006;
            public const int Err_CfRepresentId = -1204007;
            public const int Err_CfAuthId = -1204008;
            public const int Err_Description = -1204009;
            public const int Err_CfGroupSign = -1204010;
            public const int Err_CfGroupSignText = -1204011;
            public const int Err_DataType = -1204012;
            public const int Err_DataTypeText = -1204013;
            public const int Err_DocType = -1204014;
            public const int Err_PathSign = -1204015;
            public const int Err_FileName = -1204016;
            public const int Err_FileSize = -1204017;
            public const int Err_Status = -1204018;
            public const int Err_StatusText = -1204019;
            public const int Err_Deleted = -1204020;
            public const int Err_CreateBy = -1204021;
            public const int Err_CreateDate = -1204022;
            public const int Err_LastChangeBy = -1204023;
            public const int Err_LastChangeDate = -1204024;
            public const int Err_ApproveBy = -1204025;
            public const int Err_ApproveDate = -1204026;
        }

        /// <summary>
        /// CFAuth - [-12_05_YYY] - Thông tin ủy quyền
        /// </summary>
        public static class CF_CfAuth
        {
            public const int Err_CfAuthId = -1205001;
            public const int Err_PrCfAuthId = -1205002;
            public const int Err_CfAutoId = -1205003;
            public const int Err_AfAutoId = -1205004;
            public const int Err_AuthType = -1205005;
            public const int Err_CustId = -1205006;
            public const int Err_RefCustId = -1205007;
            public const int Err_AfAccNo = -1205008;
            public const int Err_Name = -1205009;
            public const int Err_OtherName = -1205010;
            public const int Err_Position = -1205011;
            public const int Err_Address = -1205012;
            public const int Err_Phone = -1205013;
            public const int Err_Email = -1205014;
            public const int Err_Mobile = -1205015;
            public const int Err_MobileTel = -1205016;
            public const int Err_Country = -1205017;
            public const int Err_IdType = -1205018;
            public const int Err_IdCode = -1205019;
            public const int Err_IdDate = -1205020;
            public const int Err_IdPlace = -1205021;
            public const int Err_IdExpiryDate = -1205022;
            public const int Err_IsExpiry = -1205023;
            public const int Err_ValDate = -1205024;
            public const int Err_ExpDate = -1205025;
            public const int Err_Status = -1205026;
            public const int Err_Deleted = -1205027;
            public const int Err_CreateBy = -1205028;
            public const int Err_CreateDate = -1205029;
            public const int Err_LastChangeBy = -1205030;
            public const int Err_LastChangeDate = -1205031;
            public const int Err_ApproveBy = -1205032;
            public const int Err_ApproveDate = -1205033;
            public const int Err_Signs = -1205034;
            public const int Err_AuthScopes = -1205035;
            public const int Err_Description = -1205036;
            public const int Err_ContractSignDate = -1205037;
            public const int Err_ContractCreateDate = -1205038;
            public const int Err_ControlType = -1205039;
            public const int Err_ContractCancelDate = -1205040;
            public const int Err_IsInheritance = -1205041;
            public const int Err_IdExpiryDateCompare = -1205042;
            public const int Err_Expiredsts = -1205043;

            public const int Err_CheckDelete_ToChuc = -1205044;
            public const int Err_CheckDelete_CaNhan = -1205045;
            public const int Err_CheckUpdate = -1205046;
            public const int Err_CheckCreater = -1205047;

            public const int Err_ValDateLessThanContractCreateDate = -1205048;
            public const int Err_ExpDateLessThanValDate = -1205049;

            public const int Err_InheritanceCfAuthId = -1205050;
            public const int Err_IsOverride = -1205051;
            public const int Err_DeleteAuthWasInherited = -1205052;

            //
            public const int Err_DataExisted = -1205999;

        }

        /// <summary>
        /// CfAuthDocument - [-12_11_YYY] - Thông tin ủy quyền GD chứng từ 
        /// </summary>
        public static class CF_CfAuthDocument
        {
            public const int Err_CustId = -1211001;
            public const int Err_Name = -1211002;
            public const int Err_CfAutoId = -1211003;
            public const int Err_NameOther = -1211004;
            public const int Err_Email = -1211005;
            public const int Err_Mobile = -1211006;
            public const int Err_Address = -1211007;
            public const int Err_LinkDoc1 = -1211008;
            public const int Err_LinkDoc2 = -1211009;
            public const int Err_LinkDoc3 = -1211010;
            public const int Err_Description = -1211011;
            public const int Err_Status = -1211012;
            public const int Err_DataExisted = -1211999;
        }

        /// <summary>
        /// AfSecuritiesRestrict - [-12_12_YYY] - Thông tin ủy quyền GD chứng từ 
        /// </summary>
        public static class CF_AfSecuritiesRestrict
        {
            public const int Err_AfRestrictId = -1212001;
            public const int Err_AfAutoId = -1212002;
            public const int Err_AfAccNo = -1212003;
            public const int Err_Symbol = -1212004;
            public const int Err_AllowToBuy = -1212005;
            public const int Err_AllowToSell = -1212006;
            public const int Err_FromDate = -1212007;
            public const int Err_ToDate = -1212008;
            public const int Err_Status = -1212009;
            public const int Err_Description = -1212010;
            public const int Err_Deleted = -1212011;
            public const int Err_Createby = -1212012;
            public const int Err_Createdate = -1212013;
            public const int Err_Lastchangeby = -1212014;
            public const int Err_Lastchangedate = -1212015;
            public const int Err_Approveby = -1212016;
            public const int Err_Approvedate = -1212017;
            //
            public const int Err_DataExisted = -1212999;
        }

        /// <summary>
        /// CfRegTranferMoney - [-12_13_YYY] - Thông tin đăng ký hạn mức chuyển tiền
        /// </summary>
        public static class CF_CfRegTranferMoney
        {
            public const int Err_CfRegTranId = -1213001;
            public const int Err_CfAutoId = -1213002;
            public const int Err_CustId = -1213003;
            public const int Err_AfAutoId = -1213004;
            public const int Err_AfAccNo = -1213005;
            public const int Err_TranType = -1213006;
            public const int Err_IsRegTransfer = -1213007;
            public const int Err_MinPerTran = -1213008;
            public const int Err_MinPerDay = -1213009;
            public const int Err_MaxPerTran = -1213010;
            public const int Err_MaxPerDay = -1213011;
            public const int Err_Status = -1213012;
            public const int Err_Description = -1213013;
            public const int Err_Deleted = -1213014;
            public const int Err_CreateBy = -1213015;
            public const int Err_CreateDate = -1213016;
            public const int Err_LastChangeBy = -1213017;
            public const int Err_LastChangeDate = -1213018;
            public const int Err_ApproveBy = -1213019;
            public const int Err_ApproveDate = -1213020;
            //
            public const int Err_DataExisted = -1213999;
        }


        /// <summary>
        /// CfControlling - [-12_14_YYY] - Thông tin người giám hộ
        /// </summary>
        public static class CF_CfControlling
        {
            public const int Err_CustId = -1214001;
            public const int Err_LinkData = -1214002;
            public const int Err_Description = -1214003;
            public const int Err_Status = -1214004;
            public const int Err_DataExisted = -1214999;
        }

        /// <summary>
        /// CfNotification - [-12_15_YYY] - Thông tin nhận thông báo SMS/Email
        /// </summary>
        public static class CF_CfNotification
        {
            public const int Err_CfNotiId = -1215001;
            public const int Err_CfAutoId = -1215002;
            public const int Err_AfAutoId = -1215003;
            public const int Err_CustId = -1215004;
            public const int Err_AfAccNo = -1215005;
            public const int Err_IsInheritance = -1215006;
            public const int Err_GroupNotiId = -1215007;
            public const int Err_NotiId = -1215008;
            public const int Err_Name = -1215009;
            public const int Err_Language = -1215010;
            public const int Err_IsCalFee = -1215011;
            public const int Err_IsRecvSms = -1215012;
            public const int Err_IsRecvEmail = -1215013;
            public const int Err_PhoneNumber = -1215014;
            public const int Err_EmailRecv = -1215015;
            public const int Err_Status = -1215016;
            public const int Err_Description = -1215017;
            public const int Err_Deleted = -1215018;
            public const int Err_CreateBy = -1215019;
            public const int Err_CreateDate = -1215020;
            public const int Err_LastChangeBy = -1215021;
            public const int Err_LastChangeDate = -1215022;
            public const int Err_ApproveBy = -1215023;
            public const int Err_ApproveDate = -1215024;
            public const int Err_DataType = -1215025;
        }

        /// <summary>
        /// CfRelation - [-12_16_YYY] - Thông tin quan hệ khách hàng
        /// </summary>
        public static class CF_CfRelation
        {
            public const int Err_CfNotiId = -1216001;
            public const int Err_RecustId = -1216002;
            public const int Err_AfAutoId = -1216003;
            public const int Err_CustId = -1216004;
            public const int Err_ReafAccNo = -1216005;
            public const int Err_AfAccNo = -1216006;
            public const int Err_Relation = -1216007;
            public const int Err_Description = -1216008;

            public const int Err_DataExisted = -1216999;

        }
        /// <summary>
        /// BrokerRelation - [-12_17_YYY] - Liên quan môi giới
        /// </summary>
        public static class CF_BrokerRelation
        {
            public const int Err_CustId = -1217001;
            public const int Err_AfAccNo = -1217002;
            public const int Err_DataType = -1217003;
            public const int Err_ReCustId = -1217004;
            public const int Err_ReAfaccNo = -1217005;
            public const int Err_Relation = -1217006;
            public const int Err_Description = -1217007;
            public const int Err_Statust = -1217008;

            public const int Err_DataExisted = -1217999;

        }

        /// <summary>
        /// AfInternalMoneyTransfer - [-12_18_YYY] - Đăng ký chuyển tiền nội bộ khác tên
        /// </summary>
        public static class CF_AfInternalMoneyTransfer
        {
            public const int Err_AutoId = -1218001;
            public const int Err_AfAutoId = -1218002;
            public const int Err_AfAccNo = -1218003;
            public const int Err_RecvAfAccNo = -1218004;
            public const int Err_FromDate = -1218005;
            public const int Err_ToDate = -1218006;
            public const int Err_Description = -1218007;
            public const int Err_Status = -1218008;
            public const int Err_Deleted = -1218009;
            public const int Err_Name = -1218010;
            //
            public const int Err_DataExisted = -1218900;
            public const int Err_SameCustId = -1218901;
        }

        public static class CF_AfSubSts
        {
            public const int Err_AutoId = -1221001;
            public const int Err_RefAutoId = -1221002;
            public const int Err_AfSubStsId = -1221003;
            public const int Err_AfAutoId = -1221004;
            public const int Err_AfAccNo = -1221005;
            public const int Err_SubStsCode = -1221006;
            public const int Err_EffectiveDate = -1221007;
            public const int Err_Description = -1221008;
            public const int Err_Status = -1221009;
            public const int Err_Deleted = -1221010;
            public const int Err_Action = -1221011;
        }

        public static class CF_AfInvestmentTrust
        {
            public const int Err_AutoId = -1221001;
            public const int Err_RefAutoId = -1221002;
            public const int Err_AfInvestmentTrustId = -1221003;
            public const int Err_AfAutoId = -1221004;
            public const int Err_TrustCompany = -1221005;
            public const int Err_ContractNumber = -1221006;
            public const int Err_EffectiveDate = -1221007;
            public const int Err_ExpiryDate = -1221008;
            public const int Err_Status = -1221009;
            public const int Err_Description = -1221010;
            public const int Err_Deleted = -1221011;
        }

        public static class CF_MarketGroup
        {
            public const int Err_MarketGroup_Enable = -1222001;
            public const int Err_MarketGroup_Exist = -1222002;
            public const int Err_MarketGroup_DetailNull = -1222003;

        }

        public static class CF_TransactionCode
        {
            public const int Err_Validate_BankAccount = -1223001;
            public const int Err_Validate_BankId = -1223002;
            public const int Err_Validate_BankBranch = -1223003;
        }

        public static class CF_AccountInterface
        {
            public const int Err_AccountId = -12_24_001;
            public const int Err_InterfaceTypeId = -12_24_002;
            public const int Err_TransferType = -12_24_003;
            public const int Err_BankAccNo = -12_24_004;
            public const int Err_BankAccName = -12_24_005;
            public const int Err_BankId = -12_24_006;
            public const int Err_BankBranchId = -12_24_007;
            public const int Err_EffectiveDate = -12_24_008;
            public const int Err_Description = -12_24_009;
            public const int Err_ForeignAccountResidentInfo = -12_24_010;
        }

        public static class CF_AccountRegisteredAccount
        {
            public const int Err_AccountId = -12_25_001;
            public const int Err_RegisteredAccountId = -12_25_002;
            public const int Err_Description = -12_25_003;
        }

        public static class CF_AccountContactNotification
        {
            public const int Err_ListOfAccountContactNotification_TabName = -12_26_001;  // Danh sách thông báo nhận Email/SMS
            public const int Err_NotificationId = -12_26_002;   // [NotificationId] không hợp lệ | [NotificationId] is invalid
            public const int Err_CustId = -12_26_003;   // [CustId] không hợp lệ | [CustId] is invalid
            public const int Err_Contact = -12_26_004;   // [Contact] Không được để trống SĐT/Email nhận thông báo | [Contact] Contact notification value must not be empty
        }

        public static class CF_UMCAccount
        {
            public const int Err_CustId_Length = -12_27_001;  // 
            public const int Err_AccountId_Length = -12_27_002;   
            public const int Err_AeId_Length = -12_27_003;   // 
            public const int Err_BranchId_Length = -12_27_004; 
            public const int Err_DepartmentId_Length = -12_27_005; 
            public const int Err_ServiceClassId_Length = -12_27_006; 
            public const int Err_FinancialClassId_Length = -12_27_007; 
            public const int Err_TradingFeeClassId_Length = -12_27_008; 
            public const int Err_NewAeId_Length = -12_27_009; 
            public const int Err_NewBranchId_Length = -12_27_010; 
            public const int Err_NewDepartmentId_Length = -12_27_011; 
            public const int Err_NewServiceClassId_Length = -12_27_012; 
            public const int Err_NewFinancialClassId_Length = -12_27_013; 
            public const int Err_NewTradingFeeClassId_Length = -12_27_014; 
            public const int Err_EffectDate_Invalid = -12_27_019; 

            public const int Err_RecordHasPendingStatus = -12_27_015;
            public const int Err_EffectiveDate_Empty = -12_27_016;
            public const int Err_EffectiveDate_Is_Holiday = -12_27_017;
            public const int Err_AeIdAcc_Not_Equal_AeIdClient = -12_27_018;
            public const int Err_ListChangeInformation = -12_27_019;
            public const int Err_AccountId_does_not_belong_to_ClientId = -12_27_020;
            public const int Err_Update_AccountOverrideSetting_Failed = -12_27_021;
            public const int Err_Delete_AccountOverrideSetting_Failed = -12_27_022;
            public const int Err_Delete_AccountFinancialClassUnderlying_Failed = -12_27_023;
            public const int Err_Delete_AccountFinancialClassParameter_Failed = -12_27_024;
            public const int Err_Delete_AccountUnderlyingDeliveryMarginRatio_Failed = -12_27_024;

            public const int Err_Create_Record_Has_EffectDate_Smaller_Than_BusDate = -12_27_094;

            public const int Err_Approve_Record_Has_EffectDate_Smaller_Than_BusDate = -12_27_095;
            public const int Err_Delete_Record_Has_EffectDate_Smaller_Than_Or_Equal_BusDate = -12_27_096; 

            public const int Err_Approve_Data = -12_27_097; // lỗi duyệt data
            public const int Err_Approve_Child_Data = -12_27_098; // lỗi duyệt child data

        }
    }
}
