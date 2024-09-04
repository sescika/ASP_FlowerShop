﻿using System;
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
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
    }
}
