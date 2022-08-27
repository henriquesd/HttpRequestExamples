using HttpRequestExamples.Interfaces;
using HttpRequestExamples.Repositories;

namespace HttpRequestExamples.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpClientExample, HttpClientExample>();
            services.AddScoped<IHttpClientFactoryExample, HttpClientFactoryExample>();

            // This is necessary to use IHttpClientFactory;
            services.AddHttpClient();

            // Named client configuration;
            services.AddHttpClient("coinDeskApi", client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("CoinDeskApi:Url"));
            });

            return services;
        }
    }
}