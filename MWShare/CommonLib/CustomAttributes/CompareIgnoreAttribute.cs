using System;

namespace CommonLib.CustomAttributes
{
    public sealed class CompareIgnoreAttribute : Attribute
    {
        public int Order { get; set; }
    }
}
