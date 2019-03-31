using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using wikia.Configuration;
using wikia.Enums;
using wikia.Helper;
using wikia.Models.Activity;

namespace wikia.Api
{
    public sealed class WikiActivity : IWikiActivity
    {
        private readonly IWikiaHttpClient _wikiaHttpClient;
        private readonly string _wikiApiUrl;

        private static readonly Dictionary<ActivityEndpoint, string> Endpoints;

        static WikiActivity()
        {
            Endpoints = new Dictionary<ActivityEndpoint, string>
            {
                {ActivityEndpoint.LatestActivity, "Activity/LatestActivity"},
                {ActivityEndpoint.RecentlyChangedArticles, "Activity/RecentlyChangedArticles"}
            };
        }


        public WikiActivity(string domainUrl)
            : this(domainUrl, WikiaSettings.ApiVersion)
        {

        }
        public WikiActivity(string domainUrl, string apiVersion)
            : this(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiActivity(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
        {
            _wikiaHttpClient = wikiaHttpClient;
            _wikiApiUrl = UrlHelper.GenerateUrl(domainUrl, apiVersion);
        }

        public Task<ActivityResponseResult> Latest()
        {
            return Latest(new ActivityRequestParameters());
        }

        public Task<ActivityResponseResult> Latest(ActivityRequestParameters requestParameters)
        {
            return ActivityRequest(ActivityEndpoint.LatestActivity, requestParameters);
        }

        public async Task<ActivityResponseResult> ActivityRequest(ActivityEndpoint endpoint, ActivityRequestParameters requestParameters)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            var requestUrl = UrlHelper.GenerateUrl(_wikiApiUrl, Endpoints[endpoint]);
            var parameters = ArticleHelper.GetActivityParameters(requestParameters);
            var json = await _wikiaHttpClient.GetString(requestUrl, parameters);

            return JsonHelper.Deserialize<ActivityResponseResult>(json);
        }
    }
}