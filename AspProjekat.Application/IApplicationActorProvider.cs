using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application
{
	public interface IApplicationActorProvider
	{
		IApplicationActor GetActor();
	}
}
