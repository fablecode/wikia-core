using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Threading.Tasks;
using wikia.Helper;
using wikia.Models.Article;
using wikia.Models.Article.AlphabeticalList;
using wikia.Models.Article.PageList;
using wikia.Services;

namespace wikia.Api
{
    public sealed class WikiArticleList : WikiArticleEndpoint, IWikiArticleList
    {
        private readonly IWikiArticleListApi _wikiArticleListApi;

        public WikiArticleList(string domainUrl) : base(domainUrl)
        {
            _wikiArticleListApi = RestService.For<IWikiArticleListApi>(domainUrl,
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            Converters = { new StringEnumConverter() }
                        }
                    )
                });
        }
        public WikiArticleList(string domainUrl, string apiVersion)
            : base(domainUrl, apiVersion, new WikiaHttpClient())
        {

        }

        public WikiArticleList(string domainUrl, string apiVersion, IWikiaHttpClient wikiaHttpClient)
            : base(domainUrl, apiVersion, wikiaHttpClient)
        {
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

        public async Task<T> ArticleList<T>(ArticleListRequestParameters requestParameters, bool expand)
        {
            if (requestParameters == null)
                throw new ArgumentNullException(nameof(requestParameters));

            //var json = await ArticleRequest(ArticleEndpoint.List, () => ArticleHelper.GetListParameters(requestParameters, expand));

            return JsonHelper.Deserialize<T>(string.Empty);
        }
    }
}