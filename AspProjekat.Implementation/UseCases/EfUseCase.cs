using AspProjekat.Application;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation.UseCases
{
	public abstract class EfUseCase
	{
		private readonly FlowershopContext _context;

		protected EfUseCase(FlowershopContext context)
		{
			_context = context;
		}

		protected FlowershopContext Context => _context;
	}
}
