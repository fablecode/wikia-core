using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Helper;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.PageList;
using wikia.Services;

namespace wikia.Api
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