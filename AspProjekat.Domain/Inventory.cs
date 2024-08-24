using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Inventory : Entity
	{
        public int ProductId { get; set; }
        public int QuantityAvailable { get; set; }

        public virtual Product Product { get; set; }
    }
}
