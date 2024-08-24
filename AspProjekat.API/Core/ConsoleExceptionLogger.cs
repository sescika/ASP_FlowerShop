using AspProjekat.Application;
using AspProjekat.DataAccess;
using AspProjekat.Domain;

namespace AspProjekat.API.Core
{
	public class ConsoleExceptionLogger : IExceptionLogger
	{
		public Guid Log(Exception ex, IApplicationActor actor)
		{
			var id = Guid.NewGuid();
			Console.WriteLine(ex.Message + " ID: " + id);

			return id;
		}
	}
	public class DbExceptionLogger : IExceptionLogger
	{
		private readonly FlowershopContext _context;

		public DbExceptionLogger(FlowershopContext aspContext)
		{
			_context = aspContext;
		}

		public Guid Log(Exception ex, IApplicationActor actor)
		{
			Guid id = Guid.NewGuid();
			//ID, Message, Time, StrackTrace
			ErrorLog log = new()
			{
				ErrorId = id,
				Message = ex.Message,
				StrackTrace = ex.StackTrace,
				Time = DateTime.UtcNow
			};


			_context.ErrorLogs.Add(log);

			_context.SaveChanges();

			return id;
		}
	}
}
