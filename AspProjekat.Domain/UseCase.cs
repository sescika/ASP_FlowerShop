using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class UseCase : NamedEntity
	{
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
		public virtual ICollection<UseCaseLog> UseCaseLogs { get; set; } = new HashSet<UseCaseLog>();
	}
}
