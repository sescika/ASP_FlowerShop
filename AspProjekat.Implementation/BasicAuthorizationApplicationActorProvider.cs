using AspProjekat.Application;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.Implementation
{
	public class BasicAuthorizationApplicationActorProvider //: IApplicationActorProvider
	{
		private string _authorizationHeader;
		private FlowershopContext _context;

		public BasicAuthorizationApplicationActorProvider(string authorizationHeader, FlowershopContext context)
		{
			_authorizationHeader = authorizationHeader;
			_context = context;
		}

		public IApplicationActor GetActor()
		{
			if (_authorizationHeader == null || !_authorizationHeader.Contains("Basic"))
			{
				return new UnauthorizedActor();
			}

			var base64Data = _authorizationHeader.Split(" ")[1];


			var bytes = Convert.FromBase64String(base64Data);

			var decodedCredentials = System.Text.Encoding.UTF8.GetString(bytes);

			if (decodedCredentials.Split(":").Length < 2)
			{
				throw new InvalidOperationException("Invalid Basic authorization header.");
			}

			string username = decodedCredentials.Split(":")[0];
			string password = decodedCredentials.Split(":")[1];

			Customer u = _context.Customers.Include(x => x.UseCases)
								   .FirstOrDefault(x => x.Username == username && x.Password == password);

			if (u == null)
			{
				return new UnauthorizedActor();
			}

			var useCases = u.UseCases.Select(x => x.UseCaseId).ToList();

			return new Actor
			{
				//Email = u.Email,
				//FirstName = u.Name,
				Id = u.Id,
				//LastName = u.LastName,
				Username = u.Username,
				AllowedUseCases = useCases
			};
		}
	}
}
