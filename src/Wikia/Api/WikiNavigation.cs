using System.Net.Http;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Helper;
using wikia.Models;

namespace wikia.Api
{
    public sealed class WikiNavigation : IWikiNavigation
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;
        private const string NavigationLinksEndpoint = "Navigation/Data";

        public WikiNavigation(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }

        public WikiNavigation(string domainUrl, IHttpClientFactory httpClientFactory)
            : this(domainUrl, WikiaSettings.ApiVersion, new WikiaHttpClient(httpClientFactory))
        {

        }

        public WikiNavigation(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiNavigation(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public async Task<NavigationResultSet> NavigationLinks()
        {
            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, NavigationLinksEndpoint);
            var json = await _wikiaHttpClient.GetString(requestUrl);

            return JsonHelper.Deserialize<NavigationResultSet>(json);
        }
    }
}