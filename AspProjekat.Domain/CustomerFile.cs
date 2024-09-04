using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class CustomerFile : Entity
	{
		public string Source { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
	}
}
