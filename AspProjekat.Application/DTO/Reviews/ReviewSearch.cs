using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Reviews
{
	public class ReviewSearch : PagedSearch
	{
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
