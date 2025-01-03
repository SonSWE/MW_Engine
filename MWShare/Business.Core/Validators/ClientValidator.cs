using Business.Core.BLs.ClientBLs;
using Business.Core.Validators;
using CommonLib.Constants;
using CommonLib.Extensions;
using FluentValidation;
using FluentValidation.Results;
using MemoryData;
using Microsoft.Identity.Client;
using Object;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Validators
{
    public class ClientValidator : BaseValidator<MWClient>
    {
        public ClientValidator() : base()
        {
        }

        public ClientValidator(ValidationAction action) : base(action)
        {
        }

        public ClientValidator(ValidationConfig config) : base(config)
        {
        }

        public ClientValidator(ValidationAction action, string language) : base(action, language)
        {
        }

        public override void InitRules()
        {
            
        }
    }
}
