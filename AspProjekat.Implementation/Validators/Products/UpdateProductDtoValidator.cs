using AspProjekat.Application.DTO.Products;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.Validators.Products
{
	public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
	{
		private FlowershopContext _ctx;
		public UpdateProductDtoValidator(FlowershopContext ctx)
		{
			ClassLevelCascadeMode = CascadeMode.Stop;
			_ctx = ctx;
			RuleFor(x => x.Id).Must(y => _ctx.Products.Any(p => p.Id == y)).WithMessage($"Product with that id doens't exist.");
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
			RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.").GreaterThan(0).WithMessage("Price must be greater than 0.");
			RuleFor(x => x.QuantityAvailable).NotEmpty().WithMessage("Quantity is required.").GreaterThan(0).WithMessage("Quanitity must be greater than 0.");
		}
	}
}
