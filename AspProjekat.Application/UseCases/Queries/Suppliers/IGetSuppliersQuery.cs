using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Suppliers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Queries.Suppliers
{
	public interface IGetSuppliersQuery : IQuery<PagedResponse<SuppliersDto>, SupplierSearch>
	{
	}
}
