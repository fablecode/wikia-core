﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Enums;
using wikia.Helper;
using wikia.Models.Article.Details;

namespace wikia.Api
{
    public sealed class WikiArticle : WikiArticleEndpoint, IWikiArticle
    {
        public WikiArticle(string domainUrl)
            : base(domainUrl, WikiaSettings.ApiVersion)
        {
            
        }
        public WikiArticle(string domainUrl, string apiVersion)
            : base(domainUrl, apiVersion, new WikiaHttpClient())
        {
            
        }

        public WikiArticle(string domainUrl, IHttpClientFactory httpClientFactory)
            : this(domainUrl, WikiaSettings.ApiVersion, new WikiaHttpClient(httpClientFactory))
        {

        }


        public WikiArticle(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        : base(domainUrl, apiVersion, wikiaHttpClient)
        {
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