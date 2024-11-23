using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MWAuth.Models
{
    public sealed class TokenRequestParams
    {
        public string Grant_type { get; set; } = string.Empty;
        public string Refresh_token { get; set; } = string.Empty;
        //public string Client_id { get; set; }
        //public string Client_secret { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //public string Ticket { get; set; }
        //public string Serivceurl { get; set; }
    }
}
