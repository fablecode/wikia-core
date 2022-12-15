using System.Threading.Tasks;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.PageList;

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
    }
}