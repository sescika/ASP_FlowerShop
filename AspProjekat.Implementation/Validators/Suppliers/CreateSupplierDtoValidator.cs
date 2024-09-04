using AspProjekat.Application.DTO.Suppliers;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.Validators.Suppliers
{
	public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
	{
		private FlowershopContext _ctx;
		public CreateSupplierDtoValidator(FlowershopContext ctx)
		{
			_ctx = ctx;
			ClassLevelCascadeMode = CascadeMode.Stop;
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
			RuleFor(x => x.City).NotEmpty().WithMessage("City is required.").MinimumLength(2).WithMessage("City must be at least 2 characters long.");
			RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip Code is required..").MinimumLength(5).WithMessage("eg: 11000, min 5");
			RuleFor(x => x.State).NotEmpty().WithMessage("State is required.").MinimumLength(3).WithMessage("State must be at least 3 characters long.");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Email isn't in valid format.");
			RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required.").MinimumLength(11).WithMessage("At least 11 chars.");
		}
	}
}
