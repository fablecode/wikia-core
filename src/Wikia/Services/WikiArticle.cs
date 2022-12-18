using System;
using System.Threading.Tasks;
using wikia.Api;
using wikia.Configuration;
using wikia.Models.Article.Details;

namespace wikia.Services
{
    public sealed class WikiArticle : IWikiArticle
    {
        private readonly IWikiArticleApi _wikiArticleApi;

        public WikiArticle(string domainUrl) 
            : this(WikiaRestService.For<IWikiArticleApi>(domainUrl))
        {
        }

        public WikiArticle(IWikiArticleApi wikiArticleApi)
        {
            _wikiArticleApi = wikiArticleApi;
        }

        public Task<ExpandedArticleResultSet> Details(params int[] ids)
        {
            return Details(new ArticleDetailsRequestParameters(ids));
        }

        public Task<ExpandedArticleResultSet> Details(ArticleDetailsRequestParameters requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            return _wikiArticleApi.Details(requestParameters);
        }
    }
}