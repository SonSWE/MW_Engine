using CommonLib.Constants;
using Object.Core;
using Object.Core.CustomAttributes;
using static CommonLib.Constants.Const;

namespace Object.Core
{
    [DbTable(Name = Const.DbTable.MWClient, ViewName = $"VW_{Const.DbTable.MWClient}")]
    public sealed class MWClient : MasterDataBase
    {
        [DbField(IsKey = true)]
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ClientType { get; set; } //loại khách hàng
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string ClientTypeText { get; set; } //loại khách hàng
        public string Website { get; set; } //trang web
        public string SpecialtyId { get; set; } //ngành
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string SpecialtyIdText { get; set; } //ngành
        public string PeopleInCompany { get; set; } // só người trong công ty
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string PeopleInCompanyText { get; set; } // só người trong công ty
        public string TagLine { get; set; } // Khẩu hiệu
        public string Description { get; set; } // Miêu tả
        public string Status { get; set; }
        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string StatusText { get; set; } 

        //contact
        public string Owner { get; set; } // người sở hữu
        public string PhoneNumber { get; set; } // số điện thoại
        public string Address { get; set; } // địa chỉ

        [DbField(IgnoreInsert = true, IgnoreUpdate = true)]
        public string Password { get; set; } //mật khẩu
    }
}
