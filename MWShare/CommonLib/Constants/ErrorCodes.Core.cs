namespace CommonLib.Constants
{
    public partial class ErrorCodes
    {
        // Ma loi phan he CR (Core): -14_XX_YYY;
        // XX: 2 so the hien bang
        //		+ 00: TLLog                 - Tran log
        //		+ 01: SysParam                 - SysParam
        //		+ 02: MasterDataBase                 - SysParam
        //		+ 03: Role
        //		+ 04: RoleInputSetting
        //		+ 05: RoleApprovalSetting
        //		+ 06: RoleFunction
        //		+ 07: User
        //		+ 08: UserFunction
        //		+ 09: UserUserRole
        //		+ 10: UserInputSetting
        //		+ 11: UserApprovalSetting
        //		+ 12: UserAccessibleBranch
        // YYY: 3 so the hien loi

        public static class CR
        {
            public static class Err_TLLog
            {
                public const int Status = -14_00_001;
                public const int TxNum_Duplicate = -14_00_002;
                public const int PendingDataExisted = -14_00_003;
                public const int BatchId_Existed = -14_00_004;
            }
        }
        /// <summary>
        /// SysParam - [-14_01_YYY] - SysParam
        /// </summary>
        public static class Err_SysParam
        {
            public const int Err_AutoId = -14_01_001;
            public const int Err_Grp = -14_01_002;
            public const int Err_Name = -14_01_003;
            public const int Err_PValue = -14_01_004;
            public const int Err_PType = -14_01_005;
            public const int Err_Content = -14_01_006;
            public const int Err_ContentOther = -14_01_007;
            public const int Err_Status = -14_01_008;
            public const int Err_SysParam_Duplicate = -14_01_009;
            public const int Err_Description = -14_01_010;
            public const int StatusInvalid = -14_01_011;
            public const int Err_Used = -14_01_012;
        }

        public static class CR_MasterData
        {
            public const int Err_RecordStatus_Delete = -1402001;
            public const int Err_RecordStatus_Cancel = -1402002;
            public const int Err_RecordStatus_Update = -1402003;
            public const int Err_RecordStatus_Approve = -1402004;
        }

        //
        public static class CR_Role
        {
            public const int Err_AutoId = -1403001;
            public const int Err_RefAutoId = -1403002;
            public const int Err_Description = -1403003;
            public const int Err_RecordStatus = -1403004;
            public const int Err_Action = -1403005;
            public const int Err_CreateBy = -1403006;
            public const int Err_CreateDate = -1403007;
            public const int Err_LastChangeBy = -1403008;
            public const int Err_LastChangeDate = -1403009;
            public const int Err_ApproveBy = -1403010;
            public const int Err_ApproveDate = -1403011;
            public const int Err_RejectNum = -1403012;
            public const int Err_RejectDes = -1403013;
            public const int Err_CancelReason = -1403014;
            public const int Err_Deleted = -1403015;
            //
            public const int Err_UserRolePid = -1403016;
            public const int Err_RoleId = -1403017;
            public const int Err_RuleType = -1403018;
            public const int Err_Name = -1403019;
            public const int Err_NameOther = -1403020;
            public const int Err_InputSettings = -1403021;
            public const int Err_ApprovalSettings = -1403022;
            public const int Err_FunctionSettings = -1403023;
            public const int Err_RoleId_Existed = -1403024;
            public const int Err_PendingExisted = -1403025;
            public const int Err_DeleteDataUsed = -1403026;
            //
            public const int Err_Status = -1403027;
            public const int Err_ApproveSelfData = -1403028;
            public const int Err_CancelOtherData = -1403029;
            public const int Err_FunctionSettings_NotExists = -1403030;
            public const int Err_Status_InactiveKhiDaGanVaoUser = -1403031;
        }

        //
        public static class CR_RoleInputApprovalLimit
        {
            public const int Err_ParameterId = -1404001;
            public const int Err_Value = -1404002;
            public const int Err_Type = -1404003;
        }

        //
        public static class CR_RoleFunction
        {
            public const int Err_RoleId = -1406005;
            public const int Err_FunctionId = -1406006;
            public const int Err_Deleted = -1406007;
            //
            public const int Err_AllowQuery = -1406008;
            public const int Err_AllowAdd = -1406009;
            public const int Err_AllowUpdate = -1406010;
            public const int Err_AllowDelete = -1406011;
            public const int Err_AllowCancel = -1406012;
            public const int Err_AllowExecute = -1406013;
            public const int Err_AllowApproveAdd = -1406014;
            public const int Err_AllowApproveUpdate = -1406015;
            public const int Err_AllowApproveDelete = -1406016;
            public const int Err_AllowApproveExecute = -1406017;
            public const int Err_AllowBackdate = -1406018;
            public const int Err_AllowNotification = -1406019;
            public const int Err_AllowImport = -1406020;
            public const int Err_AllowPrint = -1406021;
            public const int Err_AllowCheckAccessHierachy = -1406022;
            public const int Err_AllowCopyRecord = -1406023;
            public const int Err_AllowExport = -1406024;
        }

        //
        public static class CR_User
        {
            public const int Err_AutoId = -1407001;
            public const int Err_RefAutoId = -1407002;
            public const int Err_Description = -1407003;
            public const int Err_RecordStatus = -1407004;
            public const int Err_Action = -1407005;
            public const int Err_CreateBy = -1407006;
            public const int Err_CreateDate = -1407007;
            public const int Err_LastChangeBy = -1407008;
            public const int Err_LastChangeDate = -1407009;
            public const int Err_ApproveBy = -1407010;
            public const int Err_ApproveDate = -1407011;
            public const int Err_RejectNum = -1407012;
            public const int Err_RejectDes = -1407013;
            public const int Err_CancelReason = -1407014;
            public const int Err_Deleted = -1407015;
            //
            public const int Err_UserPid = -1407016;
            public const int Err_UserName = -1407017;
            public const int Err_BranchPid = -1407018;
            public const int Err_BranchId = -1407019;
            public const int Err_DepartmentPid = -1407020;
            public const int Err_DepartmentId = -1407021;
            public const int Err_Name = -1407022;
            public const int Err_NameOther = -1407023;
            public const int Err_RptFuncCanViewAllBranches = -1407024;
            public const int Err_UserType = -1407025;
            public const int Err_Status = -1407026;
            public const int Err_ReadOnlyUser = -1407027;
            public const int Err_Source = -1407028;
            public const int Err_Title = -1407029;
            public const int Err_Position = -1407030;
            public const int Err_SuperVisor = -1407031;
            public const int Err_Supporter = -1407032;
            public const int Err_SecuritiesPracticingCertification = -1407033;
            public const int Err_Gender = -1407034;
            public const int Err_PhoneNo = -1407035;
            public const int Err_EmailAddress = -1407036;
            public const int Err_Remark = -1407037;
            public const int Err_RemarkOther = -1407038;
            public const int Err_EnableLogon = -1407039;
            public const int Err_Password = -1407040;
            public const int Err_MustChangePasswordAtNextLogon = -1407041;
            public const int Err_UserRoles = -1407042;
            public const int Err_FunctionSettings = -1407043;
            public const int Err_UserName_Existed = -1407044;
            public const int Err_PendingExisted = -1407045;
            public const int Err_InputSettings = -1407046;
            public const int Err_ApprovalSettings = -1407047;
            public const int Err_AccessibleBranches = -1407048;
            public const int Err_AccountIsLockedOut = -1407049;
            //
            public const int Err_ApproveSelfData = -1407050;
            public const int Err_CancelOtherData = -1407051;
            public const int Err_FunctionSettings_NotExistsInUserRole = -1407052;
            public const int Err_FunctionSettings_NotExists = -1407053;
            public const int Err_UserLDAPKhongTonTai = -1407054;
            public const int Err_UserLDAPTrangThaiInactive = -1407055;
            public const int Err_LdapTitle = -1407056;
            public const int Err_LdapPosition = -1407057;
            //
            public const int Err_DeleteUserCreatedTransaction = -1407058;
            public const int Err_Password_LengthMustGreaterOrEqualsNCharacter = -1407059;
            public const int Err_Password_MustContainsBothUpperAndLowerCase = -1407060;
            public const int Err_Password_MustContainsNumbericCharacter = -1407061;
            //
            public const int Err_ChangePassword_OldPasswordInvalid = -1407062;
            public const int Err_ChangePassword_NewPasswordRepeated = -1407063;
            public const int Err_ChangePassword_NewPasswordSameOldPassword = -1407064;
            public const int Err_ChangePassword_CantChangeUserLDAPPassword = -1407065;
            //
            public const int Err_CompanyId = -1407066;
            public const int Err_ResetPassword = -1407067;
            public const int Err_OrderCheckingGroupId = -1407068;
        }

        //
        public static class CR_UserFunction
        {
            public const int Err_AutoId = -1408001;
            public const int Err_RefAutoId = -1408002;
            public const int Err_Pid = -1408003;
            public const int Err_UserPid = -1408004;
            public const int Err_UserAutoId = -1408005;
            public const int Err_FunctionAutoId = -1408006;
            public const int Err_Deleted = -1408007;
            //
            public const int Err_AllowQuery = -1408008;
            public const int Err_AllowAdd = -1408009;
            public const int Err_AllowUpdate = -1408010;
            public const int Err_AllowDelete = -1408011;
            public const int Err_AllowCancel = -1408012;
            public const int Err_AllowExecute = -1408013;
            public const int Err_AllowApproveAdd = -1408014;
            public const int Err_AllowApproveUpdate = -1408015;
            public const int Err_AllowApproveDelete = -1408016;
            public const int Err_AllowApproveExecute = -1408017;
            public const int Err_AllowBackdate = -1408018;
            public const int Err_AllowNotification = -1408019;
            public const int Err_AllowImport = -1408020;
            public const int Err_AllowPrint = -1408021;
            public const int Err_AllowCheckAccessHierachy = -1408022;
            public const int Err_IsOverride = -1408023;
            public const int Err_AllowCopyRecord = -1408024;
            public const int Err_AllowExport = -1408025;
        }

        //
        public static class CR_UserRole
        {
            public const int Err_AutoId = -1409001;
            public const int Err_RefAutoId = -1409002;
            public const int Err_Pid = -1409003;
            public const int Err_UserPid = -1409004;
            public const int Err_UserAutoId = -1409005;
            public const int Err_UserRolePid = -1409006;
            public const int Err_UserRoleAutoId = -1409007;
            public const int Err_Deleted = -1409008;
        }


        //
        public static class CR_UserInputApprovalLimit
        {
            public const int Err_ParameterId = -1410001;
            public const int Err_Value = -1410002;
            public const int Err_Type = -1410003;
            public const int Err_IsOverride = -1410004;
        }

        //
        public static class CR_UserAccessibleBranch
        {
            public const int Err_AutoId = -1412001;
            public const int Err_RefAutoId = -1412002;
            public const int Err_Pid = -1412003;
            public const int Err_UserPid = -1412004;
            public const int Err_UserAutoId = -1412005;
            public const int Err_BranchType = -1412006;
            public const int Err_BranchId = -1412007;
            public const int Err_DepartmentId = -1412008;
            public const int Err_Deleted = -1412009;
        }
    }
}
