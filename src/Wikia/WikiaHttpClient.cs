using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace wikia
{
    public sealed class WikiaHttpClient : IWikiaHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

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
            var client = _httpClientFactory.CreateClient();

            url = QueryHelpers.AddQueryString(url, parameters);

            return client.GetStringAsync(url);
        }
    }
}