using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application
{
	public interface IApplicationActor
	{
		int Id { get; }
		string Username { get; }
		string Email { get; }
		string FirstName { get; }
		string LastName { get; }
		IEnumerable<int> AllowedUseCases { get; }
	}
}
