using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Products;
using AspProjekat.Application.DTO.Reviews;
using AspProjekat.Application.UseCases.Queries.Reviews;
using AspProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Queries.Reviews
{
	public class EfGetReviewsQuery : EfUseCase, IGetReviewsQuery
	{

		public EfGetReviewsQuery(FlowershopContext ctx) : base(ctx)
		{

		}
		public int Id => 9;

		public string Name => "Get All Reviews";

		public PagedResponse<ReviewDto> Execute(ReviewSearch search)
		{
			var query = Context.Reviews.AsQueryable();
	
			if (!string.IsNullOrEmpty(search.ProductName))
			{
				query = query.Where(x => x.Product.Name.ToLower().Contains(search.ProductName.ToLower()));
			}
			if (search.ProductId.HasValue)
			{
				query = query.Where(x => x.Product.Id == search.ProductId);
			}


			int totalCount = query.Count();
			int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
			int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


			int skip = perPage * (page - 1);

			query = query.Skip(skip).Take(perPage);

			return new PagedResponse<ReviewDto>
			{
				CurrentPage = page,
				TotalCount = totalCount,
				Data = query.Select(x => new ReviewDto
				{
					ProductId = x.Product.Id,
					ProductName = x.Product.Name,	
					Rating = x.Rating,
					CustomerUsername = x.Customer.Username,
					ReviewText = x.ReviewText
				}).OrderByDescending(x => x.Rating).ToList(),
				PerPage = perPage,
			};
		}
	}
}
