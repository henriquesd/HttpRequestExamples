using HttpRequestExamples.Interfaces;
using HttpRequestExamples.Models;
using System.Text.Json;

namespace HttpRequestExamples.Repositories
{
    public class HttpClientFactoryExample : IHttpClientFactoryExample
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string _baseUri;

        public HttpClientFactoryExample(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _baseUri = _configuration.GetSection("CoinDeskApi:Url").Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<BtcContent?> GetBtcContent()
        {
            try
            {
                using var client = _httpClientFactory.CreateClient();

                var apiUrl = $"{_baseUri}currentprice.json";
                var response = await client.GetAsync(apiUrl);

                var btcContent = JsonSerializer.Deserialize<BtcContent>(await response.Content.ReadAsStringAsync());
                return btcContent;
            }
            catch (Exception ex)
            {
                return await Task.FromException<BtcContent>(ex);
            }
        }

        public async Task<BtcContent?> GetBtcContentWithNamedClient()
        {
            try
            {
                using var client = _httpClientFactory.CreateClient("coinDeskApi");

                var response = await client.GetAsync("currentprice.json");

                var btcContent = JsonSerializer.Deserialize<BtcContent>(await response.Content.ReadAsStringAsync());
                return btcContent;
            }
            catch (Exception ex)
            {
                return await Task.FromException<BtcContent>(ex);
            }
        }
    }
}