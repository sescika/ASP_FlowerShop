using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Queries.Products
{
	public interface IGetProductsQuery : IQuery<PagedResponse<ProductDto>, ProductSearch>
	{
	}
}
