using System.Threading.Tasks;
using wikia.Models.Article.Details;
using wikia.Models.Article.Simple;

namespace wikia.Api
{
    public interface IWikiArticle
    {
        /// <summary>
        /// Get simplified article contents
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ContentResult> Simple(long id);

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