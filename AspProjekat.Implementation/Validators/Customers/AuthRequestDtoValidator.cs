using AspProjekat.Application.DTO.User;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.Validators.Customers
{
    public class LoginRequestDtoValidator : AbstractValidator<CustomerAuthRequestDto>
    {
        public LoginRequestDtoValidator(FlowershopContext ctx)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Username)
                .NotEmpty()
                .Matches("(?=.{5,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
                .WithMessage("Invalid username format. Valid examples: (user.name, username_123, user.name_c)");

            RuleFor(x => x.Password).NotEmpty().Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")
                .WithMessage("Password must contain at least one number, and one letter, min. 8 characters:");
        }
    }
}
