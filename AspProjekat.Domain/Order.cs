using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Order : Entity
	{
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentMethod { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual DeliveryDetails DeliveryDetails { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
