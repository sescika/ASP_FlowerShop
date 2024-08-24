using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Product : NamedEntity
	{
        public string Description { get; set; }
        public double Price { get; set; }
        public int SupplierId { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual Supplier Supplier { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
