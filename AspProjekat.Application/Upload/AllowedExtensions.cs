using System;
using System.Collections.Generic;
using System.Text;

namespace AspYt.Application.Upload
{
	public class AllowedExtensions
	{
		public IEnumerable<string> Extensions => new List<string>
		{
			"jpg", "png", "pdf"
		};
	}
}
