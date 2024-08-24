using AspProjekat.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application
{
	public interface IQuery<TResult, TSearch> : IUseCase
		where TResult : class
	{
		TResult Execute(TSearch search);
	}
}
