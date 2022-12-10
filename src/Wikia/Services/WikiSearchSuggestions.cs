using System;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.SearchSuggestions;

namespace wikia.Services
{
    public sealed class WikiSearchSuggestions : IWikiSearchSuggestions
    {
        private readonly IWikiSearchSuggestionsApi _wikiSearchSuggestionsApi;

        public WikiSearchSuggestions(string domainUrl)
            : this(WikiaRestService.For<IWikiSearchSuggestionsApi>(domainUrl))
        {
        }

        public WikiSearchSuggestions(IWikiSearchSuggestionsApi wikiSearchSuggestionsApi)
        {
            _wikiSearchSuggestionsApi = wikiSearchSuggestionsApi;
        }

        public Task<SearchSuggestionsPhrases> SuggestedPhrases(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Search suggestion query required.", nameof(query));

            return _wikiSearchSuggestionsApi.SuggestedPhrases(query);
        }

    }
}