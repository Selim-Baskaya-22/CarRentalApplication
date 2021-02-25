using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Cars>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(80);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1900);
        }
    }
}
