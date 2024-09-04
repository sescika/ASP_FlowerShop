using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.DTO;
using AspProjekat.Application.UseCases.Queries.Customers;
using AspProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspProjekat.Application.DTO.Customers;

namespace AspProjekat.Implementation.UseCases.Queries.Customers
{
	public class EFGetCustomersQuery : EfUseCase, IGetCustomersQuery
	{
		public EFGetCustomersQuery(FlowershopContext ctx) : base(ctx)
		{

		}
		public int Id => 7;
		public string Name => "Get All Customers";

		public PagedResponse<CustomerDto> Execute(CustomerSearch search)
		{
			var query = Context.Customers.AsQueryable();

			if (!string.IsNullOrEmpty(search.FirstName))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.FirstName.ToLower()));
			}

			if (!string.IsNullOrEmpty(search.LastName))
			{ 
				query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
			}

			if (!string.IsNullOrEmpty(search.Username))
			{
				query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
			}

			if (search.Id.HasValue)
			{
				query = query.Where(x => x.Id == search.Id);
			}
			int totalCount = query.Count();
			int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
			int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


			int skip = perPage * (page - 1);

			query = query.Skip(skip).Take(perPage);
			return new PagedResponse<CustomerDto>
			{
				CurrentPage = page,
				TotalCount = totalCount,
				Data = query.Select(x => new CustomerDto
				{
					Id = x.Id,
					FirstName = x.Name,
					LastName = x.LastName,
					Username = x.Username,
					Email = x.Email,
				}).ToList(),
				PerPage = perPage,
			};
		}
	}
}
