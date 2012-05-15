using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace fb.net
{
	public class FacebookUser
	{
		public FacebookUser ()
		{
		}

		public double Id { get; set; }
		public string Name { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public string Link { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }

		//public FacebookError Error { get; set; }

		public FacebookNamedItem Location { get; set; }
		public List<FacebookWork> Work { get; set; }
		public List<FacebookEducation> Education { get; set; }

		public GenderTypes Gender { get; set; } 
		public double TimeZone { get; set; }
		//public Locale fbLocale { get; set; }
		public Boolean Verified { get; set; }
		public DateTime Updated_Time { get; set; }
		public string Type { get; set; }

		public enum GenderTypes
        {
            Male,
            Female,
            Undefined
        }
	}

}

