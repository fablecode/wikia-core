using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Helper;
using wikia.Models.Search;

namespace wikia.Api
{
    public class WikiSearch : IWikiSearch
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;
        private const string SearchListUrlSegment = "Search/List";

        public WikiSearch(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }

        public WikiSearch(string domainUrl, IHttpClientFactory httpClientFactory)
            : this(domainUrl, WikiaSettings.ApiVersion, new WikiaHttpClient(httpClientFactory))
        {

        }

        public WikiSearch(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiSearch(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public async Task<LocalWikiSearchResultSet> SearchList(SearchListRequestParameter requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, SearchListUrlSegment);
            var parameters = GetSearchListParameters(requestParameters);
            var json = await _wikiaHttpClient.GetString(requestUrl, parameters);

            return JsonHelper.Deserialize<LocalWikiSearchResultSet>(json);
        }

        #region private helpers

        private static IDictionary<string, string> GetSearchListParameters(SearchListRequestParameter requestParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                ["query"] = string.Join(",", requestParameters.Query),
                [Constants.Limit] = requestParameters.Limit.ToString(),
                [Constants.MinArticleQuality] = requestParameters.MinArticleQuality.ToString(),
                ["batch"] = requestParameters.Batch.ToString(),
                [Constants.Namespaces] = string.Join(",", requestParameters.Namespaces)
            };

            if (!string.IsNullOrEmpty(requestParameters.Type))
                parameters["type"] = requestParameters.Type;

            if (!string.IsNullOrEmpty(requestParameters.Rank))
                parameters["rank"] = requestParameters.Rank;

            return parameters;
        }

        #endregion

    }
}