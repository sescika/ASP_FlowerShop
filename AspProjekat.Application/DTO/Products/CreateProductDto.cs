using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Products
{
	public class CreateProductDto
	{
		public string Description {  get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int SupplierId {  get; set; }
		public int QuantityAvailable { get; set; }
		public string ImageUrl { get; set; }
		public List<int> Categories { get; set; }
	}
}
