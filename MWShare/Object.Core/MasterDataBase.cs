using CommonLib.Constants;
using Object.Core.Attribute;
using Object.Core.CustomAttributes;
using System;
using System.Collections.Generic;

namespace Object.Core
{
    public class MasterDataBase
    {
        //
        [DbField(IgnoreUpdate = true)]
        public virtual string CreateBy { get; set; }

        [DbField(IgnoreUpdate = true)]
        public virtual DateTime? CreateDate { get; set; }
        public virtual string LastChangeBy { get; set; }
        public virtual DateTime? LastChangeDate { get; set; }
    }

    public class MasterDataBaseBusinessResponse
    {
        public long Code { get; set; }
        public string Message { get; set; }
        public string JsonData { get; set; }
        public string PropertyName { get; set; }
        public string Id { get; set; }
    }

    public class MasterDataBaseApproveRequest
    {
        public long AutoId { get; set; }
        public string Status { get; set; }
        public string RejectDes { get; set; }
        public string Id { get; set; }
    }
    public class MasterDataBaseDeleteRequest
    {
        public long AutoId { get; set; }
        public string Id { get; set; }
    }

    public class MasterDataBaseCheckDuplicateIdResponse
    {
        public bool IsDuplicated { get; set; }
        public string RecordStatus { get; set; }
    }
}
