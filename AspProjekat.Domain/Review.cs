using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Review : Entity
	{
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public float Rating { get; set; }
        public string ReviewText { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
