using FluentValidation;
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
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDay { get; set; }
        public DateOnly RegistrationDate { get; set; }
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
            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(16);
        }
    }
}
