using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Customers
{
	public class CustomerDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
