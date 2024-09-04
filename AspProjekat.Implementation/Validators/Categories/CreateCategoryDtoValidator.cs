using AspProjekat.Application.DTO.Categories;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.Validators
{
	public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
	{
		private FlowershopContext _context;

		public CreateCategoryDtoValidator(FlowershopContext context)
		{
			_context = context;

			ClassLevelCascadeMode = CascadeMode.Stop;

			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name is required.")
				.MinimumLength(3)
				.WithMessage("Category name must have at least 3 characters.");
		}
	}
}
