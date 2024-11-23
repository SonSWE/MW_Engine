using Business.Core.Validators;
using CommonLib.Constants;
using CommonLib.Extensions;
using FluentValidation;
using FluentValidation.Results;
using MemoryData;
using Microsoft.Identity.Client;
using Object.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Validators
{
    public class UserValidator : BaseValidator<MWUser>
    {
        public UserValidator() : base()
        {
        }

        public UserValidator(ValidationAction action) : base(action)
        {
        }

        public UserValidator(ValidationConfig config) : base(config)
        {
        }

        public UserValidator(ValidationAction action, string language) : base(action, language)
        {
        }

        public override void InitRules()
        {
            
        }
    }


    public class UserFunctionValidator : BaseValidator<MWUserFunction>
    {
        public UserFunctionValidator() : base()
        {
        }

        public UserFunctionValidator(ValidationAction action) : base(action)
        {
        }

        public UserFunctionValidator(ValidationConfig config) : base(config)
        {
        }

        public UserFunctionValidator(ValidationAction action, string language) : base(action, language)
        {
        }

        public override void InitRules()
        {

        }
    }
}
