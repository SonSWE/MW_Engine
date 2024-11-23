namespace Object.Core
{
    public class SysParam
    {
        public long AutoId { get; set; }
        public long SysParamId { get; set; }
        public string Grp { get; set; }
        public string Name { get; set; }
        public string PValue { get; set; }
        public string PType { get; set; }
        public string ContentOther { get; set; }
        public string Content { get; set; }
        public int OrderNo { get; set; }
        public int Deleted { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
