using AspProjekat.Application.DTO.Products;
using AspProjekat.DataAccess;
using FluentValidation;

namespace AspProjekat.Implementation.Validators.Products
{
	public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
	{
		private FlowershopContext _ctx;
		public CreateProductDtoValidator(FlowershopContext ctx) 
		{
			ClassLevelCascadeMode = CascadeMode.Stop;
			_ctx = ctx;

			RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
			RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required.").GreaterThan(0).WithMessage("Price must be greater than 0.");
			RuleFor(x => x.QuantityAvailable).NotEmpty().WithMessage("Quantity is required.").GreaterThan(0).WithMessage("Quanitity must be greater than 0.");
		}
	}
}
