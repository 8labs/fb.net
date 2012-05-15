using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using System.Collections.Generic;


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
			//FacebookUser test = ApiCall<FacebookUser>("me", Method.GET);

			var request = new RestRequest("me", Method.GET);
			request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
			request.AddParameter("access_token", token);
			IRestResponse<FacebookUser> fbUser = restClient.Execute<FacebookUser>(request);

			FacebookUser me = JsonConvert.DeserializeObject<FacebookUser>(fbUser.Content);

			return fbUser.Data;
		}

		/*
		public T ApiCall<T>(String method, Method type)
		{
			return ApiCall<T>(method, type, null);
		}

		public T ApiCall<T>(String method, Method type, KeyValuePair<string, string>[] args)
		{
			var request = new RestRequest(method, type);
			request.AddParameter("access_token", token);

			foreach (KeyValuePair<string, string> arg in args)
			{
				request.AddParameter(arg.Key, arg.Value);
			}

			IRestResponse<T> response = restClient.Execute<T>(request);

			return response.Data;
		}
		*/

	}
}

