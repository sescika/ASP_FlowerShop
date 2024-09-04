using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Reviews
{
	public class ReviewDto
	{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Rating { get; set; }
        public string CustomerUsername { get; set; }
        public string ReviewText { get; set; }
    }
}
