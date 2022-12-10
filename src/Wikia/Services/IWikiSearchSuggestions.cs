using System.Threading.Tasks;
using wikia.Models.SearchSuggestions;

namespace wikia.Services
{
    public interface IWikiSearchSuggestions
    {
        Task<SearchSuggestionsPhrases> SuggestedPhrases(string query);
    }
}