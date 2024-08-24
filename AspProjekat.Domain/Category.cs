using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Category : NamedEntity
	{

		public virtual IEnumerable<Product> Products { get; set; } = new HashSet<Product>();
    }
}
