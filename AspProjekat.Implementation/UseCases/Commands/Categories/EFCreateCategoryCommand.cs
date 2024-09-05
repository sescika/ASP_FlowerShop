using AspProjekat.Application.DTO.Categories;
using AspProjekat.Application.UseCases.Commands.Categories;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Commands.Categories
{
	public class EFCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
	{
		private CreateCategoryDtoValidator _validator;

		public EFCreateCategoryCommand(FlowershopContext context, CreateCategoryDtoValidator validator) : base(context) 
		{
			_validator = validator; 
		}

		public int Id => 2;
		public string Name => "Create Category";

		public void Execute(CreateCategoryDto data)
		{
			_validator.ValidateAndThrow(data);

			Category catToAdd = new Category
			{
				Name = data.Name
			};
			
			Context.Categories.Add(catToAdd);
			Context.SaveChanges();
		}
	}
}
