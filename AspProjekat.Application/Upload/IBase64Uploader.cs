using System;
using System.Collections.Generic;
using System.Text;

namespace AspYt.Application.Upload
{
	public interface IBase64Uploader
	{
		bool IsExtensionValid(string base64File);
		string GetExtension(string base64File);
		string Upload(string base64File);
	}
}
