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
			FacebookUser me = ApiCall<FacebookUser>("me", Method.GET);
			return me;
		}


		public T ApiCall<T>(String method, Method httpType)
		{
			return ApiCall<T>(method, httpType, null);
		}

		public T ApiCall<T>(String method, Method httpType, KeyValuePair<string, string>[] args)
        {
            return (T)ApiCall(typeof(T), method, httpType, args);
        }

		public object ApiCall(Type type, String method, Method httpType, KeyValuePair<string, string>[] args)
		{
			var request = new RestRequest(method, httpType);
			request.AddParameter("access_token", token);

			if (args != null)
			{
				foreach (KeyValuePair<string, string> arg in args)
				{
					request.AddParameter(arg.Key, arg.Value);
				}
			}

			IRestResponse response = restClient.Execute(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

			object obj = JsonConvert.DeserializeObject(response.Content, type);

			return obj;
		}


	}
}

