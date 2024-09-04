using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Orders
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string Status { get; set; }
		//public double TotalAmount { get; set; }
		public string PaymentMethod { get; set; }
		public IEnumerable<OrderItemDto> OrderItems { get; set; }
		public DeliveryDetailsDto DeliveryDetails { get; set; }
		public string CustomerUsername { get; set; }
	}
}
