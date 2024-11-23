using System;

namespace Object.Core
{
    public class ObjectBase
    {
        public string Status { get; set; }
        public int Deleted { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime LastChangeDate { get; set; }
    }
}
