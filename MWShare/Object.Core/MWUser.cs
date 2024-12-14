
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
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string UserTypeText { get; set; }

        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; }
        // Logon Setting
        public string EnableLogon { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string EnableLogonText { get; set; }
        public string Password { get; set; }
        public int FailedLogonCount { get; set; }
        public string MustChangePasswordAtNextLogon { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string MustChangePasswordAtNextLogonText { get; set; }
        public string AccountIsLockedOut { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string AccountIsLockedOutText { get; set; }
        public DateTime LastTriedOrLogonTime { get; set; }
        public string LastTriedOrLogonIp { get; set; }
        // End - Logon Setting


        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public List<MWUserFunction> FunctionSettings { get; set; }


        public DateTime LastChangePasswordOn { get; set; }

        public string ResetPassword { get; set; }
        public string IsEkycVerified { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsEkycVerifiedText { get; set; }
        public string IsEmailVerified { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsEmailVerifiedText { get; set; }
        public string LoginType { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string LoginTypeText { get; set; }
        public string OnlineStatus { get; set; } = Const.ONLINE_STATUS.Offline;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string OnlineStatusText { get; set; }
        public string IsHiddenOnlineStatus { get; set; } = Const.YN.No;
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string IsHiddenOnlineStatusText { get; set; }

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public MWFreelancer Freelancer { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public List<MWClient> Clients { get; set; }

    }
}
