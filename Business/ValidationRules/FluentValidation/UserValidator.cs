﻿using Core.Entities.Concrete;
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
			RuleFor(p => p.FirstName).MinimumLength(3);
			RuleFor(p => p.LastName).MinimumLength(3);
			RuleFor(p => p.Email).MinimumLength(3);
		}
	}
}
