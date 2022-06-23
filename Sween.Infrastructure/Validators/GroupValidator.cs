using FluentValidation;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Validators
{
    public class GroupValidator : AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(group => group.GroupType).NotNull();
            RuleFor(group => group.GroupDescription).NotNull();
            RuleFor(group => group.Xuser).NotNull();
        }
    }
}
