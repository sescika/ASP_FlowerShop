using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.UseCases.Queries.Products;
using AspProjekat.DataAccess;

namespace AspProjekat.Implementation.UseCases.Queries.Products
{
	public class EFGetProductsQuery : EfUseCase, IGetProductsQuery
	{

		public EFGetProductsQuery(FlowershopContext ctx) : base(ctx)
		{
			
		}
		public int Id => 3;
		public string Name => "Get All Products";

		public PagedResponse<ProductDto> Execute(ProductSearch search)
		{
			var query = Context.Products.AsQueryable();

			if(!string.IsNullOrEmpty(search.ProductName))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.ProductName.ToLower()));
			}

			if(!string.IsNullOrEmpty(search.SupplierName))
			{
				//ovo	 
				query = query.Where(x => x.Supplier.Name.ToLower().Contains(search.SupplierName.ToLower()));
			}

			if (search.QuantityLeftInInventory_GreaterThan.HasValue)
			{
				query = query.Where(x => x.Inventory.QuantityAvailable > search.QuantityLeftInInventory_GreaterThan);
			}

			if(search.Price_GreaterThan.HasValue)
			{
				query = query.Where(x => x.Price >= search.Price_GreaterThan);
			}

			int totalCount = query.Count();
			int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
			int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


			int skip = perPage * (page - 1);

			query = query.Skip(skip).Take(perPage);
			return new PagedResponse<ProductDto>
			{
				CurrentPage = page,
				TotalCount = totalCount,
				Data = query.Select(x => new ProductDto
				{
					Id = x.Id,
					Name = x.Name,
					SupplierName = x.Supplier.Name,
					Categories = x.Categories.Select(y => new Application.DTO.Categories.CategoryDto
					{
						Id =y.Id,
						Name =y.Name,
					}),
					Description = x.Description,
					QuantityLeftInInventory = x.Inventory.QuantityAvailable,
					ImageUrl = x.ImageUrl,
					Price = (decimal)x.Price
				}).ToList(),
				PerPage = perPage,
			};
		}
	}
}
