using System.Threading.Tasks;
using Refit;
using wikia.Constants;
using wikia.Models.Article.Details;

namespace wikia.Api;

public interface IWikiArticleApi
{
    /// <summary>
    /// Get details about one or more articles
    /// </summary>
    /// <param name="requestParameters"></param>
    /// <returns></returns>
    [Get(ArticleEndpoint.Details)]
    Task<ExpandedArticleResultSet> Details(ArticleDetailsRequestParameters requestParameters);
}