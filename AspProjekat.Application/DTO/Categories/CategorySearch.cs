using AspProjekat.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DTO.Categories
{
    public class CategorySearch : PagedSearch
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
