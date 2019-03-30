using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace wikia
{
    public sealed class WikiaHttpClient : IWikiaHttpClient
    {
        private static IHttpClientFactory _httpClientFactory;

        static WikiaHttpClient()
        {
            var serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
            _httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        }

        public WikiaHttpClient() {}

        public WikiaHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> GetString(string url)
        {
            return GetString(url, new Dictionary<string, string>());
        }

        public Task<string> GetString(string url, IDictionary<string, string> parameters)
        {
            url = QueryHelpers.AddQueryString(url, parameters);

            var httpClient = _httpClientFactory.CreateClient();

            return httpClient.GetStringAsync(url);
        }
    }
}