using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Email
{
	public interface IEmailSender
	{
		void SendEmail(EmailDto emailObj);
	}
}
