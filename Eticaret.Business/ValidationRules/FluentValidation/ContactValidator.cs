using System;
using System.Collections.Generic;
using System.Text;
using Eticaret.Entities.Concrete;
using FluentValidation;

namespace Eticaret.Business.ValidationRules.FluentValidation
{
    public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(p => p.name).NotEmpty();
            RuleFor(p => p.name).Must(StartWithWithA);
        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
