using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Enums;
using wikia.Helper;
using wikia.Models.Article;
using wikia.Models.Article.NewArticles;

namespace wikia.Api
{
    public abstract class WikiArticleEndpoint
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private static readonly Dictionary<ArticleEndpoint, string> Endpoints;
        private readonly string _wikiApiUrl;

        static WikiArticleEndpoint()
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

        protected WikiArticleEndpoint(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }

        protected WikiArticleEndpoint(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        protected WikiArticleEndpoint(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public Task<string> ArticleRequest(ArticleEndpoint endpoint, Func<IDictionary<string, string>> getParameters)
        {
            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, Endpoints[endpoint]);
            var parameters = getParameters.Invoke();
            return _wikiaHttpClient.GetString(requestUrl, parameters);
        }
    }
}