using System.Collections.Generic;
using System.Linq;
using CommonLib.Constants;

namespace Object.Core
{
    public sealed class LoggedUser
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Status { get; set; }
        public string LoginType { get; set; }
        public bool MustChangePassword { get; set; }
        public string WalletId { get; set; }
        //
        public List<LoggedUserFunction> FunctionSettings { get; set; }
        public MWClient Client { get; set; }
        public MWFreelancer Freelancer { get; set; }
    }

    public sealed class LoggedUserFunction
    {
        public string AllowQuery { get; set; }
        public string AllowAdd { get; set; }
        public string AllowUpdate { get; set; }
        public string AllowDelete { get; set; }
        public string AllowExecute { get; set; }
        //
        public string FunctionDescription { get; set; }
        public string FunctionType { get; set; }
        public string FunctionId { get; set; }
    }
}
