using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Email
{
    public class EmailDto
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
