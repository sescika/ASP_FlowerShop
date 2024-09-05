using AspProjekat.Application.Exceptions;
using AspProjekat.Application.UseCases.Commands.Categories;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Commands.Categories
{
	public class EFDeleteCateogryCommand : EfUseCase, IDeleteCategoryCommand
	{
		private CreateCategoryDtoValidator _validator;

		public EFDeleteCateogryCommand(FlowershopContext context, CreateCategoryDtoValidator validator) : base(context)
		{
			_validator = validator;
		}

		public int Id => 12;

		public string Name => "Delete Category";

		public void Execute(int data)
		{
			Category? cat = Context.Categories.Find(data);

			if(cat == null)
			{
				throw new ConflictException($"Category with id {data} doesn't exist.");
			}
			if(cat.Products.Any())
			{
				throw new ConflictException($"Category belongs to a product.");
			}
			
			Context.Categories.Remove(cat);
			Context.SaveChanges();
		}
	}
}
