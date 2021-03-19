using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(p => p.UserFirstName).MinimumLength(3);
			RuleFor(p => p.UserLastName).MinimumLength(3);
			RuleFor(p => p.UserEmail).MinimumLength(3);
			RuleFor(p => p.UserPassword).NotEmpty();
		}
	}
}
