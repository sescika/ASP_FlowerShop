using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.DTO.Suppliers;
using AspProjekat.Application.UseCases.Queries.Suppliers;
using AspProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Queries.Suppliers
{
	public class EFGetSuppliersQuery : EfUseCase, IGetSuppliersQuery
	{
		public EFGetSuppliersQuery(FlowershopContext ctx) : base(ctx)
		{

		}
		public int Id => 5;
		public string Name => "Get All Suppliers";

		public PagedResponse<SuppliersDto> Execute(SupplierSearch search)
		{
			var query = Context.Suppliers.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name))
			{
				query = Context.Suppliers.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.City))
			{
				query = Context.Suppliers.Where(x => x.SupplierCity.ToLower().Contains(search.City.ToLower()));
			}
			if (!string.IsNullOrEmpty(search.State))
			{
				query = Context.Suppliers.Where(x => x.SupplierState.ToLower().Contains(search.State.ToLower()));
			}


			int totalCount = query.Count();
			int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
			int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


			int skip = perPage * (page - 1);

			query = query.Skip(skip).Take(perPage);

			return new PagedResponse<SuppliersDto>
			{
				CurrentPage = page,
				TotalCount = totalCount,
				PerPage = perPage,
				Data = query.Select(x => new SuppliersDto
				{
					Id = x.Id,
					Name = x.Name,
					Address = x.SupplierAddress,
					City = x.SupplierCity,
					State = x.SupplierState,
					Email = x.SupplierEmail,
					ZipCode = x.SupplierZipCode,
					Phone = x.SupplierPhone,
				})
			};
		
		}
	}
}
