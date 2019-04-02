using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Helper;
using wikia.Models.RelatedPages;

namespace wikia.Api
{
    public class WikiRelatedPages
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;
        private const string RelatedPagesUrlSegment = "RelatedPages/List";

        public WikiRelatedPages(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }

        public WikiRelatedPages(string domainUrl, IHttpClientFactory httpClientFactory)
            : this(domainUrl, WikiaSettings.ApiVersion, new WikiaHttpClient(httpClientFactory))
        {

        }

        public WikiRelatedPages(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiRelatedPages(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public Task<RelatedPages> Articles(params int[] ids)
        {
            return Articles(new RelatedArticlesRequestParameters { Ids = ids });
        }
        public async Task<RelatedPages> Articles(RelatedArticlesRequestParameters requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            if (requestParameters.Ids == null || !requestParameters.Ids.Any())
                throw new ArgumentException("Article Id(s) required.", nameof(requestParameters.Ids));

            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, RelatedPagesUrlSegment);
            var parameters = GetArticlesParameters(requestParameters);
            var json = await _wikiaHttpClient.GetString(requestUrl, parameters);

            return JsonHelper.Deserialize<RelatedPages>(json);
        }

        #region private helpers

        private static IDictionary<string, string> GetArticlesParameters(RelatedArticlesRequestParameters requestParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                [Constants.Ids] = string.Join(",", requestParameters.Ids),
                [Constants.Limit] = requestParameters.Limit.ToString(),
            };

            return parameters;
        }

        #endregion

    }
}