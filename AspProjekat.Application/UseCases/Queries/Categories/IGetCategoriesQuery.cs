using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Queries.Categories
{
    public interface IGetCategoriesQuery : IQuery<PagedResponse<CategoryDto>, CategorySearch>
	{
	}
}
