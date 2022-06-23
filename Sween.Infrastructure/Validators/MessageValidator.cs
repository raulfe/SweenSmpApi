using FluentValidation;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(msg => msg.Message1).NotNull();
            RuleFor(msg => msg.Xuser).NotNull();
        }
    }
}
