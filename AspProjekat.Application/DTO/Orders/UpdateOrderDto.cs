using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Orders
{
	public class UpdateOrderDto
	{
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public int Quantity { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
