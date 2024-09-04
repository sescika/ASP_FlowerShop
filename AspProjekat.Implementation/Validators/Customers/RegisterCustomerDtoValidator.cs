using AspProjekat.Application.DTO.Customers;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.Validators.Customers
{
	public class RegisterCustomerDtoValidator : AbstractValidator<RegisterCustomerDto>
	{
		private FlowershopContext _context;
		public RegisterCustomerDtoValidator(FlowershopContext _ctx) 
		{
			_context = _ctx;
			ClassLevelCascadeMode = CascadeMode.Stop;

			RuleFor(x => x.Username)
				.NotEmpty()
				.Matches("(?=.{5,15}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
				.WithMessage("Invalid username format. Valid examples: (user.name, username_123, user.name_c. Min 5. max 15 chars)");

			RuleFor(x => x.Password).NotEmpty().Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$")
				.WithMessage("Password must contain at least one number, and one letter, min. 8 characters:");

			RuleFor(x => x.Email)
				.NotEmpty()
				.EmailAddress()
				.Must(x => !_context.Customers.Any(u => u.Email == x))
				.WithMessage("Email is already in use.");
			RuleFor(x => x.Name).NotEmpty().MinimumLength(2).WithMessage("Min lenght 2"); ;
			RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).WithMessage("Min lenght 2"); ;
			RuleFor(x => x.State).NotEmpty().MinimumLength(2).WithMessage("Min lenght 2"); ;
			RuleFor(x => x.Address).NotEmpty().MinimumLength(2).WithMessage("Min lenght 2");
			RuleFor(x => x.ZipCode).NotEmpty().MinimumLength(5).WithMessage("Min lenght 5, example: 11000");
		}
	}
}
