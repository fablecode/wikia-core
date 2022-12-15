using Refit;
using System.Threading.Tasks;
using wikia.Constants;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.PageList;

namespace wikia.Api;

public interface IWikiArticleListApi
{
    /// <summary>
    /// Get article list in alphabetical order
    /// </summary>
    /// <param name="requestParameters"></param>
    /// <returns></returns>
    [Get(ArticleEndpoint.List)]
    Task<UnexpandedListArticleResultSet> AlphabeticalList(ArticleListRequestParameters requestParameters);

    /// <summary>
    /// Get a list of pages on the current wiki
    /// </summary>
    /// <param name="requestParameters"></param>
    /// <returns></returns>
    [Get(ArticleEndpoint.List)]
    Task<ExpandedListArticleResultSet> PageList(ArticleListRequestParameters requestParameters);
}