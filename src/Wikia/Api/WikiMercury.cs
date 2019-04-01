using System.Net.Http;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Helper;
using wikia.Models.Mercury;

namespace wikia.Api
{
    public sealed class WikiMercury
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;
        private const string WikiVariablesUrl = "Mercury/WikiVariables";

        public WikiMercury(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }

        public WikiMercury(string domainUrl, IHttpClientFactory httpClientFactory)
            : this(domainUrl, WikiaSettings.ApiVersion, new WikiaHttpClient(httpClientFactory))
        {

        }

        public WikiMercury(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiMercury(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public async Task<WikiDataContainer> WikiVariables()
        {
            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, WikiVariablesUrl);
            var json = await _wikiaHttpClient.GetString(requestUrl);

            return JsonHelper.Deserialize<WikiDataContainer>(json);
        }
    }
}