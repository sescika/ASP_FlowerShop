using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Categories;
using AspProjekat.Application.UseCases.Queries.Categories;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases.Queries.Categories
{
    public class EFGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
	{
		private readonly IMapper mapper;

		public EFGetCategoriesQuery(FlowershopContext context, IMapper mapper) : base(context)
		{
			this.mapper = mapper;
		}
		public int Id => 1;
		public string Name => "Get All Categories";
		public PagedResponse<CategoryDto> Execute(CategorySearch search)
		{
			var query = Context.Categories.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}

			if (search.Id > 0)
			{
				query = query.Where(x => x.Id == search.Id);
			}

			int totalCount = query.Count();	
			int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
			int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


			int skip = perPage * (page - 1);

			query = query.Skip(skip).Take(perPage);
			return new PagedResponse<CategoryDto>
			{
				CurrentPage = page,
				TotalCount = totalCount,
				Data = query.Select(x => new CategoryDto
				{
					Id = x.Id,
					Name = x.Name

				}).ToList(),
				PerPage = perPage
			};
		}
	}
}
