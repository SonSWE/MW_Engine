using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWUser, ViewName = $"VW_{Const.DbTable.MWUser}")]
    public sealed class MWUser : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string UserName { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string NameOther { get; set; }
        public string RptFuncCanViewAllBranches { get; set; }
        public string UserType { get; set; }
        public string Status { get; set; }
        public string ReadOnlyUser { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Supervisor { get; set; }
        public string Supporter { get; set; }
        public string SecuritiesPracticingCertification { get; set; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Remark { get; set; }
        public string RemarkOther { get; set; }
        // Logon Setting
        public string EnableLogon { get; set; }
        public string Password { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string RawPassword { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string HiddenPassword
        {
            get
            {
                return new string('*', Password?.Length ?? 0);
            }
        }
        public int FailedLogonCount { get; set; }
        public string MustChangePasswordAtNextLogon { get; set; }
        public string AccountIsLockedOut { get; set; }
        public DateTime LastTriedOrLogonTime { get; set; }
        public string LastTriedOrLogonIp { get; set; }
        // End - Logon Setting


        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public List<MWUserFunction> FunctionSettings { get; set; }


        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusTextEn { get; set; }

        public string LdapTitle { get; set; }
        public string LdapPosition { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string TitleText { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string TitleTextEn { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string PositionText { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string PositionTextEn { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string GenderText { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string GenderTextEn { get; set; }

        public DateTime LastChangePasswordOn { get; set; }

        public string CompanyId { get; set; }

       
        public string ResetPassword { get; set; }
        public string OrderCheckingGroupId { get; set; }

        //audit trail
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string MustChangePasswordAtNextLogonText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string MustChangePasswordAtNextLogonTextEn { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string EnableLogonText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string EnableLogonTextEn { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string SecuritiesPracticingCertificationText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string SecuritiesPracticingCertificationTextEn { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ReadOnlyUserText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ReadOnlyUserTextEn { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string RptFuncCanViewAllBranchesText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string RptFuncCanViewAllBranchesTextEn { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ResetPasswordText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ResetPasswordTextEn { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string AccountIsLockedOutText { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string AccountIsLockedOutTextEn { get; set; }
    }

    [DbTable]
    public sealed class MCUserPasswordHistory
    {
        public string HistDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
