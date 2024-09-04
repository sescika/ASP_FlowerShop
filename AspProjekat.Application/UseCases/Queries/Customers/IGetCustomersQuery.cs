using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Queries.Customers
{
	public interface IGetCustomersQuery : IQuery<PagedResponse<CustomerDto>, CustomerSearch>
	{
	}
}
