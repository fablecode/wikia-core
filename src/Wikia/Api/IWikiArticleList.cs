using System.Threading.Tasks;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.NewArticles;
using wikia.Models.Article.PageList;

namespace wikia.Api
{
    public interface IWikiArticleList
    {
        Task<UnexpandedListArticleResultSet> AlphabeticalList(string category);
        Task<UnexpandedListArticleResultSet> AlphabeticalList(ArticleListRequestParameters requestParameters);
        Task<ExpandedListArticleResultSet> PageList(string category);
        Task<ExpandedListArticleResultSet> PageList(ArticleListRequestParameters requestParameters);
        Task<T> ArticleList<T>(ArticleListRequestParameters requestParameters, bool expand);
        Task<NewArticleResultSet> NewArticles();
        Task<NewArticleResultSet> NewArticles(NewArticleRequestParameters requestParameters);
    }
}