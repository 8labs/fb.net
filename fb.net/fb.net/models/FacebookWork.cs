using System;
namespace fb.net
{
	public class FacebookWork
	{
		public FacebookWork ()
		{
		}

		FacebookNamedItem Employer { get; set; }
      	FacebookNamedItem Location { get; set; }
		FacebookNamedItem Position { get; set; }
	    string Description { get; set; }
	    DateTime Start_Date { get; set; }
		DateTime End_Date { get; set; }
	}
}

