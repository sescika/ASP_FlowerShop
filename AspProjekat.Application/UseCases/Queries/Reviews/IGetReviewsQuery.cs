using AspProjekat.Application.DTO;
using AspProjekat.Application.DTO.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.UseCases.Queries.Reviews
{
	public interface IGetReviewsQuery : IQuery<PagedResponse<ReviewDto>, ReviewSearch>
		{ }
}
