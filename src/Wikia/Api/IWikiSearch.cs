using System.Threading.Tasks;
using wikia.Models.Search;

namespace wikia.Api
{
    public interface IWikiSearch
    {
        Task<LocalWikiSearchResultSet> SearchList(SearchListRequestParameter requestParameters);
    }
}