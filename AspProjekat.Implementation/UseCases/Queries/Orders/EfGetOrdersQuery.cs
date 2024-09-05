using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Customers;
using AspProjekat.Application.DTO.Orders;
using AspProjekat.Application.UseCases.Queries.Orders;
using AspProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Queries.Orders
{
	public class EfGetOrdersQuery : EfUseCase, IGetOrdersQuery
	{
		public EfGetOrdersQuery(FlowershopContext ctx) : base(ctx)
		{

		}
		public int Id => 10;

		public string Name => "Get All Orders";

		public PagedResponse<OrderDto> Execute(OrderSearch search)
		{
			var query = Context.Orders.AsQueryable();

			if (!string.IsNullOrEmpty(search.CustomerUsername))
			{
				query = query.Where(x => x.Customer.Username.ToLower().Contains(search.CustomerUsername.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.Status))
			{
				query = query.Where(x => x.Status.ToLower().Contains(search.Status.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.PaymentMethod))
			{
				query = query.Where(x => x.PaymentMethod.ToLower().Contains(search.PaymentMethod.ToLower()));
			}

			int totalCount = query.Count();
			int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
			int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


			int skip = perPage * (page - 1);

			query = query.Skip(skip).Take(perPage);
			return new PagedResponse<OrderDto>
			{
				CurrentPage = page,
				TotalCount = totalCount,
				Data = query.Select(x => new OrderDto
				{
					Id = x.Id,
					CustomerUsername = x.Customer.Username,
					Status = x.Status,
					PaymentMethod = x.PaymentMethod,
					DeliveryDetails = new DeliveryDetailsDto
					{
						DeliveryDate = x.DeliveryDetails.DeliveryDate,
						DeliveryTime = x.DeliveryDetails.DeliveryTime,
						DeliveryStatus	= x.DeliveryDetails.DeliveryStatus,
					},
					OrderItems = x.OrderItems.Select(y => new OrderItemDto
					{
						ProductId = y.ProductId,
						ProductQuantity	= y.Quantity
					}),
				}).ToList(),
				PerPage = perPage,
			};
		}
	}
}
