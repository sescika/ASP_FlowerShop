using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.UseCases.Commands.Products;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validators.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Commands.Products
{
	public class EFUpdateProductCommand : EfUseCase, IUpdateProductCommand
	{
		private UpdateProductDtoValidator _validator;

		public EFUpdateProductCommand(FlowershopContext context, UpdateProductDtoValidator validator) : base(context)
		{
			_validator = validator;
		}
		public int Id => 11;

		public string Name => "Update Product";

		public void Execute(UpdateProductDto data)
		{
			_validator.ValidateAndThrow(data);
				
			var product = Context.Products.Include(x => x.Inventory).FirstOrDefault(p => p.Id == data.Id);
           
			if(product != null)
			{
				product.Name = string.IsNullOrEmpty(data.Name) ? data.Name : product.Description;
				product.Description = string.IsNullOrEmpty(data.Description) ? data.Description : product.Description;
				product.ImageUrl = string.IsNullOrEmpty(data.ImageUrl) ? data.ImageUrl : product.Description;
				product.Inventory.QuantityAvailable = data.QuantityAvailable.HasValue ?  data.QuantityAvailable.Value : product.Inventory.QuantityAvailable;
				Context.SaveChanges();
			}
		}
	}
}
