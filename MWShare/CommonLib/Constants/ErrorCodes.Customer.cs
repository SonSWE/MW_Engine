namespace CommonLib.Constants
{
    public static partial class ErrorCodes
    {
        // Error code phan he CUSTOMER: -12XXYYY;
        // XX: 2 so the hien bang
        //		+ 00: MCCustomer - Thông tin khách hàng
        //		+ 01: MCContact - Thông tin liên hệ của customer và account
        //		+ 02: MCCustomerLegalRepresentative - Thông tin Người đại diện
        //		+ 03: MCCustomerControllingPerson - Thông tin Người giám hộ
        //		+ 04: MCAuthority - Thông tin ủy quyền
        //      + 05: MCCustomerIssuer - Thông tin cổ đông
        //      + 06: MCCustomerTin - Thông tin mã số thuế
        //      + 08: MCCustomerAERelation - Thông tin môi giới có quan hệ với KH
        // YYY: 3 so the hien loi

        /// <summary>
        /// CUSTOMER - [-12_00_YYY] - Thông tin khách hàng
        /// </summary>
        public static class MCCustomer
        {
            public const int Err_CustId = -12_00_001;  // Mã khác hàng không được để trống và không hơn 20 ký tự // [CustId] invalid
            public const int Err_Name = -12_00_002; // Tên khách hàng, công ty tổ chức mở tài khoản không được để trống và không hơn 500 ký tự // [Name] invalid
            public const int Err_NameOther = -12_00_003; // Tên bằng ngôn ngữ khác không hơn 500 ký tự // [NameOther] invalid
            public const int Err_ShortName = -12_00_004; // Tên viết tắt của KH không hơn 100 ký tự
            public const int Err_RegistrationType = -12_00_005; // Loại hình khách hàng không hợp lệ
            public const int Err_OmnibusEFlag = -12_00_006; // Tài khoản tổng Cơ sở  chỉ cho phép giá trị Y or N
            public const int Err_OmnibusDFlag = -12_00_007; // TK phái sinh là TK tổng không tự động bù trừ chỉ cho phép giá trị Y or N
            public const int Err_CustodianFlag = -12_00_008; // Tiền và chứng khoán quản lý tại ngân hàng lưu ký chỉ cho phép giá trị Y or N
            public const int Err_MutualFundFlag = -12_00_009; // Quỹ chỉ cho phép giá trị Y or N
            public const int Err_AssetManagementFlag = -12_00_010; // Quản lý tài sản chỉ cho phép giá trị Y or N
            public const int Err_EnableSubAccountManagementFlag = -12_00_011; // Quản lý phụ khoản chỉ cho phép giá trị Y or N
            public const int Err_Nationality = -12_00_012; // Quốc tịch không để trống và không hơn 100 ký tự
            public const int Err_SignPaths = -12_00_013; // Đường dẫn chữ ký KH không hơn 1000 ký tự
            public const int Err_InstitutionTypeId = -12_00_014; // Loại tổ chức không hợp lệ
            public const int Err_Sid = -12_00_015; // Mã định danh của NĐT không hơn 16 ký tự
            public const int Err_InvestorCode = -12_00_016; // Mã NĐT không hơn 35 ký tự
            public const int Err_Gender = -12_00_017; // Giới tính không hợp lệ
            public const int Err_DateOfBirth = -12_00_018; // Ngày sinh không đúng định dạng yyyyMMdd
            public const int Err_PlaceOfBirth = -12_00_019; // Nơi sinh không hơn 2000 ký tự
            public const int Err_ResidentCountryId = -12_00_020; // Quốc gia không hơn 3 ký tự
            public const int Err_FATCA = -12_00_021; //  Tài khoản nộp thuế tại Hoa Kỳ chỉ cho phép giá trị Y or N
            public const int Err_CustodyCd = -12_00_022; //  Số tài khoản lưu ký không để trống và không hơn 20 ký tự
            public const int Err_ManageTradingCodeFlag = -12_00_023; //  KH nước ngoài có được quản lý hồ sơ thông tin chính của NĐT ở SSI  chỉ cho phép giá trị Y or N
            public const int Err_TradingCodeIssueDate = -12_00_024; //  Ngày cấp trading code  KH nước ngoài không đúng định dạng yyyyMMdd
            public const int Err_TradingCodeIssuePlace = -12_00_025; //  TradingCodeIssuePlace  không hơn 1000 ký tự
            public const int Err_TradingCodeCancelFlag = -12_00_026; // TradingCodeCancelFlag chỉ cho phép giá trị Y or N
            public const int Err_BrokerCareFlag = -12_00_027; // Có môi giới chăm sóc chỉ cho phép giá trị Y or N
            public const int Err_AeId = -12_00_028; // Cán bộ môi giới quản lý không hơn 50 ký tự
            public const int Err_EnableAccountEditAe = -12_00_029; // EnableAccountEditAe chỉ cho phép giá trị Y or N
            public const int Err_BranchId = -12_00_030; // Chi nhánh không để trống và không hơn 100 ký tự
            public const int Err_ClearingFlag = -12_00_031; //Bù trừ phái sinh chỉ cho phép giá trị D or G

            #region Thông tin cư trú

            public const int Err_ResidentType = -12_00_032; // Loại cư trú không hơn 500 ký tự
            public const int Err_ResidentCard = -12_00_033; // Số thẻ cư trú không hơn 200 ký tự
            public const int Err_ResidentCardActiveDate = -12_00_034; // Ngày hiệu lực thẻ cư trú không đúng định dạng yyyyMMdd
            public const int Err_ResidentCardExpiryDate = -12_00_035; // Ngày hết hạn thẻ cư trú không đúng định dạng yyyyMMdd
            public const int Err_ResidentCardIssuePlace = -12_00_036; // Nơi cấp thẻ cư trú không hơn 100 ký tự

            #endregion Thông tin cư trú

            #region Trạng thái khách hàng

            public const int Err_IsStaff = -12_00_037; // IsStaff chỉ cho phép giá trị Y or N
            public const int Err_OpenDate = -12_00_038; //  OpenDate không đúng định dạng yyyyMMdd
            public const int Err_CloseDate = -12_00_039; // CloseDate không đúng định dạng yyyyMMdd
            public const int Err_Status = -12_00_040; // Trạng thái hoạt động chỉ cho phép giá trị A or C
            public const int Err_OpenVia = -12_00_041; // Kênh mở tài khoản không hợp lệ
            public const int Err_ProfessionalInvestorsFlag = -12_00_042; // ProfessionalInvestorsFlag chỉ cho phép giá trị Y or N
            public const int Err_ProfessionalInvestorsType = -12_00_043; // Loại nhà đầu tư chứng khoán chuyên nghiệp chỉ cho phép giá trị Y or N
            public const int Err_ProfessionalInvestorsExpiryDate = -12_00_044; // Ngày hết hạn NĐT chuyên nghiệp không đúng định dạng yyyyMMdd

            #endregion Trạng thái khách hàng

            #region Đăng ký nhận thông báo SMS/EMAIL

            public const int Err_IsReceiveSMS = -12_00_045; // Nhận SMS chỉ cho phép giá trị Y or N
            public const int Err_IsReceiveEmail = -12_00_046; // Nhận Email chỉ cho phép giá trị Y or N
            public const int Err_IsSuspendSms = -12_00_047; // Dừng nhận SMS chỉ cho phép giá trị Y or N
            public const int Err_IsSuspendEmail = -12_00_048; // Dừng nhận Email chỉ cho phép giá trị Y or N
            public const int Err_IsReopened = -12_00_049; // IsReopened không hơn 1 ký tự
            public const int Err_Description = -12_00_050; // Mô tả thêm không hơn 2000 ký tự

            #endregion Đăng ký nhận thông báo SMS/EMAIL

            public const int Err_ExistCustId = -12_00_051; // CustId đã tồn tại
            public const int Err_Exist_CustId_IdType_IdNumber = -12_00_052; // Số ĐKSH đã tồn tại
            public const int Err_IdIssueDate = -12_00_053; // [IdIssueDate] không hợp lệ |  [IdIssueDate] invalid
            public const int Err_IdExpiryDate = -12_00_054; // [IdExpiryDate] không hợp lệ |  [IdExpiryDate] invalid
            public const int Err_IdIssuePlace = -12_00_055; // [IdIssuePlace] không hợp lệ |  [IdIssuePlace] invalid
            public const int Err_ExistCustodycd = -12_00_056; // CustodyCd đã tồn tại
            public const int Err_ExistTradingCode = -12_00_057; // TradingCode đã tồn tại
            public const int Err_IdType = -12_00_058; // [IDType] không hợp lệ |  [IDType] invalid
            public const int Err_IdNumber = -12_00_059; // [IdNumber] không hợp lệ |  [IdNumber] invalid
            public const int Err_TradingCode = -12_00_060; // [TradingCode] không hợp lệ |  [TradingCode] invalid
            public const int Err_ExitsActiveAccount = -12_00_061; // Khách hàng đã mở tài khoản thành công không được phép xóa |  Customers who have successfully opened an account are not allowed to delete

            public const int Err_OperatorAccount = -12_00_062;  // [OperatorAccount] không hợp lệ | [OperatorAccount] invalid
            public const int Err_OperatorAccountPaths = -12_00_063;  // [OperatorAccountPaths] không hợp lệ | [OperatorAccountPaths] invalid
            public const int Err_MustHave_ControllingPerson = -12_00_064;  // Khách hàng phải có thông tin người giám hộ | Customer must have controlling person
            public const int Err_DateOfBirth_18 = -12_00_065;  // Khách hàng phải đủ 18 tuổi | Must be at least 18 years old
            public const int Err_DateOfBirth_SystemDate = -12_00_066;  // Ngày sinh phải nhỏ hơn ngày hệ thống | Date of Birth must be less than System Date
            public const int Err_CustomerAccountStatusClosed = -12_00_067;  // Khách hàng vẫn còn tài khoản chưa đóng | This customer still has an unclosed account
            public const int Err_DateOfBirth_15 = -12_00_068;  // Khách hàng phải đủ 15 tuổi | Must be at least 15 years old

        }

        /// <summary>
        /// MCContact - [-12_01_YYY] - Thông tin liên hệ
        /// </summary>
        public static class MCContact
        {
            public const int Err_CustId = -12_01_001;  // [CustId] không hợp lệ |  [CustId] invalid
            public const int Err_AccountId = -12_01_002;  // [AccountId] không hợp lệ |  [AccountId] invalid
            public const int Err_CountryId = -12_01_003;  // [CountryId] không hợp lệ |  [CountryId] invalid
            public const int Err_DataType = -12_01_004;  // [DataType] không hợp lệ |  [DataType] invalid
            public const int Err_AddType = -12_01_005;  // [AddType] không hợp lệ |  [AddType] invalid
            public const int Err_InfoType = -12_01_006;  // [InfoType] không hợp lệ |  [InfoType] invalid
            public const int Err_Contact = -12_01_007;  // [Contact] không hợp lệ |  [Contact] invalid
            public const int Err_FaxAttention = -12_01_008;  // [FaxAttention] không hợp lệ |  [FaxAttention] invalid
            public const int Err_IsDefault = -12_01_009;  // [IsDefault] không hợp lệ |  [IsDefault] invalid
            public const int Err_IsInheritance = -12_01_010;  // [IsInheritance] không hợp lệ |  [IsInheritance] invalid
            public const int Err_InheritancedContactId = -12_01_011;  // [InheritancedContactId] không hợp lệ |  [InheritancedContactId] invalid
            public const int Err_IsOverride = -12_01_012;  // [IsOverride] không hợp lệ |  [IsOverride] invalid
            public const int Err_Description = -12_01_013;  // [Description] không hợp lệ |  [Description] invalid

            public const int Err_ListOfContacts_TabName = -12_01_014;  // Danh sách phòng ban |  List of Contact

            /// <summary>
            /// Xóa liên hệ đã được kế thừa ở Account
            /// </summary>
            public const int Err_DeleteContactHasBeenInherited = -12_01_015;

            /// <summary>
            /// Mỗi liên hệ chỉ được phép 1 giá trị mặc định
            /// </summary>
            public const int Err_Only1Default1AddType = -12_01_016;

            public const int Err_CustomerExistedContact = -12_01_017;
            public const int Err_AddTypeRequired = -12_01_018;  // [AddType] không hợp lệ |  [AddType] invalid
        }

        /// <summary>
        /// MCContact - [-12_02_YYY] - Thông tin Người đại diện
        /// </summary>
        public static class MCCustomerLegalRepresentative
        {
            public const int Err_ListOfLegalRepresentative_TabName = -12_02_001;  // Danh sách nguời đại diện
            public const int Err_CustId = -12_02_002;  //  [CustId] không hợp lệ |  [CustId] invalid
            public const int Err_OperatorAccount = -12_02_003;  //  [OperatorAccount] không hợp lệ |  [OperatorAccount] invalid
            public const int Err_RefCustId = -12_02_004;  //  [RefCustId] không hợp lệ |  [RefCustId] invalid
            public const int Err_Name = -12_02_005;  //  [Name] không hợp lệ |  [Name] invalid
            public const int Err_NameOther = -12_02_006;  //  [NameOther] không hợp lệ |  [NameOther] invalid
            public const int Err_ShortName = -12_02_007;  //  [ShortName] không hợp lệ |  [ShortName] invalid
            public const int Err_IdType = -12_02_008;  //  [IdType] không hợp lệ |  [IdType] invalid
            public const int Err_IdNumber = -12_02_009;  //  [IdNumber] không hợp lệ |  [IdNumber] invalid
            public const int Err_IdIssueDate = -12_02_010;  //  [IdIssueDate] không hợp lệ |  [IdIssueDate] invalid
            public const int Err_IdIssuePlace = -12_02_011;  //  [IdIssuePlace] không hợp lệ |  [IdIssuePlace] invalid
            public const int Err_IdExpiryDate = -12_02_012;  //  [IdExpiryDate] không hợp lệ |  [IdExpiryDate] invalid
            public const int Err_Gender = -12_02_013;  //  [Gender] không hợp lệ |  [Gender] invalid
            public const int Err_DateOfBirth = -12_02_014;  //  [DateOfBirth] không hợp lệ |  [DateOfBirth] invalid
            public const int Err_LegalPresenceType = -12_02_015;  //  [LegalPresenceType] không hợp lệ |  [LegalPresenceType] invalid
            public const int Err_Nationality = -12_02_016;  //  [Nationality] không hợp lệ |  [Nationality] invalid
            public const int Err_CountryId = -12_02_017;  //  [CountryId] không hợp lệ |  [CountryId] invalid
            public const int Err_SignPaths = -12_02_018;  //  [SignPaths] không hợp lệ |  [SignPaths] invalid
            public const int Err_DocumentNo = -12_02_019;  //  [DocumentNo] không hợp lệ |  [DocumentNo] invalid
            public const int Err_Position = -12_02_020;  //  [Position] không hợp lệ |  [Position] invalid
            public const int Err_Mobile = -12_02_021;  //  [Mobile] không hợp lệ |  [Mobile] invalid
            public const int Err_Email = -12_02_022;  //  [Email] không hợp lệ |  [Email] invalid
            public const int Err_Address1 = -12_02_023;  //  [Address1] không hợp lệ |  [Address1] invalid
            public const int Err_Address2 = -12_02_024;  //  [Address2] không hợp lệ |  [Address2] invalid
            public const int Err_DataLink = -12_02_025;  //  [DataLink] không hợp lệ |  [DataLink] invalid
            public const int Err_Description = -12_02_026;  //  [Description] không hợp lệ |  [Description] invalid
            public const int Err_OperatorAccountPaths = -12_02_027;  //  [Description] không hợp lệ |  [Description] invalid
            public const int Err_RequiredForDomesticCustomer = -12_02_028;  //  Bắt buộc thêm Người đại diện với khách hàng Tổ chức trong nước |  A representative is required for domestic corporate customers
        }

        /// <summary>
        /// MCContact - [-12_03_YYY] - Thông tin Người giám hộ
        /// </summary>
        public static class MCCustomerControllingPerson
        {
            public const int Err_ListOfCustomerControllingPerson_TabName = -12_03_001;  // Danh sách người giám hộ
            public const int Err_ControllingPersonId = -12_03_002;  // [ControllingPersonId] không hợp lệ | [ControllingPersonId] invalid
            public const int Err_CustId = -12_03_003;  // [CustId] không hợp lệ | [CustId] invalid
            public const int Err_Controllingflag = -12_03_004;  // [Controllingflag] không hợp lệ | [Controllingflag] invalid
            public const int Err_Datalink = -12_03_005;  // [Datalink] không hợp lệ | [Datalink] invalid
            public const int Err_Description = -12_03_006;  // [Description] không hợp lệ | [Description] invalid
        }

        /// <summary>
        /// MCAuthority - [-12_04_YYY] - Thông tin ủy quyền
        /// </summary>
        public static class MCAuthority
        {
            public const int Err_ListOfAuthority_TabName = -12_04_001;  // Danh sách ủy quyền
            public const int Err_AuthorityId = -12_04_002;  // [AuthorityId] không hợp lệ | [AuthorityId] invalid
            public const int Err_CustId = -12_04_003;  // [CustId] không hợp lệ | [CustId] invalid
            public const int Err_AccountId = -12_04_004;  // [AccountId] không hợp lệ | [AccountId] invalid
            public const int Err_CountryId = -12_04_005;  // [CountryId] không hợp lệ | [CountryId] invalid
            public const int Err_DataType = -12_04_006;  // [DataType] không hợp lệ | [DataType] invalid
            public const int Err_Type = -12_04_007;  // [Type] không hợp lệ | [Type] invalid

            public const int Err_RefCustId = -12_04_010;  // [RefCustId] không hợp lệ | [RefCustId] invalid
            public const int Err_Name = -12_04_011;  // [Name] không hợp lệ | [Name] invalid
            public const int Err_NameOther = -12_04_012;  // [NameOther] không hợp lệ | [NameOther] invalid
            public const int Err_Position = -12_04_013;  // [Position] không hợp lệ | [Position] invalid
            public const int Err_Address = -12_04_014;  // [Address] không hợp lệ | [Address] invalid
            public const int Err_Phone = -12_04_015;  // [Phone] không hợp lệ | [Phone] invalid
            public const int Err_Email = -12_04_016;  // [Email] không hợp lệ | [Email] invalid
            public const int Err_Mobile = -12_04_017;  // [Mobile] không hợp lệ | [Mobile] invalid
            public const int Err_Mobile2 = -12_04_018;  // [Mobile2] không hợp lệ | [Mobile2] invalid
            public const int Err_IdType = -12_04_019;  // [IdType] không hợp lệ | [IdType] invalid
            public const int Err_IdNumber = -12_04_020;  // [IdNumber] không hợp lệ | [IdNumber] invalid
            public const int Err_IdIssueDate = -12_04_021;  // [IdIssueDate] không hợp lệ | [IdIssueDate] invalid
            public const int Err_IdExpiryDate = -12_04_022;  // [IdExpiryDate] không hợp lệ | [IdExpiryDate] invalid
            public const int Err_IdIssuePlace = -12_04_023;  // [IdIssuePlace] không hợp lệ | [IdIssuePlace] invalid
            public const int Err_IsExpiry = -12_04_024;  // [IsExpiry] không hợp lệ | [IsExpiry] invalid
            public const int Err_Status = -12_04_025;  // [Status] không hợp lệ | [Status] invalid
            public const int Err_LinkeCM = -12_04_026;  // [LinkeCM] không hợp lệ | [LinkeCM] invalid
            public const int Err_ContractCreateDate = -12_04_027;  // [ContractCreateDate] không hợp lệ | [ContractCreateDate] invalid
            public const int Err_ContractSignDate = -12_04_028;  // [ContractSignDate] không hợp lệ | [ContractSignDate] invalid
            public const int Err_ContractEffectiveDate = -12_04_029;  // [ContractEffectiveDate] không hợp lệ | [ContractEffectiveDate] invalid
            public const int Err_ContractExpiryDate = -12_04_030;  // [ContractExpiryDate] không hợp lệ | [ContractExpiryDate] invalid
            public const int Err_ContractEffectiveDateOfExpired = -12_04_031;  // [ContractEffectiveDateOfExpired] không hợp lệ | [ContractEffectiveDateOfExpired] invalid
            public const int Err_AuthorityScope = -12_04_032;  // [AuthorityScope] không hợp lệ | [AuthorityScope] invalid
            public const int Err_OtherAuthorizationDes = -12_04_033;  // [OtherAuthorizationDes] không hợp lệ | [OtherAuthorizationDes] invalid
            public const int Err_IsInheritance = -12_04_034;  // [IsInheritance] không hợp lệ | [IsInheritance] invalid
            public const int Err_InheritancedAuthorityId = -12_04_035;  // [InheritancedAuthorityId] không hợp lệ | [InheritancedAuthorityId] invalid
            public const int Err_IsOverride = -12_04_036;  // [IsOverride] không hợp lệ | [IsOverride] invalid
            public const int Err_TrustCustId = -12_04_037;  // [TrustCustId] không hợp lệ | [TrustCustId] invalid
            public const int Err_TrustContractNo = -12_04_038;  // [TrustContractNo] không hợp lệ | [TrustContractNo] invalid
            public const int Err_TrustDescription = -12_04_039;  // [TrustDescription] không hợp lệ | [TrustDescription] invalid
            public const int Err_Description = -12_04_040;  // [Description] không hợp lệ | [Description] invalid
            public const int Err_SignPaths = -12_04_041;  // [SignPaths] không hợp lệ | [SignPaths] invalid
            public const int Err_ExistIDNumber = -12_04_042;  // Số ĐKSH đã tồn tại | IDNumber already exists
            public const int Err_IsTrust = -12_04_043;  // Số ĐKSH đã tồn tại | IDNumber already exists
            public const int Err_TrungKhoangHieuLucVoiKHCaNhan = -12_04_044; // Lỗi trùng khoảng hiệu lực với khách hàng cá nhân
        }

        /// <summary>
        /// MCCustomerIssuer - [-12_05_YYY] - Thông tin cổ đông
        /// </summary>
        public static class MCCustomerIssuer
        {
            public const int Err_ListOfCustomerIssuer_TabName = -12_05_001;  // Danh sách cổ đông
            public const int Err_CustId = -12_05_002;   // [CustId] không hợp lệ | [CustId] invalid
            public const int Err_Symbol = -12_05_003; // [Symbol] không hợp lệ | [Symbol] invalid
            public const int Err_Position = -12_05_004; // [Position] không hợp lệ | [Position] invalid
            public const int Err_Relationship = -12_05_005; // [Relationship] không hợp lệ | [Relationship] invalid
            public const int Err_NumberOfShare = -12_05_006;  // [NumberOfShare] không hợp lệ | [NumberOfShare] invalid
            public const int Err_PercentageOfShare = -12_05_007; // [PercentageOfShare] không hợp lệ | [PercentageOfShare] invalid
            public const int Err_StartDate = -12_05_008; // [StartDate] không hợp lệ | [StartDate] invalid
            public const int Err_Enddate = -12_05_009; // [Enddate] không hợp lệ | [Enddate] invalid
            public const int Err_Reason = -12_05_010;  // [Reason] không hợp lệ | [Reason] invalid
            public const int Err_Description = -12_05_011; // [Description] không hợp lệ | [Description] invalid

        }

        /// <summary>
        /// MCCustomerTin - [-12_06_YYY] - Thông tin mã số thuế
        /// </summary>
        public static class MCCustomerTin
        {
            public const int Err_ListOfCustomerTin_TabName = -12_06_001;  // Danh sách cổ đông
            public const int Err_CustId = -12_06_002;   // [CustId] không hợp lệ | [CustId] invalid
            public const int Err_CountryId = -12_06_003;   // [CountryId] không hợp lệ | [CountryId] invalid
            public const int Err_TaxResidency = -12_06_004;   // [TaxResidency] không hợp lệ | [TaxResidency] invalid
            public const int Err_TaxNumber = -12_06_005;   // [TaxNumber] không hợp lệ | [TaxNumber] invalid
            public const int Err_StartDate = -12_06_006;   // [StartDate] không hợp lệ | [StartDate] invalid
            public const int Err_EndDate = -12_06_007;   // [EndDate] không hợp lệ | [EndDate] invalid
            public const int Err_Description = -12_06_008;   // [Description] không hợp lệ | [Description] invalid

        }

        /// <summary>
        /// MCCustomerAERelation - [-12_08_YYY] - Thông tin môi giới có quan hệ với KH
        /// </summary>
        public static class MCCustomerAERelation
        {
            public const int Err_ListOfCustomerAERelation_TabName = -12_08_001;  // Danh sách các môi giới
            public const int Err_AEID = -12_08_002;   // [AEID] không hợp lệ | [AEID] invalid
            public const int Err_CustId = -12_08_003;   // [CustId] không hợp lệ | [CustId] invalid
            public const int Err_Relation = -12_08_004;   // [Relation] không hợp lệ | [Relation] invalid
            public const int Err_Description = -12_08_005;   // [Description] không hợp lệ | [Description] invalid
        }

        public static class MCCusmoterContactNotification
        {
            public const int Err_ListOfCustomerContactNotification_TabName = -12_09_001;  // Danh sách thông báo nhận Email/SMS
            public const int Err_NotificationId = -12_09_002;   // [NotificationId] không hợp lệ | [NotificationId] is invalid
            public const int Err_CustId = -12_09_003;   // [CustId] không hợp lệ | [CustId] is invalid
            public const int Err_Contact = -12_09_004;   // [Contact] Không được để trống SĐT/Email nhận thông báo | [Contact] Contact notification value must not be empty
        }

        public static class MCCustomerIdentity
        {
            public const int Err_IdType = -12_10_001; // [IdType] không hợp lệ | [IdType] invalid
            public const int Err_IdNumber = -12_10_002; // [IdNumber] không hợp lệ | [IdNumber] invalid
            public const int Err_IdIssueDate = -12_10_003; // [IdIssueDate] không hợp lệ | [IdIssueDate] invalid
            public const int Err_IdExpiryDate = -12_10_004; // [IdExpiryDate] không hợp lệ | [IdExpiryDate] invalid
            public const int Err_IdIssuePlace = -12_10_005; // [IdIssuePlace] không hợp lệ | [IdIssuePlace] invalid
        }
    }
}