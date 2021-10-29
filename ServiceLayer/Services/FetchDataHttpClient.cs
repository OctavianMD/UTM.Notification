using System.Net.Http;
using System.Threading.Tasks;
using CommonLayer;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class FetchDataHttpClient: IFetchDataClient
    {
        private readonly HttpClient _httpClient;
        private const string SendersEndpoint = "https://localhost:44354/api/dataseed/senders";
        private const string ReceiversEndpoint = "https://localhost:44354/api/dataseed/receivers";

        public FetchDataHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(Constants.FetchDataHttpClientName);
        }

        public async Task<string> FetchSenders()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, SendersEndpoint));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<string> FetchReceivers()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, ReceiversEndpoint));
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
