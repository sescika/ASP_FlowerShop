using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Orders
{
	public class DeliveryDetailsDto
	{
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string DeliveryStatus { get; set; }
    }
}
