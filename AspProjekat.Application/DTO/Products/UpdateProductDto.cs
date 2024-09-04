﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Products
{
	public class UpdateProductDto
	{
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? QuantityAvailable { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
    }
}
