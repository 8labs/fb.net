using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace fb.net
{
	public class Facebook
	{

		private RestClient restClient;
		private string token;

		/// <summary>
		/// Initializes a new instance of the <see cref="fb.net.Facebook"/> class.
		/// </summary>
		/// <param name='access_token'>
		/// Facebook access token.
		/// </param>
		public Facebook (string access_token)
		{
			this.token = access_token;
			this.restClient = new RestClient("https://graph.facebook.com");
		}

		public FacebookUser GetUser()
		{
			var request = new RestRequest("me", Method.GET);
			request.AddParameter("access_token", token);
			IRestResponse<FacebookUser> fbUser = restClient.Execute<FacebookUser>(request);

			FacebookUser me = JsonConvert.DeserializeObject<FacebookUser>(fbUser.Content);

			return fbUser.Data;
		}

	}
}

