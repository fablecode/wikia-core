using System.Threading.Tasks;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.NewArticles;
using wikia.Models.Article.PageList;
using wikia.Models.Article.Popular;

namespace wikia.Services
{
    public interface IWikiArticleList
    {
        /// <summary>
        /// Get article list in alphabetical order given an article category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<UnexpandedListArticleResultSet> AlphabeticalList(string category);
        /// <summary>
        /// Get article list in alphabetical order
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        Task<UnexpandedListArticleResultSet> AlphabeticalList(ArticleListRequestParameters requestParameters);
        /// <summary>
        /// Get a list of pages on the current wiki given an article category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<ExpandedListArticleResultSet> PageList(string category);
        /// <summary>
        /// Get a list of pages on the current wiki
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        Task<ExpandedListArticleResultSet> PageList(ArticleListRequestParameters requestParameters);
        /// <summary>
        /// Get a list of pages on the current wiki
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestParameters"></param>
        /// <param name="expand"></param>
        /// <returns></returns>
        Task<T> ArticleList<T>(ArticleListRequestParameters requestParameters, bool expand);
        /// <summary>
        /// Get list of new articles on this wiki
        /// </summary>
        /// <returns></returns>
        Task<NewArticleResultSet> NewArticles();
        /// <summary>
        /// Get a list of new articles on this wiki
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        Task<NewArticleResultSet> NewArticles(NewArticleRequestParameters requestParameters);
        /// <summary>
        /// Get simple information about popular articles for the current wiki
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        Task<PopularListArticleResultSet> PopularArticleSimple(PopularArticleRequestParameters requestParameters);
        /// <summary>
        /// Get detailed information about popular articles for the current wiki
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        Task<PopularExpandedArticleResultSet> PopularArticleDetail(PopularArticleRequestParameters requestParameters);
        /// <summary>
        /// Get popular articles for the current wiki
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestParameters"></param>
        /// <param name="expand"></param>
        /// <returns></returns>
        Task<T> PopularArticle<T>(PopularArticleRequestParameters requestParameters, bool expand);
    }
}