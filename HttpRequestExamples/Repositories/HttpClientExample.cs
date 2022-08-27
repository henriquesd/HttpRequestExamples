using HttpRequestExamples.Interfaces;
using HttpRequestExamples.Models;
using System.Text.Json;

namespace HttpRequestExamples.Repositories
{
    public class HttpClientExample : IHttpClientExample
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUri;

        private static HttpClient _httpClient = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(1)
        });

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

                var btcContent = JsonSerializer.Deserialize<BtcContent>(await response.Content.ReadAsStringAsync());
                return btcContent;
            }
            catch (Exception ex)
            {
                return await Task.FromException<BtcContent>(ex);
            }
        }

        #region Example of how NOT to use the HttpClient;

        // This is NOT the recommended way to use HttpClient;
        public async Task<BtcContent?> GetBtcContentWithUsing()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync($"{_baseUri}currentprice.json");

                    var btcContent = JsonSerializer.Deserialize<BtcContent>(await response.Content.ReadAsStringAsync());
                    return btcContent;
                }
            }
            catch (Exception ex)
            {
                return await Task.FromException<BtcContent>(ex);
            }
        }
        #endregion
    }
}