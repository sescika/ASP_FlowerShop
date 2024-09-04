using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Orders
{
	public class OrderSearch : PagedSearch
	{
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public string CustomerUsername { get; set; }
    }
}
