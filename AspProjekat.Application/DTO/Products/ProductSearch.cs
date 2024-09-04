using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Products
{
	public class ProductSearch : PagedSearch
	{
		public string ProductName { get; set; }
		public double? Price_GreaterThan { get; set; }
		public string SupplierName { get; set; }
		public int? QuantityLeftInInventory_GreaterThan { get; set; }
			
	}
}
