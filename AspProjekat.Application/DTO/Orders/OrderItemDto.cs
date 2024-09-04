using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Orders
{
	public class OrderItemDto
	{
		public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
		public decimal Price { get; set; }
    }
}
