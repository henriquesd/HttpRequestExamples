using HttpRequestExamples.Interfaces;
using HttpRequestExamples.Repositories;

namespace HttpRequestExamples.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientExample, HttpClientExample>();
            services.AddScoped<IHttpClientFactoryExample, HttpClientFactoryExample>();

            // This is necessary to use IHttpClientFactory;
            services.AddHttpClient();

            return services;
        }
    }
}