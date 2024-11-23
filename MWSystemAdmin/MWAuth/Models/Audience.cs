using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWAuth.Models
{
    public sealed class Audience
    {
        public string Secret { get; set; } = string.Empty;
        public string Iss { get; set; } = string.Empty;
        public string Aud { get; set; } = string.Empty;
    }
}
