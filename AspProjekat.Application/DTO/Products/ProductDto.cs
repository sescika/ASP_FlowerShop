using AspProjekat.Application.DTO.Categories;

using System.Collections.Generic;


namespace AspProjekat.Application.DTO.Products
{
	public class ProductDto : PagedSearch
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IEnumerable<CategoryDto> Categories { get; set; }
		public string SupplierName { get; set; }
		public int QuantityLeftInInventory { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
	}
}
