using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO
{
	public class SortBy
	{
		public string SortProperty { get; set; }
		public SortDirection Direction { get; set; }
	}
	public enum SortDirection {Asc,Desc}
}
