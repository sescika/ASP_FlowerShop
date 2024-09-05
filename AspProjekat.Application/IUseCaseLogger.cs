using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application
{
	public interface IUseCaseLogger
	{
		void Log(UseCaseLog message);
	}

	public class UseCaseLog
	{
		public string Username { get; set; }
		public string UseCaseName { get; set; }
		public object UseCaseData { get; set; }

		//public static implicit operator UseCaseLog(UseCaseLog v)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
