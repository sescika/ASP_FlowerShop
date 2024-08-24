using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Supplier : NamedEntity
	{
        public string SupplierEmail { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierState { get; set; }
        public string SupplierZipCode { get; set; }

        public virtual Product Product { get; set; }
    }
}
