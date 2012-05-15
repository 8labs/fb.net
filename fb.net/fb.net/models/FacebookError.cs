using System;
namespace fb.net
{
	public class FacebookError
	{
		public FacebookError ()
		{
		}

		string Message { get; set; }
		string Type { get; set; }
		int Code { get; set; }
	}

}

