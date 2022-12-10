using System.Threading.Tasks;
using wikia.Models.Article.Details;

namespace wikia.Api
{
    public interface IWikiArticle
    {
        /// <summary>
        /// Get details about one or more articles
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<ExpandedArticleResultSet> Details(params int[] ids);

        /// <summary>
        /// Get details about one or more articles
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        Task<ExpandedArticleResultSet> Details(ArticleDetailsRequestParameters requestParameters);
    }
}