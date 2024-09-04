using AspProjekat.Application.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Commands.Products
{
	public interface IUpdateProductCommand : ICommand<UpdateProductDto>
	{
	}
}
