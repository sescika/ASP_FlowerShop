using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class CustomerUseCase
	{
		public int CustomerId { get; set; }
		public int UseCaseId { get; set; }
		public virtual Customer User { get; set; }
	}
}
