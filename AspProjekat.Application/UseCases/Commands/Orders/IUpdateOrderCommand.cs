using AspProjekat.Application.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Commands.Orders
{
	public interface IUpdateOrderCommand : ICommand<UpdateOrderDto>
	{
	}
}
