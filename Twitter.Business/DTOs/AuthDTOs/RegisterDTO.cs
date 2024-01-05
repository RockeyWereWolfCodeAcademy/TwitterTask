﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Business.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(64);
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(64);
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(16);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.BirthDay)
                .NotEmpty()
                .Must(BeAValidAge);

		}
		protected bool BeAValidAge(DateTime dateOfBirth)
		{
			int currentYear = DateTime.Now.Year;
			int birthYear = dateOfBirth.Year;

			if (birthYear <= (currentYear - 13))
			{
				return true;
			}

			return false;
		}
	}
}
