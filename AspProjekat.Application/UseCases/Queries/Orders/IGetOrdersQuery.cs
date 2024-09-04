using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Queries.Orders
{
	public interface IGetOrdersQuery : IQuery<PagedResponse<OrderDto>, OrderSearch>
	{
	}
}
