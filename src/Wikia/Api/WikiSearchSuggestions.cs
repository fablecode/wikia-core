using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Helper;
using wikia.Models.SearchSuggestions;

namespace wikia.Api
{
    public class WikiSearchSuggestions : IWikiSearchSuggestions
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;
        private const string SearchSuggestionsUrlSegment = "SearchSuggestions/List";

        public WikiSearchSuggestions(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }

        public WikiSearchSuggestions(string domainUrl, IHttpClientFactory httpClientFactory)
            : this(domainUrl, WikiaSettings.ApiVersion, new WikiaHttpClient(httpClientFactory))
        {

        }

        public WikiSearchSuggestions(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiSearchSuggestions(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public async Task<SearchSuggestionsPhrases> SuggestedPhrases(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Search suggestion query required.", nameof(query));

            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, SearchSuggestionsUrlSegment);
            var parameters = new Dictionary<string, string> { ["query"] = query };
            var json = await _wikiaHttpClient.GetString(requestUrl, parameters);

            return JsonHelper.Deserialize<SearchSuggestionsPhrases>(json);
        }

    }
}