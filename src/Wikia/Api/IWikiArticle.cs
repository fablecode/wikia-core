using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Enums;
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
        /// Execute article request and return response
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="getParameters"></param>
        /// <returns></returns>
        Task<string> ArticleRequest(ArticleEndpoint endpoint, Func<IDictionary<string, string>> getParameters);

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