using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Customers
{
	public class RegisterCustomerDto
	{
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Address { get; set; } = "Address";
        public string City { get; set; } = "City";
        public string State { get; set; } = "State";
        public string ZipCode { get; set; } = "11000";
        public string Password { get; set; }
    }
}
