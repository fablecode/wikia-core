using System.Threading.Tasks;
using Refit;
using wikia.Constants;
using wikia.Models.SearchSuggestions;

namespace wikia.Api;

public interface IWikiSearchSuggestionsApi
{

    [Get(ArticleEndpoint.SearchSuggestions)]
    Task<SearchSuggestionsPhrases> SuggestedPhrases(string query);
}