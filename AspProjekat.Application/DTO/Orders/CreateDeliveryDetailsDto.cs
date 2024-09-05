using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Orders
{
	public class CreateDeliveryDetailsDto
	{
		public int OrderId { get; set; }
		public DateTime DeliveryDate { get; set; }
		public DateTime DeliveryTime { get; set; }
		public string DeliveryAddress { get; set; }
		public string DeliveryCity { get; set; }
		public string DeliveryState { get; set; }
		public string DeliveryZipCode { get; set; }
		public string DeliveryStatus { get; set; }
	}
}
