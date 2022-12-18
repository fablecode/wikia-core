using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.PageList;

namespace wikia.Services
{
    public sealed class WikiArticleList : IWikiArticleList
    {
        private readonly IWikiArticleListApi _wikiArticleListApi;

        public WikiArticleList(string domainUrl) 
            : this(WikiaRestService.For<IWikiArticleListApi>(domainUrl))
        {
        }

        public WikiArticleList(IWikiArticleListApi wikiArticleListApi)
        {
            _wikiArticleListApi = wikiArticleListApi;
        }

        public Task<UnexpandedListArticleResultSet> AlphabeticalList(string category)
        {
            return AlphabeticalList(new ArticleListRequestParameters(category));
        }

        public Task<UnexpandedListArticleResultSet> AlphabeticalList(ArticleListRequestParameters requestParameters)
        {
            return _wikiArticleListApi.AlphabeticalList(requestParameters);
        }

        public Task<ExpandedListArticleResultSet> PageList(string category)
        {
            return PageList(new ArticleListRequestParameters(category));
        }

        public Task<ExpandedListArticleResultSet> PageList(ArticleListRequestParameters requestParameters)
        {
            requestParameters.Expand = "1";
            return _wikiArticleListApi.PageList(requestParameters);
        }
    }
}