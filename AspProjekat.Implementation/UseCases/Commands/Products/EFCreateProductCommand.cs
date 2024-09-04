using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Categories;
using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.UseCases.Commands.Products;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validators.Products;
using FluentValidation;

namespace AspProjekat.Implementation.UseCases.Commands.Products
{
	public class EFCreateProductCommand : EfUseCase, ICreateProductCommand
	{
		private CreateProductDtoValidator _validator;

		public EFCreateProductCommand(FlowershopContext context, CreateProductDtoValidator validator) : base(context)
		{
			_validator = validator;
		}
		public int Id => 4;
		public string Name => "Create Product";

		public void Execute(CreateProductDto data)
		{
			_validator.ValidateAndThrow(data);

			if(Context.Suppliers.Find(data.SupplierId) == null)
			{
				throw new ConflictException($"Suppler with {data.SupplierId} doesn't exist.");
			}

			foreach (var categoryId in data.Categories)
			{
				if (Context.Categories.Find(categoryId) == null)
				{
					throw new ConflictException($"Category with ID {categoryId} doesn't exist.");
				}
			}


			Product productToAdd = new Product
			{
				Name = data.Name,
				Description = data.Description,
				Price =	data.Price,
				ImageUrl = data.ImageUrl,
				SupplierId = data.SupplierId
			};
			Inventory inventoryToAdd = new Inventory
			{
				QuantityAvailable = data.QuantityAvailable,
				Product = productToAdd
			};


			Context.Products.Add(productToAdd);
			Context.Inventory.Add(inventoryToAdd);
			Context.SaveChanges();
		}
	}
}
