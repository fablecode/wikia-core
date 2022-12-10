using System.Threading.Tasks;
using Refit;
using wikia.Constants;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.NewArticles;
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

    /// <summary>
    /// Get a list of new articles on this wiki
    /// </summary>
    /// <param name="requestParameters"></param>
    /// <returns></returns>
    [Get(ArticleEndpoint.NewArticles)]
    Task<NewArticleResultSet> NewArticles(NewArticleRequestParameters requestParameters);
}