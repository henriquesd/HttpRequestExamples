using HttpRequestExamples.Interfaces;
using HttpRequestExamples.Models;
using System.Net;
using System.Text.Json;

namespace HttpRequestExamples.Repositories
{
    public class HttpClientExample : IHttpClientExample
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUri;

        private static HttpClient _httpClient = new HttpClient();

        public HttpClientExample(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUri = _configuration.GetSection("CoinDeskApi:Url").Value;
        }

        // This is the recommended way to use HttpClient;
        public async Task<BtcContent?> GetBtcContent()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUri}currentprice.json");
                response.EnsureSuccessStatusCode();

                var btcCurrentPrice = JsonSerializer.Deserialize<BtcContent>(await response.Content.ReadAsStringAsync());
                return btcCurrentPrice;
            }
            catch (Exception ex)
            {
                return await Task.FromException<BtcContent>(ex);
            }
        }

        // This is NOT the recommended way to use HttpClient;
        public async Task<BtcContent?> GetBtcContentWithUsing()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"{_baseUri}currentprice.json");
                    response.EnsureSuccessStatusCode();

                    var btcCurrentPrice = JsonSerializer.Deserialize<BtcContent>(await response.Content.ReadAsStringAsync());
                    return btcCurrentPrice;
                }
            }
            catch (Exception ex)
            {
                return await Task.FromException<BtcContent>(ex);
            }
        }

        // This is NOT the recommended way to use HttpClient;
        public async Task<List<int>> GetGoogle()
        {
            var listStatusCode = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync("https://www.google.com");
                    listStatusCode.Add((int)response.StatusCode);
                }
            }
            return listStatusCode;
        }
    }
}