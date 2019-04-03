using System.Threading.Tasks;
using wikia.Models.SearchSuggestions;

namespace wikia.Api
{
    public interface IWikiSearchSuggestions
    {
        Task<SearchSuggestionsPhrases> SuggestedPhrases(string query);
    }
}