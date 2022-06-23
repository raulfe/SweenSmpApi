using FluentValidation;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.UserName).NotNull().Length(3, 100);
            RuleFor(user => user.UserLastName).NotNull().Length(3, 100);
            RuleFor(user => user.UserPhoneNumber).Length(10);
            RuleFor(user => user.Email).NotNull().Length(3, 100);
            RuleFor(user => user.Birthday).NotNull();
        }
    }
}
