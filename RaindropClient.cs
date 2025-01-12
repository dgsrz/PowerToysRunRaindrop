using System.Net.Http;
using System.Text.Json;
using Wox.Plugin.Logger;

namespace Community.PowerToys.Run.Plugin.Raindrop
{
	public class RaindropClient
	{
		private readonly HttpClient httpClient = new HttpClient();

		private string? AccessToken { get; set; }

		public RaindropClient(string? apiToken)
		{
			AccessToken = apiToken;
		}

		public SearchResult<Bookmark>? Request(string search)
		{
			var queries = new Dictionary<string, string>
			{
				{ "sort", "-created" },
				{ "search", search }
			};
			var queryString = new FormUrlEncodedContent(queries).ReadAsStringAsync().Result;

			var req = new HttpRequestMessage(HttpMethod.Get, $"https://api.raindrop.io/rest/v1/raindrops/0?{queryString}");
			req.Headers.Add("Authorization", "Bearer " + AccessToken);

			var res = httpClient.Send(req);
			if (res.IsSuccessStatusCode)
			{
				string json = res.Content.ReadAsStringAsync().Result;
				return JsonSerializer.Deserialize<SearchResult<Bookmark>>(json);
			}
			return new SearchResult<Bookmark>
			{
				result = false,
				items = new List<Bookmark>()
			};
		}
	}
}
