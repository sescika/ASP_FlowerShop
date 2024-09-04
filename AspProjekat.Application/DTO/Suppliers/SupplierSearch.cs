using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Suppliers
{
	public class SupplierSearch : PagedSearch
	{
        public string Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
    }
}
