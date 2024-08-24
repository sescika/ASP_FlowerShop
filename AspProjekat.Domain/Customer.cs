using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Customer : NamedEntity
	{
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
		public virtual ICollection<CustomerUseCase> UseCases { get; set; } = new HashSet<CustomerUseCase>();
	}
}
