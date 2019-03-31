using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Enums;
using wikia.Helper;
using wikia.Models.Article.Details;
using wikia.Models.Article.Simple;

namespace wikia.Api
{
    public sealed class WikiArticle : IWikiArticle
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private static readonly Dictionary<ArticleEndpoint, string> Endpoints;
        private readonly string _wikiApiUrl;

        static WikiArticle()
        {
            Endpoints = new Dictionary<ArticleEndpoint, string>
            {
                {ArticleEndpoint.Simple, "Articles/AsSimpleJson"},
                {ArticleEndpoint.Details, "Articles/Details"},
                {ArticleEndpoint.List, "Articles/List"},
                {ArticleEndpoint.NewArticles, "Articles/New"},
                {ArticleEndpoint.Popular, "Articles/Popular"}
            };
        }

        public WikiArticle(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {
            
        }
        public WikiArticle(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {
            
        }

        public WikiArticle(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public async Task<ContentResult> Simple(long id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var json = await ArticleRequest(ArticleEndpoint.Simple, () => new Dictionary<string, string> { ["id"] = id.ToString() });

            return JsonHelper.Deserialize<ContentResult>(json);
        }

        public Task<string> ArticleRequest(ArticleEndpoint endpoint, Func<IDictionary<string, string>> getParameters)
        {
            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, Endpoints[endpoint]);
            var parameters = getParameters.Invoke();
            return _wikiaHttpClient.GetString(requestUrl, parameters);
        }

        public Task<ExpandedArticleResultSet> Details(params int[] ids)
        {
            return Details(new ArticleDetailsRequestParameters(ids));
        }

        public async Task<ExpandedArticleResultSet> Details(ArticleDetailsRequestParameters requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            var json = await ArticleRequest(ArticleEndpoint.Details, () => ArticleHelper.GetDetailsParameters(requestParameters));

            return JsonHelper.Deserialize<ExpandedArticleResultSet>(json);
        }
    }
}